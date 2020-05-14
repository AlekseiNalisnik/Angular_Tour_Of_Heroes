using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.API.Models;

namespace Shop.API.Services
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