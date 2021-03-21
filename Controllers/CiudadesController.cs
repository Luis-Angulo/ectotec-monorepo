using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ectotec.Modelo;
using Ectotec.Persistencia;
using Microsoft.AspNetCore.Http;

namespace Ectotec.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class CiudadesController : ControllerBase
    {
        private readonly ILogger<CiudadesController> _logger;
        private readonly IContactosRepository _repo;
        public CiudadesController(
            IContactosRepository repo,
            ILogger<CiudadesController> logger
        )
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<Ciudad>> Get(string termino = "")
        {
            // TODO: extract 10 max search results to config var (appsettings)
            return await _repo.GetSugerenciasCiudades(termino, 10);;
        }
    }
}