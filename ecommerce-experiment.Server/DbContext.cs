using ecommerce_experiment.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_experiment.Server
{
    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql("Host=localhost;Database=ecommerce;Username=zetademon;Password=2001123");
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // sets up auto-generating of userId in Postgres, starting from 50
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .HasIdentityOptions(startValue: 1);
        }
    }
}