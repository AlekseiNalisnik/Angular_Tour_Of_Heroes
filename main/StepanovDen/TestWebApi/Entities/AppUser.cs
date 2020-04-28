using System;
using Microsoft.AspNetCore.Identity;

namespace TestWebApi.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Отчество
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Sex { get; set; }
    }
}