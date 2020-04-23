using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore; // подключаем библиотеку

namespace API_v1.Models
{/// <summary>
///  Контекст базы данных - основной класс, 
///  который координирует функциональные возможности Entity Framework для модели данных
/// </summary>
    public class TodoContext : DbContext
    {
        public DbSet<Items> Items { get; set; }
        public TodoContext() { } //
        public TodoContext(DbContextOptions<TodoContext>options) : base(options) { }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);
        }                   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ShopDB;Username=postgres;Password=1");
            base.OnConfiguring(optionsBuilder);
        }
    }
}