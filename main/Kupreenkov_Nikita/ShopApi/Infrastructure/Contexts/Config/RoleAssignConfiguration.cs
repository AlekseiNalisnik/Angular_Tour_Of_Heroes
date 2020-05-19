using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Infrastructure.Contexts.Config;

namespace ShopApi.Infrastructure.Config
{
     public class UserRolesAssignConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var adminIur = new IdentityUserRole<Guid>
            {
                RoleId = RoleConfiguration.AdminRoleId,
                UserId = UsersConfiguration.AdminId
            };

            var userIur = new IdentityUserRole<Guid>
            {
                RoleId = RoleConfiguration.UserRoleId,
                UserId = UsersConfiguration.UserId
            };
            
            builder.HasData(adminIur);
            builder.HasData(userIur);
        }
    }
}