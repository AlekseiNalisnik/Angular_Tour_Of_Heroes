using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Infrastructure.Entities;

namespace ShopApi.Infrastructure.Contexts.Config
{
  public class RoleConfiguration : IEntityTypeConfiguration<UserRole>
  {
      public static readonly Guid AdminRoleId = Guid.NewGuid();
      public static readonly Guid UserRoleId = Guid.NewGuid();

      public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new UserRole
                {
                    Id = UserRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }

    }
}