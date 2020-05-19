using System.ComponentModel.DataAnnotations;

namespace Shop.API.Presentation.ViewModels.AppUser
{
    public class AppUserLoginModel
    {
        [Required(ErrorMessage = "Адрес электронной почты должен быть указан.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Пароль должен быть указан")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}