using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Infrastructure.Repositories.CartAggregate
{
   
    public abstract class DbCartRepository : ICartRepository
    {
        private readonly ShopDbContext _context;

        protected DbCartRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task Add(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public Task Delete(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task Add(Product product, long count = 1)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Cart cart)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Product product, long count = 1)
        {
            throw new System.NotImplementedException();
        }

        public Cart Get()
        {
            throw new System.NotImplementedException();
        }

        public Cart Get(Expression<Func<Cart, bool>> expression)
        {
            return _context.Carts.Where(expression)
                                 .Include("CartItems")
                                 .Include("CartItems.Product")
                                 .FirstOrDefault();
        }
    }

}