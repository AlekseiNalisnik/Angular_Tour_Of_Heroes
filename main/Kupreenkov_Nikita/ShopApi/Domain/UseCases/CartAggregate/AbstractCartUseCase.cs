#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Domain.UseCases.CartAggregate
{

    public abstract class AbstractCartUseCase
    {
        protected const string CartSessionKey = "cart";

        protected readonly ShopDbContext Context;
        protected readonly ICartRepository Repository;
        protected readonly IHttpContextAccessor Accessor;

        protected AbstractCartUseCase(ShopDbContext context,
                                      IHttpContextAccessor accessor,
                                      ICartRepository repository)
        {
            Context = context;
            Accessor = accessor;
            Repository = repository;
        }

        public abstract Cart Get();
        protected abstract Task<Cart> CreateCart();

        protected abstract Guid UserId { get; }

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

        protected virtual async Task<CartItem> CreateCartItem(Product product, Cart cart)
        {
            return new CartItem
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                CartId = cart.Id
            };
        }

        protected virtual void UpdateCartItem(CartItem cartItem, long count)
        {
            EntityState state;
            
            cartItem.Count += count;
            
            if (cartItem.Count < 1)
            {
               state = EntityState.Deleted;
            }
            else if (Context.CartItems.Any(c => c.Id == cartItem.Id))
            {
               state = EntityState.Modified;
            }
            else
            {
               state = EntityState.Added;
            }
            
            Context.Entry(cartItem).State = state;
        }

        public async Task Add(Cart cart)
        {
            EntityState state;
            if (Context.Carts.All(c => c.Id != cart.Id))
            {
                cart.UserId = UserId;
                state = EntityState.Modified;
            }
            else
            {
                state = EntityState.Added;
            }
            Context.Entry(cart).State = state;
            await Context.SaveChangesAsync();
        }

        public async Task Add(Product product, long count = 1)
        {
            var (cart, cartItem) = GetCartData(product);

            cart ??= await CreateCart();
            cartItem ??= await CreateCartItem(product, cart);
            
            UpdateCartItem(cartItem, count);

            await Context.SaveChangesAsync();
        }

        public async Task Delete(Cart cart)
        {
            Context.Carts.Remove(cart);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Product product, long count = 1)
        {
            var (_, cartItem) = GetCartData(product);
            
            if (cartItem == null) return;
            UpdateCartItem(cartItem, -count);
            
            await Context.SaveChangesAsync();
        }

    }
}