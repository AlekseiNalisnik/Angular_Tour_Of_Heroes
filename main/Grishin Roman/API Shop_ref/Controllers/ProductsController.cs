using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API_Shop_ref.Models;
using API_Shop_ref.Data;


namespace API_Shop_ref.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {/// <summary>
     ///  GET: api/products [Просмотр товаров]
     ///  GET: api/products/{id} [Просмотр товара id]
     ///  PUT: api/products/{id} [Изменение товара в базе]
     ///  POST: api/products [Добавление товара в базу]
     ///  DELETE: api/products/{id} [Удаление товара из базы]
     /// ДОБАВИТЬ: "изменять БД может только администратор"
     /// </summary>

        private readonly DBContext _context;
        
        public ProductsController(DBContext context)
        {
            _context = context;
        
        }
        // GET: api/products [Просмотр товаров]
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        // GET: api/products/{id} [Просмотр товара id]
        [HttpGet("{id}")]        
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) { return NotFound(); }

            return product;
        }

        // PUT: api/products/{id} [Изменение товара в базе]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/products [Добавление товара в базу]
        [HttpPost]
        public async Task<ActionResult<Products>> AddProducts([FromBody]Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddProducts", new { id = products.Id }, products);
        }

        // DELETE: api/products/{id} [Удаление товара из базы]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        // проверка наличия товара в базе
        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}