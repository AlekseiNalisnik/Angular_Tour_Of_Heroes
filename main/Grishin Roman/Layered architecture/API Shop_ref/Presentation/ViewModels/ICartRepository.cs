using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Shop_ref.Models;


namespace API_Shop_ref.Services
{
    public interface ICartRepository
    {
        public void Add(Carts cart);
        public Task Add(Products product, int count = 1);
        public void Delete(Carts cart);
        public Task Delete(Products product, int count = 1);
        public Carts Get(Guid id);
        public IEnumerable<Carts> Get();
        public void Update(Carts cart);

       
    }

}
