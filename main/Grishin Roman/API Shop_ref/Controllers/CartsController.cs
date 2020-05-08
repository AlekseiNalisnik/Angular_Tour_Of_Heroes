using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Shop_ref.Data;
using API_Shop_ref.Models;

namespace API_Shop_ref.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    { /// <summary>
      ///  POST: api/carts [Добавление корзины в базу]
      ///  PUT: api/carts/{id} [Изменение корзины в базе]
      ///  DELETE: api/carts/{id} [Удаление карзины] 
      /// ДОБАВИТЬ: " Просмотр корзины пользователя, просмотр товара в корзине "
      /// </summary>

        private readonly DBContext _context;

        public CartsController(DBContext context)
        {
            _context = context;
        }

        // POST: api/carts [Добавление корзины в базу]
        [HttpPost]
        public async Task<ActionResult<Carts>> AddCart([FromBody]Carts cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddCart", new { id = cart.Id }, cart);
        }

        // PUT: api/carts/{id} [Изменение корзины в базе]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Carts cart)
        {
            if (id != cart.Id) { return BadRequest(); }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id)) { return NotFound(); }
                else { throw; }
            }

            return NoContent();
        }

        // DELETE: api/carts/{id} [Удаление карзины]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carts>> DeleteUserCart(int id)
        {
            var Cart = await _context.Carts.FindAsync(id);
            if (Cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(Cart);
            await _context.SaveChangesAsync();

            return Cart;
        }

        // проверка наличия карзины в базе
        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}