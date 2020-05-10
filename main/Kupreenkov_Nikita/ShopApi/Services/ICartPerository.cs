using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Models;
using ShopApi.Models.Product;

namespace ShopApi.Services
{
    public interface ICartRepository
    {
        public void Add(Cart cart);
        public Task Add(Product product, long count = 1);
        public void Delete(Cart cart);
        public Task Delete(Product product, long count = 1);
        public Cart Get(Guid id);
        public IEnumerable<Cart> Get();
        public void Update(Cart cart);
    }

}