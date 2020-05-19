using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Infrastructure.Interfaces
{
    public interface ICartRepository
    {
        public Task Add(Cart cart);
        public Task Add(CartItem cartItem);
        public Task Update(CartItem cartItem);
        public Task Delete(CartItem cartItem);
        public Task Delete(Cart cart);
        public Cart Where(Expression<Func<Cart, bool>> expression);
    }

}