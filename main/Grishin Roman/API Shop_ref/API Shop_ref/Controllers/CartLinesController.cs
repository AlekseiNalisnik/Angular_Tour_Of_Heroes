using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Shop_ref.Data;
using API_Shop_ref.Models;

namespace API_Shop_ref.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartLinesController : ControllerBase
    {
        private readonly DBContext _context;

        public CartLinesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/CartLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartLine>>> GetCartLine()
        {
            return await _context.CartLine.ToListAsync();
        }

        // GET: api/CartLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartLine>> GetCartLine(int id)
        {
            var cartLine = await _context.CartLine.FindAsync(id);

            if (cartLine == null)
            {
                return NotFound();
            }

            return cartLine;
        }

        // PUT: api/CartLines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartLine(int id, CartLine cartLine)
        {
            if (id != cartLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartLineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartLines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartLine>> PostCartLine(CartLine cartLine)
        {
            _context.CartLine.Add(cartLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartLine", new { id = cartLine.Id }, cartLine);
        }

        // DELETE: api/CartLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartLine>> DeleteCartLine(int id)
        {
            var cartLine = await _context.CartLine.FindAsync(id);
            if (cartLine == null)
            {
                return NotFound();
            }

            _context.CartLine.Remove(cartLine);
            await _context.SaveChangesAsync();

            return cartLine;
        }

        private bool CartLineExists(int id)
        {
            return _context.CartLine.Any(e => e.Id == id);
        }
    }
}
