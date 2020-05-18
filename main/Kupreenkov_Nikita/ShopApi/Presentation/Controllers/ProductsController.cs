using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Authentication.Cookies;

using ShopApi.Domain.Interfaces;
using ShopApi.Infrastructure.Contexts;
using ShopApi.Infrastructure.Entities.ProductAggregate;

namespace ShopApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ICartUseCase _useCase;

        public ProductsController(ShopDbContext context, 
                                  IDistributedCache cache, 
                                  ICartUseCase useCase)
        {
            _context = context;
            _cache = cache;
            _useCase = useCase;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Product>> Get()
        {
            return await _context.Products.Include("Images").ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Product>> AddToCart([FromQuery] Guid id, 
                                                           [FromQuery] long count = 1)
        {
            var product = await _context.Products.FindAsync(id);
            await _useCase.Add(product, count);
            return Ok(product);
        }

        [HttpDelete("[action]")]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [AllowAnonymous]
        public async 
        Task<ActionResult<Product>> 
        DeleteFromCart([FromQuery] Guid id,
                       [FromQuery] long count = 1)
        {
            var product = await _context.Products.FindAsync(id);
            await _useCase.Delete(product, count);
            return Ok(product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> Put(Guid id, Product product)
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
        [Authorize(Roles="Admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Product>> Post([FromForm] Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(Guid id) =>
            _context.Products.Any(e => e.Id == id);
    }
}
