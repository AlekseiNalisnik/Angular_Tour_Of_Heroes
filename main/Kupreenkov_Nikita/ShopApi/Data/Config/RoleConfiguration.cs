using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApi.Data.Config
{
  public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<long>>
    {
        private enum RolesId : long
        {
            AdminId = 1,
            UserId
        }
        
        public void Configure(EntityTypeBuilder<IdentityRole<long>> builder)
        {
            builder.HasData(
                new IdentityRole<long>
                {
                    Id = (long)RolesId.AdminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<long>
                {
                    Id = (long)RolesId.UserId,
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }

    }
}