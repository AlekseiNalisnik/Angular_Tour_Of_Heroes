using System;
using System.Linq;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using ShopApi.Data;
using ShopApi.Models;
using ShopApi.Models.User;
using ShopApi.Services;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly ICartRepository _repository;

        public AccountController(ShopDbContext context, 
                                 ICartRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        private IEnumerable<Claim> GenerateUserClaims(User user)
        {
            var userRoles = from iur in _context.UserRoles
                where iur.UserId == user.Id
                from ur in _context.Roles 
                where ur.Id == iur.RoleId
                select ur;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString(), nameof(Guid)),
                new Claim(ClaimTypes.Sid, _repository.Get().Id.ToString(), nameof(Cart)),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString(CultureInfo.InvariantCulture)),
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return claims;
        }

        private async Task Authenticate(IEnumerable<Claim> claims)
        {
            var id = new ClaimsIdentity(claims, 
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id), 
                new AuthenticationProperties());
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Login([FromForm] Login login, 
                                               [FromServices] RepositoryMapper mapper)
        {
            if (!ModelState.IsValid) return CreatedAtAction("Login", login);
            
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user != null)
            {
                await Authenticate(GenerateUserClaims(user));
                // await mapper.Map();
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Incorrect login or password.");
            return CreatedAtAction("Login", login);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]Register register)
        {
            if (!ModelState.IsValid) return CreatedAtAction("Register", register);
            
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == register.Email);
            if (user == null)
            {
                var userEntry = await _context.Users.AddAsync(new User
                {
                    Email = register.Email,
                    PasswordHash = register.Password
                });
                
                await Authenticate(GenerateUserClaims(userEntry.Entity));
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "User already exists.");
            return CreatedAtAction("Register", register);
        }
 
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}