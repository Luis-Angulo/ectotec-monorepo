using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ectotec.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Ectotec.Persistencia
{
    public class EctotecContext : DbContext
    {
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        public EctotecContext(DbContextOptions<EctotecContext> o) : base(o)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}