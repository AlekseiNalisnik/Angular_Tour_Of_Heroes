using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [Route("api/Users/{userid}/[controller]")]
    [ApiController]
    public class UserCartsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public UserCartsController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: api/Users/{userid}/UserCarts
        [HttpGet]
        public async Task<IEnumerable<UserCart>> GetUserCart(int userid)
        {
            // return await _context.UserCarts.ToListAsync();
            return await (from usercart in _context.UserCarts
                        join user in _context.Users on usercart.UserId equals userid
                        select usercart).ToListAsync();
        }

        // GET: api/Users/{userid}/UserCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCart>> GetUserCart(long id)
        {
            var userCart = await _context.UserCarts.FindAsync(id);

            if (userCart == null)
            {
                return NotFound();
            }

            return userCart;
        }

        // PUT: api/Users/{userid}/UserCarts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCart(long id, UserCart userCart)
        {
            if (id != userCart.Id) { return BadRequest(); }

            _context.Entry(userCart).State = EntityState.Modified;

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

        // POST: api/Users/{userid}/UserCarts
        [HttpPost]
        public async Task<ActionResult<UserCart>> PostUserCart([FromForm]UserCart userCart)
        {
            _context.UserCarts.Add(userCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCart", new { id = userCart.Id }, userCart);
        }

        // DELETE: api/Users/{userid}/UserCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCart>> DeleteUserCart(long id)
        {
            var userCart = await _context.UserCarts.FindAsync(id);
            if (userCart == null)
            {
                return NotFound();
            }

            _context.UserCarts.Remove(userCart);
            await _context.SaveChangesAsync();

            return userCart;
        }

        private bool UserCartExists(long id)
        {
            return _context.UserCarts.Any(e => e.Id == id);
        }
    }
}
