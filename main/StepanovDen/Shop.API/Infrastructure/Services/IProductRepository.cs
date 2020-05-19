using System.Collections.Generic;
using Shop.API.Infrastructure.Models;

namespace Shop.API.Infrastructure.Services
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