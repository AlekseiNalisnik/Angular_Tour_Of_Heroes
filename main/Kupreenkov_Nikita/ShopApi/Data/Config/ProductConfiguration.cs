using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopApi.Models.Product;

namespace ShopApi.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public static readonly Guid BearId = Guid.NewGuid();
        public static readonly Guid GammyBearId = Guid.NewGuid();

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.HasData(new Product
            { 
                Id = BearId,
                Name = "Bear",
                Price = 0.0,
                Description = "Holy bear",
                Weight = 1
            });
            
            builder.HasData(new Product 
            { 
                Id = GammyBearId,
                Name = "GammyBear",
                Price = 10.5,
                Description = "Tasty and cute sugar boys",
                Weight = 10
            });
        }
    }
}