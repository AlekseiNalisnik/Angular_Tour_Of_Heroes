using System;

namespace Shop.API.Presentation.ViewModels.AppUser
{
    public class AppUserModel
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