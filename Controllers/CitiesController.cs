using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ectotec.Model;
using Ectotec.Persistence;
using Microsoft.AspNetCore.Http;

namespace Ectotec.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesRepository _repo;
        public CitiesController(
            ICitiesRepository repo
        )
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<City>> Get(string term = "")
        {
            return await _repo.GetCities(term, 10); ;
        }
    }
}