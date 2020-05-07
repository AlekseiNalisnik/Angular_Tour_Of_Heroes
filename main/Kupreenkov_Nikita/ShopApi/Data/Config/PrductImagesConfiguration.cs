using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models.Product;
using Image = ShopApi.Models.Product.Image;

namespace ShopApi.Data.Config
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<Image>
    {
        private const string RootPath =
            "/home/kupns/Develop/csharp/Angular_Tour_Of_Heroes/main/Kupreenkov_Nikita/ShopApi/Assets";

        private const string BearImgPath = RootPath + "bear.jpeg";
        private const string DuckImgPath = RootPath + "duck.jpeg";
        private const string HiDuckImgPath = RootPath + "hi_duck.jpeg";
        private const string InjureImgPath = RootPath + "injure.jpeg";
        private const string PzDuckImgPath = RootPath + "pzduck.jpeg";

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

        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.BearId,
                ImagePath = BearImgPath
            });
            builder.HasData(new Image
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.BearId,
                ImagePath = DuckImgPath
            });

            builder.HasData(new Image
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.GammyBearId,
                ImagePath = HiDuckImgPath
            });
            builder.HasData(new Image
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.GammyBearId,
                ImagePath = InjureImgPath
            });
            builder.HasData(new Image
            {
                Id = Guid.NewGuid(),
                ProductId = ProductConfiguration.GammyBearId,
                ImagePath = PzDuckImgPath
            });
        }
    }
}
