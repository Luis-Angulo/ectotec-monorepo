using System.Collections.Generic;
using System.Threading.Tasks;
using Ectotec.Modelo;

namespace Ectotec.Persistencia
{
    public interface IContactosRepository
    {
        public Task<IEnumerable<Ciudad>> GetSugerenciasCiudades(string terminoBusqueda, int maxResultados);

        public Task AddContacto(Contacto contacto);

        public Task<Ciudad> GetCiudad(int ciudadId);
    }
}