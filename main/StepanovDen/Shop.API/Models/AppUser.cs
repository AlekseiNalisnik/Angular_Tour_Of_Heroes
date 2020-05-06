using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace Shop.API.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Отчество
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public bool IsAdmin { get; set; }
        // Помимо этого у пользователя д.б.: Id, Email, PhoneNumber.
    }
}