using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using ShopApi.Domain.Interfaces;
using ShopApi.Domain.UseCases.CartAggregate;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities;

namespace ShopApi.Domain.Services
{
    public class CartMapper
    {
        private readonly ICartUseCase _anyUseCase;
        private readonly ShopDbContext _context;
        
        public CartMapper(CartUseCaseFactory factory, 
                          AuthorizedCartUseCase authUseCase,
                          ShopDbContext context)
        {
            _anyUseCase = factory.Get();
            _context = context;
        }

        public async Task MapTo(User user)
        {
            var sourceCart = _anyUseCase.Get();
            sourceCart.UserId = user.Id;
            
            var destCart = _context.Carts.Where(c => c.UserId == sourceCart.UserId && c.OrderId == null)
                                         .Include("CartItems")
                                         .FirstOrDefault();
            foreach (var item in sourceCart.CartItems)
            {
                var existedItem = destCart.CartItems.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existedItem == null)
                {
                    item.CartId = destCart.Id;
                    _context.CartItems.Update(item);
                }
                else
                {
                    existedItem.Count += item.Count;
                }
            }
            _context.Carts.Remove(sourceCart);
            await _context.SaveChangesAsync();
        }

    }
}
