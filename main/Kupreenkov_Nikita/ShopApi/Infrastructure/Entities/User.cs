using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ShopApi.Infrastructure.Entities.CartAggregate;

namespace ShopApi.Infrastructure.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        public Cart Cart { get; set; }
    }
    
    public class UserRole : IdentityRole<Guid>
    {
        public UserRole() : base() { }
        public UserRole(string roleName) : base(roleName) { }
    }
}