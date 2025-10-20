using CISOSample.Models;
using Microsoft.EntityFrameworkCore;


namespace CISOSample.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Status)
                .HasConversion<string>();
        }
    }
}
