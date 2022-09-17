using chachito.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace chachito.Api.Infrastructure.Persistence
{
    public class ChanchitoDbContext : DbContext
    {
        public ChanchitoDbContext(DbContextOptions<ChanchitoDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users{get; set;}
        public DbSet<Order> Orders{get; set;}
        public DbSet<OrderDetail> OrderDetails{get; set;}
        public DbSet<Product> Products{get; set;}
        public DbSet<ProductCategory> ProductCategories{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetail");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
        }
    }
}