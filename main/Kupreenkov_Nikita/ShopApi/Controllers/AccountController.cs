using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm]Login model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.PasswordHash == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email);
 
                    return Redirect(
                        Url.Link("api", new {  Url = nameof(HomeController), controller = "Home", action = "Index" })
                    );
                }
                ModelState.AddModelError("", "Incorrect login or password.");
            }
            return CreatedAtAction("Login", model);
        }
 
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm]Register model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, PasswordHash = model.Password };
                    
                    await new UsersController(_context).PostUser(user);
                    await Authenticate(model.Email);
 
                    
                    return Redirect(
                        Url.Link("api", new {  Url = nameof(HomeController), controller = "Home", action = "Index" })
                    );

                }
                else
                    ModelState.AddModelError("", "User already exists.");
            }
            return CreatedAtAction("Register", model);
        }
 
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, 
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
 
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(
                Url.Link("DefaultApi", new { Url = nameof(HomeController), controller = "Home", action = "Index" })
            );
        }
    }
}