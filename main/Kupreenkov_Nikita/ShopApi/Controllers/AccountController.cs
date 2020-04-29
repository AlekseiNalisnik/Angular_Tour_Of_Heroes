using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using ShopApi.Data;
using ShopApi.Models.User;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ShopDbContext _context;
        
        public AccountController(ShopDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm]Login login)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
                if (user != null)
                {
                    await Authenticate(login.Email);
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
                    user = new User { Email = register.Email, PasswordHash = register.Password };
                    
                    await new UsersController(_context).PostUser(user);
                    await Authenticate(register.Email);
 
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
 
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, 
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id), 
                new AuthenticationProperties());
        }

    }
}