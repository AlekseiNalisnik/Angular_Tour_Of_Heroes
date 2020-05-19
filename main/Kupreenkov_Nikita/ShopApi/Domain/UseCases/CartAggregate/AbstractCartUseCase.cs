#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using ShopApi.Domain.Interfaces;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Services;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Domain.UseCases.CartAggregate
{

    public abstract class AbstractCartUseCase : ICartUseCase
    {

        protected readonly ShopDbContext Context;
        protected readonly ICartRepository Repository;
        protected readonly IHttpContextAccessor Accessor;

        protected AbstractCartUseCase(ShopDbContext context,
                                      IHttpContextAccessor accessor,
                                      CartRepositoryFactory factory)
        {
            Context = context;
            Accessor = accessor;
            Repository = factory.Get();
        }

        protected abstract Guid UserId { get; }
        public abstract Cart Get();
        protected abstract Task<Cart> CreateCart();

        private (Cart?, CartItem?) GetCartData(Product product)
        {
            var cart = Get();
            CartItem? cartItem = null;
            
            if (cart != null)
            {
                cartItem = Context.CartItems.FirstOrDefault(cI =>
                    cI.ProductId == product.Id && cI.CartId == cart.Id); 
            }

            return (cart, cartItem);
        }

        public async Task Add(Product product, long count = 1)
        {
            var (cart, cartItem) = GetCartData(product);

            cart ??= await CreateCart();
            cartItem ??= new CartItem
                 {
                     Id = Guid.NewGuid(),
                     ProductId = product.Id,
                     CartId = cart.Id
                 };
            
            cartItem.Count += count;
            await Repository.Update(cartItem);
        }

        public async Task Delete(Product product, long count = 1)
        {
            var (_, cartItem) = GetCartData(product);
            
            if (cartItem == null) return;
            
            cartItem.Count -= count;
            await Repository.Update(cartItem);
        }

    }
}