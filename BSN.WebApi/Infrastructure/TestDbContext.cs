using BSN.WebApi.Domain;
using BSN.WebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BSN.WebApi.Infrastructure
{
    public class TestDbContext : DbContext, IDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BSNTestDb;Username=postgres;Password=123");
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
