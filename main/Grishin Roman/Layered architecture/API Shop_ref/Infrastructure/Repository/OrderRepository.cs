using API_Shop_ref.Infrastructure.Models;
using System;
using System.Linq;

namespace API_Shop_ref.Infrastructure.Repository
{
    public class OrderRepository : IOrederRepository
    {
        private readonly DBContext _context;

        public OrderRepository(DBContext context)
        {
            _context = context;
        }

        public int AddOrder(int cartId,decimal price)
        {
            var carts = new Orders { CartId = cartId, Time = DateTime.Now, Cost = price };
            _context.Orders.Add(carts);
            _context.SaveChanges();
            var NewOrderId = carts.Id;   //??
            return NewOrderId;

        }

        public decimal Calculate(int cartId)
        {
            decimal total = decimal.Zero;

            total = (from CartLine in _context.CartLine

                     where CartLine.CartId == cartId

                     select CartLine.Count * CartLine.Product.Price).Sum();
            return total;
        }


    }
}
