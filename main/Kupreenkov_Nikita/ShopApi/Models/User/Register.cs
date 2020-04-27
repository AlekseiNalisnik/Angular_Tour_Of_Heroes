using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models.User
{
    public class Register
    {
        [Required]
        public string Email { get; set; }
         
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}