using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestWebApi.DbContexts;
using TestWebApi.Entities;

namespace TestWebApi.Services
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product GetProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
        bool ProductExists(int productId);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly AppDataDbContext _dataContext;

        public ProductRepository(AppDataDbContext dataContext)
        {
            _dataContext = dataContext ??
                throw new ArgumentNullException(nameof(dataContext));
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            
            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }

        public Product GetProduct(int productId)
        {
            if (productId == 0)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _dataContext.Products
                .Where(p => p.Id == productId).FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dataContext.Products.OrderBy(p => p.Name).ToList();
        }

        public void UpdateProduct(Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }

        public bool ProductExists(int productId)
        {
            return _dataContext.Products.Any(p => p.Id == productId);
        }
    }
}