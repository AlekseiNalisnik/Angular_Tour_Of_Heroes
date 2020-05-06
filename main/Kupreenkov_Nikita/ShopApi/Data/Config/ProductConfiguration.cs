using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopApi.Models.Product;

namespace ShopApi.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
         builder.HasData(new Product
         { 
             Id = 1,
             Name = "Bear",
             Price = 0.0,
             Description = "Holy bear",
             Weight = 1000 
         });
         
         builder.HasData(new Product 
         { 
             Id = 2,
             Name = "GammyBear",
             Price = 10.5,
             Description = "Tasty and cute sugar boys",
             Weight = 10
         });
        }
    }
}