using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Shop.API.Models;
using Shop.API.ViewModels.AppUser;
using Shop.API.Profiles;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper,
            IConfiguration configuration)
        {
            _signInManager = signInManager ??
                throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AppUserLoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (user == null) return NotFound();

            // Из соображений безопасности следует выйти, чтобы потом войти вновь.
            // await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(
                // Вероятно, ошибка кроется именно тут. Я нашёл пользователя только для того, чтобы получить его UserName.
                // UserName необходим для входа в систему.
                userName: user.UserName, 
                password: model.Password, 
                isPersistent: false, 
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Подумать над содержательным выводом ошибки.
                return Ok(); 
            }
            return BadRequest(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AppUserCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            // if (!result.Succeeded) 
            // {
            //     foreach (var error in result.Errors)
            //     {
            //         ModelState.TryAddModelError(error.Code, error.Description);
            //     }
 
            //     return BadRequest(model);
            // }
            
            // await _userManager.AddToRoleAsync(user, "Visitor");

            return Ok();
        }

        #region Helpers


        #endregion
    }
}