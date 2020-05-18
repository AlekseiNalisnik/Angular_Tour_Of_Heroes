using API_Shop_ref.Infrastructure.Repository;

namespace API_Shop_ref.Domain
{
    public class OrderUseCases
    {
        private readonly IOrederRepository _orderRepository;
        private readonly ICartRepository _cartRepository;

        public OrderUseCases(IOrederRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;

        }
        // сохраняем заказ    
        public void Сheckout(int userId)
        {
            var cartId = _cartRepository.GetUserCartId(userId);
            var price = _orderRepository.Calculate(cartId);
            _orderRepository.AddOrder(cartId, price);                    
        }


        /*
        // получаем заказ        
        public void GetOrder()
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null) { return NotFound(); }

            return orders;
        }
        */

    }
}
