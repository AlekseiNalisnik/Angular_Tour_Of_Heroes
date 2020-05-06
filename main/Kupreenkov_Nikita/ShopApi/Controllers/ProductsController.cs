using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

using ShopApi.Data;
using ShopApi.Models.Product;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public ProductsController(ShopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var shopItem = await _context.Products.FindAsync(id);
            if (shopItem == null) { return NotFound(); }
            return shopItem;
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id) { return BadRequest(); }

            _context.Entry(product).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id)) { return NotFound(); }
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<Product>> PostProduct([FromForm]Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var shopItem = await _context.Products.FindAsync(id);
            if (shopItem == null) {  return NotFound(); }

            _context.Products.Remove(shopItem);
            await _context.SaveChangesAsync();

            return shopItem;
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
