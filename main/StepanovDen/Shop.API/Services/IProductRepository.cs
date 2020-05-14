using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shop.API.Data;
using Shop.API.Models;

namespace Shop.API.Services
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
    }
}