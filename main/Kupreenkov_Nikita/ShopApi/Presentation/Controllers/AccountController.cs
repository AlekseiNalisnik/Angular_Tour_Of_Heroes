using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Interfaces;
using ShopApi.Domain.Services;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Services;

namespace ShopApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly ICartUseCase _useCase;

        public AccountController(ShopDbContext context, 
                                 CartUseCaseFactory factory)
        {
            _context = context;
            _useCase = factory.Get();
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
                new Claim(ClaimTypes.Sid, _useCase.Get().Id.ToString(), nameof(Cart)),
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
                                               [FromServices] CartMapper mapper)
        {
            if (!ModelState.IsValid) return CreatedAtAction("Login", login);
            
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user != null)
            {
                await Authenticate(GenerateUserClaims(user));
                await mapper.MapTo(user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Incorrect login or password.");
            return CreatedAtAction("Login", login);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] Register register, 
                                                  [FromServices] CartMapper mapper)
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
                await mapper.MapTo(userEntry.Entity);
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