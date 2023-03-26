using AuthPrac.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AuthPrac.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(t => t.Price)
                .HasPrecision(18, 2); 
        }
    }
}
