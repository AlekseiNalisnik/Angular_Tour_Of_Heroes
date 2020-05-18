using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Infrastructure.Interfaces
{
    public interface ICartRepository
    {
        public Task Add(Cart cart);
        public Task Add(Product product, long count = 1);
        public Task Delete(Cart cart);
        public Task Update(Cart cart);
        public Task Delete(Product product, long count = 1);
        public Cart Get();
        public Cart Get(Expression<Func<Cart, bool>> expression);
    }

}