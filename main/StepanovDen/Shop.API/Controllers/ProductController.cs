using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Shop.API.Models;
using Shop.API.ViewModels.Product;
using Shop.API.Services;
using Shop.API.ViewModels.Item;
using Shop.API.ViewModels.Order;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger,
            UserManager<AppUser> userManager,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IItemRepository itemRepository,
            IMapper mapper)
        {
            _logger = logger ??
                      throw new ArgumentNullException(nameof(logger));
            _userManager = userManager ??
                           throw new ArgumentNullException(nameof(userManager));
            _productRepository = productRepository ??
                                 throw new ArgumentNullException(nameof(productRepository));
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository));
            _itemRepository = itemRepository ??
                              throw new ArgumentNullException(nameof(itemRepository));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var productEntities = _productRepository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(productEntities));

        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public IActionResult GetProduct(int productId)
        {
            var product = _productRepository.GetProduct(productId);

            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductModel>(product));
        }

        [HttpPost]
        // [Authorize(Policy = "AdminOnly")]
        public IActionResult CreateProduct([FromBody] ProductCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var finalProduct = _mapper.Map<Models.Product>(model);

            _productRepository.AddProduct(finalProduct);

            var productToReturn = _mapper
                .Map<ProductModel>(finalProduct);

            return CreatedAtRoute("GetProduct",
                new {productId = productToReturn.Id},
                productToReturn);
        }

        [HttpPut("{productId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult UpdateProduct(int productId,
            [FromBody] ProductUpdateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return NotFound();

            _mapper.Map(model, productEntity);
            _productRepository.UpdateProduct(productEntity);
            return NoContent();
        }

         
        [HttpPatch("{productId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult PatchProduct(int productId,
            [FromBody] JsonPatchDocument<ProductUpdateModel> productPatch)
        {
            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return NotFound();

            // Маппинг нужен, чтобы применить к нему JsonPatchDocument.
            var productToPatch = _mapper.Map<ProductUpdateModel>(productEntity);
            
            // Убрал ModelState.
            productPatch.ApplyTo(productToPatch);
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!TryValidateModel(productToPatch)) return BadRequest(ModelState);

            _mapper.Map(productToPatch, productEntity);
            _productRepository.UpdateProduct(productEntity);
            return NoContent();
        }


        [HttpDelete("{productId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteProduct(int productId)
        {
            var productEntity = _productRepository.GetProduct(productId);

            if (productEntity == null) return NotFound();

            _productRepository.DeleteProduct(productEntity);
            return NoContent();
        }
        
        [HttpPut("{productId}/addtocart")]
        // [Authorize]
        public async Task<IActionResult> AddProductToCart([FromRoute] int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogError("Пользователь не найден.");
                return NotFound();
            }

            var cart = _orderRepository.GetCartByUserId(user.Id);
            if (cart == null)
            {
                cart = BuildNewOrder(user);
                _orderRepository.AddOrder(cart);
                _orderRepository.Save();
            }
            
            var product = _productRepository.GetProduct(productId);
            if (product == null)
            {
                _logger.LogInformation("Товар не найден.");
                return NotFound();
            }

            var cartItem = _itemRepository.GetItem(cart.Id, productId);
            if (cartItem == null)
            {
                // Нужно ли проводить манипуляции, схожие с созданием нового заказа?
                _logger.LogInformation("Создание нового элемента для корзины.");
                cartItem = BuildNewCartItem(cart.Id, productId);
                await _itemRepository.AddItem(cartItem);
            }
            else
            {
                cartItem.ProductQuantity += 1;
                _itemRepository.UpdateItem(cartItem);
            }
            
            // Обновляю данные по заказу в БД с сохранением.
            _orderRepository.UpdateOrder(cart);
            _orderRepository.Save();
            
            // Возвращаю изменённый заказ.
            var orderToReturn = _mapper.Map<OrderModel>(cart);
            return Ok(orderToReturn);
        }

        [HttpPut("{productId}/deletefromcart")]
        // [Authorize]
        public async Task<IActionResult> DeleteProductFromOrder([FromRoute] int productId)
        {
            // Нужен ли пользователь? Id заказа по идее уже известно. Остаётся только получить данные по заказу.
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();
            
            // Тут следует использовать метод GetOrder();
            var cart = _orderRepository.GetCartByUserId(user.Id);
            if (cart == null) return NotFound();
            
            // TODO: Дописать. Получить все товары в заказе. Получить определённый товар по его ID
            var product = _productRepository.GetProduct(productId);
            if (product == null) return NotFound();
            
            // Найти Id товара в коллекции айтемов заказа. Если его нет => not found.
            var cartItem = _itemRepository.GetItem(cart.Id, productId);
            if (cartItem == null) return NotFound();
            
            _itemRepository.DeleteItem(cart.Id, productId);
            await _itemRepository.Save();    
            return NoContent();
        }

        [HttpPut("{productId}/updatequantity")]
        [Authorize]
        public async Task<IActionResult> ChangeProductQuantity(int productId, [FromBody] ItemUpdateModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();
            
            var cart = _orderRepository.GetCartByUserId(user.Id);
            if (cart == null) return NotFound();

            var cartItem = _itemRepository.GetItem(cart.Id, productId);
            if (cartItem == null) return NotFound();
            
            // Изменить количество товара на value.
            cartItem.ProductQuantity = model.ProductQuantity;
            
            _itemRepository.UpdateItem(cartItem);
            await _itemRepository.Save();
            
            // var orderToReturn = _mapper.Map<OrderModel>(cart);
            return NoContent();
        }
        
        #region Helpers

        private Order BuildNewOrder(AppUser user)
        {
            return new Order()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                AppUserId = user.Id
            };
        }

        private OrderProduct BuildNewCartItem(int orderId, int productId)
        {
            return new OrderProduct()
            {
                OrderId = orderId,
                ProductId = productId,
                ProductQuantity = 1
            };
        }

        #endregion
    }
}
