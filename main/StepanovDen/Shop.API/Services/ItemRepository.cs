using System.Threading.Tasks;
using Shop.API.Data;
using Shop.API.Models;
using System.Linq;

namespace Shop.API.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDataDbContext _dataContext;

        public ItemRepository(AppDataDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public OrderProduct GetItem(int cartId, int productId)
        {
            return _dataContext.OrderProducts
                .Where(op => op.OrderId == cartId)
                .SingleOrDefault(op => op.ProductId == productId);
        } 

        public async Task AddItem(OrderProduct item)
        {
            await _dataContext.OrderProducts.AddAsync(item);
        }
        
        public void UpdateItem(OrderProduct item)
        {
            _dataContext.OrderProducts.Update(item);
        }

        public void DeleteItem(int cartId, int productId)
        {
            var item = GetItem(cartId, productId);
            _dataContext.OrderProducts.Remove(item);
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}