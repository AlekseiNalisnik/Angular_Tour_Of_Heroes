using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            Cart cart = new Cart();
            Accessor.HttpContext.Session.SetString(CartSessionKey, cart.Id.ToString());
            await Context.Carts.AddAsync(cart);
            return cart;
        }
    }
}