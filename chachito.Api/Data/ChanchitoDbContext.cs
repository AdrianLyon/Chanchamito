using helperLibrary;
using Microsoft.EntityFrameworkCore;

namespace chachito.Api.Data
{
    public class ChanchitoDbContext : DbContext
    {
        public ChanchitoDbContext(DbContextOptions<ChanchitoDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}