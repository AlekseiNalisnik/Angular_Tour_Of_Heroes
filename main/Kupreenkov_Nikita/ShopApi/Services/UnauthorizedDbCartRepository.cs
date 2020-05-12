using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Services
{
    public class UnauthorizedDbCartRepository : AbstractDbCartRepository
    {
        public UnauthorizedDbCartRepository(ShopDbContext context,
                                            IHttpContextAccessor accessor)
            : base(context, accessor)
        { }

        protected override Guid UserId => Guid.Parse(Accessor.HttpContext.Session.Id);

        protected override async Task<Cart> CreateCart()
        {
            var cartEntry = await Context.Carts.AddAsync(new Cart());
            
            Accessor.HttpContext.Session.SetString(CartSessionKey, cartEntry.Entity.Id.ToString());
            return cartEntry.Entity;
        }
        
        public override Cart Get()
        {
            Guid.TryParse(Accessor.HttpContext.Session.GetString(CartSessionKey), out var cartId);
            return Context.Carts.Where(c => c.Id == cartId)
                                .Include("CartItems")
                                .Include("CartItems.Product")
                                .FirstOrDefault();
        }
    }
}