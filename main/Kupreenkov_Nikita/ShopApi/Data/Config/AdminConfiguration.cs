using System;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopApi.Models.User;

namespace ShopApi.Data.Config
{
 public class AdminConfiguration : IEntityTypeConfiguration<User>
    {
        private const long adminId = 1;
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User
            {
                Id = adminId,
                UserName = "masteradmin",
                NormalizedUserName = "MASTERADMIN",
                FirstName = "Master",
                LastName = "Admin",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(2000,1,30),
                SecurityStamp = new Guid().ToString("D"),
            };
            admin.PasswordHash = PassGenerate(admin);
            builder.HasData(admin);
        }

        public string PassGenerate(User user)
        {
            var passHash = new PasswordHasher<User>();
            return passHash.HashPassword(user, "admin");
        }
    }
}