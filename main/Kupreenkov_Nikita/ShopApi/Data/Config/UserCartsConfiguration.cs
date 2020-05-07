using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Models;

namespace ShopApi.Data.Config
{
    public class UserCartsConfiguration : IEntityTypeConfiguration<Cart>
    {
        public static readonly Guid StdUserCartId = Guid.NewGuid();
        
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasData(new Cart
            { 
                Id = StdUserCartId,
                UserId = UsersConfiguration.UserId,
                Cost = 300
            });
        }
    }
}