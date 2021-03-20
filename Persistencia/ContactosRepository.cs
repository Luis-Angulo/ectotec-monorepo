using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ectotec.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Ectotec.Persistencia
{
    public class ContactosRepository : IContactosRepository
    {
        /* En una app real con muchas entidades, cada entidad de negocio de primera clase deberia ir en su propio repository */
        private readonly EctotecContext _ctx;
        public ContactosRepository(EctotecContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Ciudad>> GetSugerenciasCiudades(string terminoBusqueda, int maxResultados) =>
            await _ctx.Ciudades
            .Where(c => c.NombreCiudad.Contains(terminoBusqueda))
            .Take(maxResultados)
            .ToListAsync();

        public async Task AddContacto(Contacto contacto) =>
            await _ctx.Contactos.AddAsync(contacto);
    }
}