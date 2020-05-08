using System;
using System.Linq;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;
using ShopApi.Data;
using ShopApi.Models.User;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;
        public AccountController(ShopDbContext context,
                                 IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        private async Task MapCart()
        {
            var unAuthCart = JsonConvert.DeserializeObject<Dictionary<Guid, long>>(
                 HttpContext.Session.GetString("cart") ?? "{}");
            var pc = new ProductsController(_context, _cache);
            pc.ControllerContext = ControllerContext;
            
            foreach (var (key, value) in unAuthCart)
            {
                await pc.AddToCart(key, value);
            }
        }
        
        private IEnumerable<Claim> GenerateUserClaims(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userName);
            var userRoles = from iur in _context.UserRoles
                where iur.UserId == user.Id
                from ur in _context.Roles 
                where ur.Id == iur.RoleId
                select ur;
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
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
                new AuthenticationProperties()).ContinueWith(t => MapCart(),
                        TaskContinuationOptions.ExecuteSynchronously);
        }
        
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Login([FromForm]Login login)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
                if (user != null)
                {
                    await Authenticate(GenerateUserClaims(login.Email));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return CreatedAtAction("Login", login);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm]Register register)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == register.Email);
                if (user == null)
                {
                    _context.Users.Add(new User
                    {
                        Email = register.Email,
                        PasswordHash = register.Password
                    });
                    
                    await Authenticate(GenerateUserClaims(register.Email));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "User already exists.");
            }
            return CreatedAtAction("Register", register);
        }
 
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}