using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Services;
using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Domain.UseCases.CartAggregate
{
    public class AuthorizedCartUseCase : AbstractCartUseCase
    {
        public AuthorizedCartUseCase(ShopDbContext context,
                                     IHttpContextAccessor accessor,
                                     CartRepositoryFactory factory)
            : base(context, accessor, factory)
        { }

        protected override Guid UserId => Guid.Parse(Accessor.HttpContext.User.Claims
            .First(c => c.Type == ClaimTypes.Sid).Value);
        
        protected override async Task<Cart> CreateCart()
        {
            var cart = new Cart { UserId = UserId };
            await Context.Carts.AddAsync(cart);
            return cart;
        }

        public override Cart Get()
        {
            return Repository.Where(c => c.OrderId == null && c.UserId == UserId);
        }
    }
}