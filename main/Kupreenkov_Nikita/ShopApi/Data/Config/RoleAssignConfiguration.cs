using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopApi.Data.Config
{
     public class UserRolesAssignConfiguration : IEntityTypeConfiguration<IdentityUserRole<long>>
    {
        private const long AdminUserId = 1;
        private const long AdminRoleId = 1;

        public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
        {
            IdentityUserRole<long> iur = new IdentityUserRole<long>
            {
                RoleId = AdminRoleId,
                UserId = AdminUserId
            };

            builder.HasData(iur);
        }
    }
}