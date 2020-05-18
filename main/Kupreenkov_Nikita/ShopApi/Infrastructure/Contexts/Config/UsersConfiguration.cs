using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApi.Infrastructure.Models;

namespace ShopApi.Infrastructure.Config
{
 public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public static readonly Guid AdminId = Guid.NewGuid();
        public static readonly Guid UserId = Guid.NewGuid();

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User
            {
                Id = AdminId,
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

            var user = new User
            {
                Id = UserId,
                UserName = "standartuser",
                NormalizedUserName = "STANDARTUSER",
                FirstName = "Standart",
                LastName = "User",
                Email = "User@User.com",
                NormalizedEmail = "USER@USER.COM",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(2000,1,30),
                SecurityStamp = new Guid().ToString("D"),
            };
            
            admin.PasswordHash = PassGenerate(admin);
            user.PasswordHash = PassGenerate(user);

            builder.HasData(admin);
            builder.HasData(user);
        }

        public string PassGenerate(User user)
        {
            var passHash = new PasswordHasher<User>();
            return passHash.HashPassword(user, "1234");
        }
    }
}