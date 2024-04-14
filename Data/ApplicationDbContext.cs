using Microsoft.EntityFrameworkCore;
using TobaccoWebShop.Models;

namespace TobaccoWebShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Black Devil",
                    Description = "This product will kill you",
                    Price = 4.2M,
                    Category = Enums.CategoryEnum.Cigarettes,
                },
                new Product
                {
                    Id = 2,
                    Name = "Davidoff Winston Churchill",
                    Description = "This cigar is FIRE!",
                    Price = 50.6M,
                    Category = Enums.CategoryEnum.Cigars,
                });
        }
    }
}
