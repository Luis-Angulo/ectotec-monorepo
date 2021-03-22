using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ectotec.Model;
using Microsoft.EntityFrameworkCore;

namespace Ectotec.Persistence
{
    public class EctotecContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> Cities { get; set; }

        public EctotecContext(DbContextOptions<EctotecContext> o) : base(o)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}