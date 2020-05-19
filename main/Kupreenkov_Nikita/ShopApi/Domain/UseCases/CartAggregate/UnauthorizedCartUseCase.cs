using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Services;
using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Domain.UseCases.CartAggregate
{
    public class UnauthorizedCartUseCase : AbstractCartUseCase
    {
        private const string CartSessionKey = "cart";
        public UnauthorizedCartUseCase(ShopDbContext context,
                                       IHttpContextAccessor accessor,
                                       CartRepositoryFactory factory)
            : base(context, accessor, factory)
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
            return Repository.Where(c => c.Id == cartId);
        }
    }
}