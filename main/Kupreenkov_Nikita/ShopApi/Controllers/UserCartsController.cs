using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/[controller]/{userid}")]
    [ApiController]
    public class UserCartsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public UserCartsController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Cart>> GetUserCart(Guid userid)
        {
            return await (from uc in _context.Carts
                        where uc.UserId == userid
                        select uc).Include("CartItems")
                                  .Include("Order")
                                  .Include("User")
                                  .Include("CartItems.Product").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Cart>> GetUserCart(Guid userid, Guid id)
        {
            return GetUserCart(userid).Result.Where(uc => uc.Id == id);
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
