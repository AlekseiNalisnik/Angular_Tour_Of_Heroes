using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Interfaces;

namespace ShopApi.Domain.UseCases.CartAggregate
{
    public class UnauthorizedCartUseCase : AbstractCartUseCase
    {
        public UnauthorizedCartUseCase(ShopDbContext context,
                                       IHttpContextAccessor accessor,
                                       ICartRepository repository)
            : base(context, accessor, repository)
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
            return Repository.Get(c => c.Id == cartId);
        }
    }
}