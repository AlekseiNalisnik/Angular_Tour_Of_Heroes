using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Shop_ref.Models;
using API_Shop_ref.Controllers;

namespace API_Shop_ref.Data
{/// <summary>
///  Контекст базы данных - основной класс, 
///  который координирует функциональные возможности Entity Framework для модели данных
/// </summary>
    public class DBContext : DbContext
    {
        public DbSet<API_Shop_ref.Models.Products> Products { get; set; }
        public DbSet<API_Shop_ref.Models.Users> Users { get; set; }
        public DbSet<API_Shop_ref.Models.Orders> Orders { get; set; }
        public DbSet<API_Shop_ref.Models.Carts> Carts { get; set; }
        public DbSet<API_Shop_ref.Models.CartLine> CartLine { get; set; }
        public DBContext() { } //
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }       
    }
}