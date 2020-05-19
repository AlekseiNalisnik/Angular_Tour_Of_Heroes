using System.Threading.Tasks;
using Shop.API.Infrastructure.Models;
using Shop.API.Infrastructure.Services;

namespace Shop.API.Domain.UseCases
{
    public class ItemUseCases
    {
        private readonly IItemRepository _itemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly CartUseCases _cartUseCases;

        public ItemUseCases(IItemRepository itemRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            CartUseCases cartUseCases)
        {
            _itemRepository = itemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _cartUseCases = cartUseCases;
        }

        public async Task UpdateItemQuantity(AppUser user, int quantity, int productId)
        {
            var cart = _orderRepository.GetCartByUserId(user.Id);
            // if (cart == null) return NotFound();

            var item = _itemRepository.GetItem(cart.Id, productId);
            // if (cartItem == null) return ;
            
            item.ProductQuantity = quantity;
            _itemRepository.UpdateItem(item);
            await _itemRepository.Save();
        }

        public async Task DeleteItem(string userId, int productId)
        {
            // TODO: Добавить различные проверки.
            var cart = _orderRepository.GetCartByUserId(userId);
            var product = _productRepository.GetProduct(productId);
            var cartItem = _itemRepository.GetItem(cart.Id, productId);
            _itemRepository.DeleteItem(cart.Id, productId);
            await _itemRepository.Save();
        }

        public async Task<Order> AddItem(AppUser user, int productId)
        {
            // TODO: Заебашить проверки. И вообще, код - говно, следует переписать!
            var cart = _orderRepository.GetCartByUserId(user.Id);
            if (cart == null)
            {
                cart = _cartUseCases.CreateNewCart(user);
                _orderRepository.UpdateOrder(cart);
            }
            var product = _productRepository.GetProduct(productId);

            var cartItem = _itemRepository.GetItem(cart.Id, productId);
            if (cartItem == null)
            {
                cartItem = CreateNewItem(cart.Id, productId);
                await _itemRepository.AddItem(cartItem);
            }
            else
            {
                cartItem.ProductQuantity += 1;
                _itemRepository.UpdateItem(cartItem);
            }
            _orderRepository.Save();
            return cart;
        }

        #region Helpers

        private OrderProduct CreateNewItem(int orderId, int productId)
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