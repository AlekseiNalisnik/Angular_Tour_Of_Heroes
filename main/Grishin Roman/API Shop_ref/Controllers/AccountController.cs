using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API_Shop_ref.Models;
using API_Shop_ref.ViewModels;

namespace API_Shop_ref.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {//контроллер для регистрации пользователей
        /// <summary>
        /// POST: api/logout
        /// POST: api/login 
        /// POST: api/register
        /// </summary>
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST: api/logout 
        [HttpPost]
        [Route("logout")]        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
            // или вместо Ok:  RedirectToAction("Home");
        }

        // POST: api/login 
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                // RedirectToAction("Home");
                return Ok();
            }
            return BadRequest(result);
        }

        // POST: api/register 
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            {
                Users user = new Users { Email = model.Email, UserName = model.Email};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Ok();   //RedirectToAction("Home");
                }
                else
                {
                   return BadRequest(ModelState);
                }
                
            }
        }
    }
}
