using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using ShopApi.Infrastructure.Interfaces;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Infrastructure.Repositories.CartAggregate
{
    public class InMemoryCartRepository : ICartRepository
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _accessor;

        public InMemoryCartRepository(IDistributedCache cache,
                                      IHttpContextAccessor accessor)
        {
            _cache = cache;
            _accessor = accessor;
        }

        public Task Update(Guid id, CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Cart Get()
        {
            var cart = JsonConvert.DeserializeObject<Dictionary<Guid, long>>(
                _accessor.HttpContext.Session.GetString("cart") ?? "{}");
            var res = new Cart();
        
            foreach (var (key, value) in cart)
            {
            }

            return res;
        }

        public Cart Get(Expression<Func<Cart, bool>> expression)
        {
            throw new NotImplementedException();
        }

        private Dictionary<Guid, long> GetCartData(Product product)
        {
            return JsonConvert.DeserializeObject<Dictionary<Guid, long>>(
                _accessor.HttpContext.Session.GetString("cart") ?? "{}");
        }

        public async Task Add(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            _accessor.HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        public Task Add(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public async Task Add(Product product, long count = 1)
        {
            var cart = GetCartData(product);
            if (cart.ContainsKey(product.Id))
                cart[product.Id] += count;
            else
                cart.Add(product.Id, count);
            _accessor.HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        public async Task Delete(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task Update(Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Product product, long count = 1)
        {
            var cart = GetCartData(product);
            if (cart.TryGetValue(product.Id, out var _count))
            {
                _count -= count;
                if (_count < 1)
                    cart.Remove(product.Id);
                else
                    cart[product.Id] = _count;
            }
            _accessor.HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

    }
}
