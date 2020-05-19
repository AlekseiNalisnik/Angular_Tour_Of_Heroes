using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Infrastructure.Repositories.CartAggregate
{
    public class DbCartRepository : ICartRepository
    {
        private readonly ShopDbContext _context;

        public DbCartRepository(ShopDbContext context)
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

        public async Task Update(CartItem cartItem)
        {
            EntityState state;
            if (cartItem.Count < 1)
            {
               state = EntityState.Deleted;
            }
            else if (_context.CartItems.Any(c => c.Id == cartItem.Id))
            {
               state = EntityState.Modified;
            }
            else
            {
               state = EntityState.Added;
            }
            
            _context.Entry(cartItem).State = state;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Cart cart)
        {
            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();
        }
        
        public async Task Delete(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public Cart Where(Expression<Func<Cart, bool>> expression)
        {
            return _context.Carts.Where(expression)
                                 .Include("CartItems")
                                 .Include("CartItems.Product")
                                 .FirstOrDefault();
        }
    }

}