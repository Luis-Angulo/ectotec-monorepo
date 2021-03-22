using System.Collections.Generic;
using System.Threading.Tasks;
using Ectotec.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ectotec.Persistence
{
    public sealed class CitiesRepository : ICitiesRepository
    {
        private readonly EctotecContext _context;
        public CitiesRepository(EctotecContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCities(string searchTerm, int maxResults) =>
            await _context.Cities
            .Where(c => 
            c.CityName.ToLower().Contains(searchTerm) ||
            c.StateName.ToLower().Contains(searchTerm))
            .OrderBy(c => c.CityName)
            .Take(maxResults)
            .ToListAsync();
        public async Task<City> GetCity(int cityId) =>
            await _context.Cities.FindAsync(cityId);
    }
}