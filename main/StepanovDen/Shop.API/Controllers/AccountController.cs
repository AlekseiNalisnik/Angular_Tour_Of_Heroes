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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper,
            IConfiguration configuration,
            ILogger<AccountController> logger)
        {
            _signInManager = signInManager ??
                throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _logger = logger ??
                      throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AppUserLoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                _logger.LogInformation("User is not found.");
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(
                userName: user.UserName,
                password: model.Password,
                isPersistent: model.RememberMe,
                lockoutOnFailure: false);

            if (!result.Succeeded) return BadRequest("Some shit happens here");
            // var identity = new ClaimsIdentity(GetUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            //
            // var principal = new ClaimsPrincipal(identity);
            //
            // _signInManager.PasswordSignInAsync();
            // await HttpContext.SignInAsync(
            //     // Какую схему использую для входа пользователей. В этом случае это Cookie.
            //     CookieAuthenticationDefaults.AuthenticationScheme,
            //     principal,
            //     new AuthenticationProperties { IsPersistent = model.RememberMe }
            // );
            // _logger.LogInformation("{1} {2} logged in", user.FirstName, user.LastName);
            var userToReturn = _mapper.Map<AppUserModel>(user);
            return Ok(userToReturn); 
            
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AppUserCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _mapper.Map<AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(model);
            }
            var userToReturn = _mapper.Map<AppUserModel>(user);
            return Ok(userToReturn);
        }

        #region Helpers

        private IEnumerable<Claim> GetUserClaims(AppUser user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString())
            };
        }
        
        #endregion
    }
}