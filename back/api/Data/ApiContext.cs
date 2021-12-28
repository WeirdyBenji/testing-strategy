using Microsoft.EntityFrameworkCore;
using TwitterApi.Models;

namespace TwitterApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Twit>().ToTable("Twit");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Twit> Twits { get; set; }
    }
}
