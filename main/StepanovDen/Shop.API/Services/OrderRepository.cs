using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.API.Data;
using Shop.API.Models;

namespace Shop.API.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataDbContext _dataContext;

        public OrderRepository(AppDataDbContext dataContext)
        {
            _dataContext = dataContext ??
                throw new ArgumentNullException(nameof(dataContext));
        }

        public Order GetOrder(int orderId)
        {
            return _dataContext.Orders
                .FirstOrDefault(o => o.Id == orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            // Получаю все заказы определённого пользователя.
            return _dataContext.Orders;

        }

        public Order GetCartByUserId(string userId)
        {
            var cartStatus = Order.SHOPPINGCART.ToString();
            return GetAllOrders()
                .Where(o => o.AppUserId == userId)
                .FirstOrDefault(o => o.Status == cartStatus);
        }

        public void AddOrder(Order order)
        {
            _dataContext.Orders.Add(order);
        }

        // Относится только к активному заказу (ShoppingCart).
        // Вероятно, потребуется разбить на несколько маленьких методов.
        public void UpdateOrder(Order order)
        {
            _dataContext.Orders.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            _dataContext.Orders.Remove(order);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}