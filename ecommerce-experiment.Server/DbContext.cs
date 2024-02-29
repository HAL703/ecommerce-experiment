using Microsoft.EntityFrameworkCore;

namespace ecommerce_experiment.Server
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
   
        public DbSet<Models.User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseNpgsql("Host=localhost;Database=ecommerce;Username=zetademon;Password=2001123");
        //
    }
}
