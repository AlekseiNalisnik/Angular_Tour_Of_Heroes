#nullable enable
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;
using ShopApi.Models.Product;

namespace ShopApi.Services
{

    public abstract class AbstractDbCartRepository : ICartRepository
    {
        protected const string CartSessionKey = "cart";

        protected readonly ShopDbContext Context;
        protected readonly IHttpContextAccessor Accessor;

        protected AbstractDbCartRepository(ShopDbContext context,
                                           IHttpContextAccessor accessor)
        {
            Context = context;
            Accessor = accessor;
        }

        private (Cart?, CartItem?) GetCartData(Product product, Guid userId)
        {
            var cart = Context.Carts.FirstOrDefault(c => c.OrderId == null && c.UserId == userId);
            CartItem? cartItem = null;
            
            if (cart != null)
            {
                cartItem = Context.CartItems.FirstOrDefault(cI =>
                    cI.ProductId == product.Id && cI.CartId == cart.Id); 
            }

            return (cart, cartItem);
        }

        protected abstract Guid UserId { get; }
        protected abstract Task<Cart> CreateCart();

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
            cartItem.Count += count;
            if (cartItem.Count < 1)
            {
                Context.CartItems.Remove(cartItem);
            }
        }

        public async Task Add(Product product, long count = 1)
        {
            var (cart, cartItem) = GetCartData(product, UserId);

            cart ??= await CreateCart();
            cartItem ??= await CreateCartItem(product, cart);
            
            UpdateCartItem(cartItem, count);
            
            Context.Entry(cartItem).State = Context.CartItems.Any(c => c.Id == cartItem.Id)
                ? EntityState.Modified : EntityState.Added;
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Product product, long count = 1)
        {
            var (_, cartItem) = GetCartData(product, UserId);
            
            if (cartItem == null) return;
            UpdateCartItem(cartItem, -count);
            
            await Context.SaveChangesAsync();
        }

        public Cart Get(Guid id)
        {
            return Context.Carts.Find(id);
        }

        public IEnumerable<Cart> Get()
        {
            return Context.Carts.OrderBy(c => c.Cost).ToList();
        }
    
        public void Add(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            Context.Carts.Add(cart);
            Context.SaveChanges();
        }
    
        public void Delete(Cart cart)
        {
        
            Context.Carts.Remove(cart);
            Context.SaveChanges();
        }

        public void Update(Cart cart)
        {
            Context.Carts.Update(cart);
            Context.SaveChanges();
        }
    }
}