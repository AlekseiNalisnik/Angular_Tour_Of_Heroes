using System.Threading.Tasks;
using Shop.API.Infrastructure.Models;

namespace Shop.API.Infrastructure.Services
{
    public interface IItemRepository
    {
        OrderProduct GetItem(int cartId, int productId);
        Task AddItem(OrderProduct item);
        void UpdateItem(OrderProduct item);
        void DeleteItem(int cartId, int productId);
        Task Save();
    }
}