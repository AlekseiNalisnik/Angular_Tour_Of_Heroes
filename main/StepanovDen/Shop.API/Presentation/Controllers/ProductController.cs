using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.API.Domain.UseCases;
using Shop.API.Infrastructure.Models;
using Shop.API.Infrastructure.Services;
using Shop.API.Presentation.ViewModels.Item;
using Shop.API.Presentation.ViewModels.Order;
using Shop.API.Presentation.ViewModels.Product;

namespace Shop.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ItemUseCases _itemUseCases;

        public ProductController(ILogger<ProductController> logger,
            UserManager<AppUser> userManager,
            IProductRepository productRepository,
            IMapper mapper,
            ItemUseCases itemUseCases)
        {
            _logger = logger ??
                      throw new ArgumentNullException(nameof(logger));
            _userManager = userManager ??
                           throw new ArgumentNullException(nameof(userManager));
            _productRepository = productRepository ??
                                 throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
            _itemUseCases = itemUseCases ??
                           throw new ArgumentNullException(nameof(itemUseCases));
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

            var finalProduct = _mapper.Map<Product>(model);

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
            var productToPatch = _mapper.Map<ProductUpdateModel>(productEntity);
            
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
            _productRepository.DeleteProduct(productEntity);
            return NoContent();
        }
        
        [HttpPut("{productId}/addtocart")]
        [Authorize]
        public async Task<IActionResult> AddProductToCart([FromRoute] int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                _logger.LogError("Пользователь не найден.");
                return NotFound();
            }
            var cart = _itemUseCases.AddItem(user, productId);
            
            var orderToReturn = _mapper.Map<OrderModel>(cart);
            return Ok(orderToReturn);
        }

        [HttpPut("{productId}/deletefromcart")]
        [Authorize]
        public async Task<IActionResult> DeleteProductFromOrder([FromRoute] int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();
            var item = _itemUseCases.DeleteItem(user.Id, productId);
            return NoContent();
        }

        [HttpPut("{productId}/updatequantity")]
        [Authorize]
        public async Task<IActionResult> ChangeProductQuantity(int productId, [FromBody] ItemUpdateModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();
            await _itemUseCases.UpdateItemQuantity(user, model.ProductQuantity, productId);
            return NoContent();
        }
    }
}
