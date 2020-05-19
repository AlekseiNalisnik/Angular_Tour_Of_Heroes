using System.Collections.Generic;
using Shop.API.Infrastructure.Models;

namespace Shop.API.Infrastructure.Services
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderId);
        IEnumerable<Order> GetAllOrders();
        Order GetCartByUserId(string userId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        void Save();
    }
}