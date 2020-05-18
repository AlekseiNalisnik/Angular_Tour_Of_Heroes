using Microsoft.EntityFrameworkCore;
using API_Shop_ref.Infrastructure.Models;

namespace API_Shop_ref.Infrastructure
{/// <summary>
///  Контекст базы данных - основной класс, 
///  который координирует функциональные возможности Entity Framework для модели данных
/// </summary>
    public class DBContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<CartLine> CartLine { get; set; }     
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }       
    }
}