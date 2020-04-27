using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // подключаем библиотеку
using API_Shop.Models;

namespace API_Shop.Models
{/// <summary>
///  Контекст базы данных - основной класс, 
///  который координирует функциональные возможности Entity Framework для модели данных
/// </summary>
    public class DBContext : DbContext
    {       
        public DbSet<API_Shop.Models.Products> Products { get; set; }
        public DbSet<API_Shop.Models.Users> Users { get; set; }
        public DbSet<API_Shop.Models.Orders> Orders { get; set; }
        public DbSet<API_Shop.Models.Carts> Carts { get; set; }
        public DbSet<API_Shop.Models.CartLine> CartLine { get; set; }
        public DBContext() { } //
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
           
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DBshop;Username=postgres;Password=1");
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}