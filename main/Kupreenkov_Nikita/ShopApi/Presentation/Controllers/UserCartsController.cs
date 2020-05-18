using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities;
using ShopApi.Infrastructure.Entities.CartAggregate;
using ShopApi.Infrastructure.Models;

namespace ShopApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;

        public UserCartsController(ShopDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _context.Carts.Include("CartItems")
                                       .Include("Order")
                                       .Include("User")
                                       .Include("CartItems.Product").ToListAsync();
        }

        [HttpGet("{userId}")]
        [Authorize(Roles="Admin")]
        public async Task<IEnumerable<Cart>> GetUserCart(Guid userId)
        {
            return await _context.Carts.Where(uc => uc.UserId == userId)
                                       .Include("CartItems")
                                       .Include("Order")
                                       .Include("User")
                                       .Include("CartItems.Product")
                                       .ToListAsync();
        }

        [HttpGet("{userId}/{id}")]
        public IEnumerable<Cart> GetUserCart(Guid userId, Guid id)
        {
            return GetUserCart(userId).Result.Where(uc => uc.Id == id);
        }
        
        [HttpGet]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<Cart>> GetUserCart()
        {
            Guid id = Guid.Parse(HttpContext.User.Claims
                .First(c => c.Type == ClaimTypes.Sid).Value);
            return await GetUserCart(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCart(Guid id, Cart cart)
        {
            if (id != cart.Id) { return BadRequest(); }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCartExists(id)) { return NotFound(); }
                else { throw; }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> PostUserCart([FromForm]Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCart", new { id = cart.Id }, cart);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DeleteUserCart(Guid id)
        {
            var userCart = await _context.Carts.FindAsync(id);
            if (userCart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(userCart);
            await _context.SaveChangesAsync();

            return userCart;
        }

        private bool UserCartExists(Guid id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
