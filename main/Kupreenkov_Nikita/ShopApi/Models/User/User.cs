using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ShopApi.Models.User
{
    public class User : IdentityUser<long>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
    }
    
    public class UserRole : IdentityRole<long>
    {
        public UserRole() : base() { }
        public UserRole(string roleName) : base(roleName) { }
    }
}