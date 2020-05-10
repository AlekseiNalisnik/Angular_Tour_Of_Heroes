using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Services
{
    public class AuthorizedDbCartRepository : AbstractDbCartRepository
    {
        public AuthorizedDbCartRepository(ShopDbContext context,
                                          IHttpContextAccessor accessor)
            : base(context, accessor)
        { }

        protected override Guid UserId =>
            Guid.Parse(Accessor.HttpContext.User.Claims
                .First(c => c.Type == ClaimTypes.Sid).Value);

        protected override async Task<Cart> CreateCart()
        {
            var cart = new Cart { UserId = UserId };
            await Context.Carts.AddAsync(cart);
            return cart;
        }
    }
}