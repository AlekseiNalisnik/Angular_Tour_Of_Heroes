using System;
using System.Collections.Generic;
using System.Linq;
using Shop.API.Infrastructure.Data;
using Shop.API.Infrastructure.Models;

namespace Shop.API.Infrastructure.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDataDbContext _dataContext;

        public ProductRepository(AppDataDbContext dataContext)
        {
            _dataContext = dataContext ??
                throw new ArgumentNullException(nameof(dataContext));
        }

        public Product GetProduct(int productId)
        {
            // Проверка на отсутствие товара с этим id в БД.

            return _dataContext.Products
                .Where(p => p.Id == productId).FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dataContext.Products.OrderBy(p => p.Name).ToList();
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

        public void UpdateProduct(Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }
    }
}