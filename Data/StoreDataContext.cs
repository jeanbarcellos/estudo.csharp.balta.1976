using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=balta_1976;Username=postgres;Password=postgres;Port=5433");
        }

    }
}