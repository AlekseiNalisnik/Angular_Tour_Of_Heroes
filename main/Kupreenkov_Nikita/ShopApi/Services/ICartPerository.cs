using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Models;
using ShopApi.Models.Product;

namespace ShopApi.Services
{
    public interface ICartRepository
    {
        public Task Add(Cart cart);
        public Task Add(Product product, long count = 1);
        public Task Delete(Cart cart);
        public Task Delete(Product product, long count = 1);
        public Cart Get();
    }

}