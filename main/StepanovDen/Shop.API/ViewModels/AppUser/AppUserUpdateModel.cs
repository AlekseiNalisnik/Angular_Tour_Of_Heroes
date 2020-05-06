using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Shop.API.ViewModels.AppUser
{
    public class AppUserUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Отчество
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}