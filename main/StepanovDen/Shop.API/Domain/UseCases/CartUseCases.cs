using Shop.API.Infrastructure.Models;
using Shop.API.Infrastructure.Services;

namespace Shop.API.Domain.UseCases
{
    public class CartUseCases
    {
        private readonly IOrderRepository _orderRepository;
        
        public CartUseCases(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public Order CreateNewCart(AppUser user)
        {
            var newCart = new Order()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                AppUserId = user.Id
            };
            _orderRepository.AddOrder(newCart);
            _orderRepository.Save();
            return newCart;
        }
    }
}