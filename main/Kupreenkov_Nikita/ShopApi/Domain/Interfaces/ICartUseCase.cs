using System.Threading.Tasks;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Domain.Interfaces
{
    public interface ICartUseCase
    {
        public Task Add(Cart cart);
        public Task Add(Product product, long count = 1);
        public Task Delete(Cart cart);
        public Task Delete(Product product, long count = 1);
        public Cart Get();
    }

}