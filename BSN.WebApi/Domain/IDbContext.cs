using BSN.WebApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BSN.WebApi.Domain
{
    public interface IDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Message> Messages { get; set; }

        public int SaveChanges();
    }
}
