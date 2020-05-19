using System;
using System.Drawing.Imaging;
using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Infrastructure.Contexts.Config
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        private const string BearImgPath = "bear.jpeg";
        private const string DuckImgPath = "duck.jpeg";
        private const string HiDuckImgPath = "hi_duck.jpeg";
        private const string InjureImgPath = "injure.jpeg";
        private const string PzDuckImgPath = "pzduck.jpeg";
        private const string ImagesPath = "ProductImages";

        private readonly IWebHostEnvironment _environment;
        public ProductImageConfiguration(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image i)
        {
            var ms = new MemoryStream();
            i.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] ba)
        {
            return System.Drawing.Image.FromStream(new MemoryStream(ba));
        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.BearId,
                ImagePath = Path.Combine(_environment.WebRootPath, ImagesPath, BearImgPath)
            });
            builder.HasData(new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.BearId,
                ImagePath = Path.Combine(_environment.WebRootPath, ImagesPath, DuckImgPath)
            });
            builder.HasData(new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.GammyBearId,
                ImagePath = Path.Combine(_environment.WebRootPath, ImagesPath, HiDuckImgPath)
            });
            builder.HasData(new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.GammyBearId,
                ImagePath = Path.Combine(_environment.WebRootPath, ImagesPath, InjureImgPath)
,           });
            builder.HasData(new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.GammyBearId,
                ImagePath = Path.Combine(_environment.WebRootPath, ImagesPath, PzDuckImgPath)
,           });
        }
    }
}
