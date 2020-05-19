using System.ComponentModel.DataAnnotations;

namespace Shop.API.Presentation.ViewModels.AppUser
{
    public class AppUserCreateModel
    {
        [Required(ErrorMessage = "Не указано имя.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Не указан %username%")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Не указана почта.")]
        public string Email { get; set; }
        
        [Required (ErrorMessage = "Не указан пароль")]
        [StringLength(20, ErrorMessage = "Пароль должен быть как минимум {0} и как максимум {1} символов в длинну.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение пароля не сходятся.")]
        public string ConfirmPassword { get; set; }
    }
}