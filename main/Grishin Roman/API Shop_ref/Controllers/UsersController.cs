using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Shop_ref.Data;
using API_Shop_ref.Models;

namespace API_Shop_ref.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {   /// <summary>
        ///  GET: api/users [Просмотр пользователей]
        ///  GET: api/users/{id} [Просмотр конкретного пользователя id]
        ///  PUT: api/users/{id} [Изменение информации о пользователе id]
        ///  DELETE: api/users/{id} [Удаление пользователя из базы id]
        ///  POST: api/users [Добавление пользователя в базу]
        /// ДОБАВИТЬ: " ? "
        /// </summary>
        private readonly DBContext _context;

        public UsersController(DBContext context)
        {
            _context = context;
        }
        // GET: api/users [Просмотр пользователей]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers() => 
            await _context.Users.ToListAsync();
        
        // GET: api/users/{id} [Просмотр конкретного пользователя id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) { 
                return NotFound();
            }
            return user;
        }

        // PUT: api/users/{id} [Изменение информации о пользователе id]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.Id) { return BadRequest(); }

            _context.Entry(user).State = EntityState.Modified;

            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id)) { 
                    return NotFound(); 
                }
                throw;
            }
            return NoContent();
        }

        // POST: api/users [Добавление пользователя в базу]
        [HttpPost]
        public async Task<ActionResult<Users>> AddUser([FromBody] Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("AddUser", new { id = user.Id }, user);
        }

        // DELETE: api/users/{id} [Удаление пользователя из базы id]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) { return NotFound(); }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        // проверка наличия пользователя в базе
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
}