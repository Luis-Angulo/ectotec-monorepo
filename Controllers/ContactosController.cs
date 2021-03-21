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
    public class ContactosController : ControllerBase
    {
        private readonly ILogger<ContactosController> _logger;
        private readonly IContactosRepository _repo;

        public ContactosController(
            IContactosRepository repo,
            ILogger<ContactosController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contacto> Get()
        {
            _logger.LogInformation("ContactsController.Get");
            // TODO: replace with actual query when persistence is added
            var contactos = new List<Contacto>();
            var contacto1 = new Contacto()
            {
                Nombre = "primer contacto",
                Email = "mail1@gmail.com",
                Ciudad = new Ciudad() { NombreCiudad = "Cd. Obregón", NombreEstado = "Sonora" },
                Fecha = DateTime.Now,
                Telefono = "1234"
            };
            var contacto2 = new Contacto()
            {
                Nombre = "segundo contacto",
                Email = "mail2@gmail.com",
                Ciudad = new Ciudad() { NombreCiudad = "Monterrey", NombreEstado = "Nuevo León" },
                Fecha = DateTime.Now,
                Telefono = "5678"
            };
            contactos.Add(contacto1);
            contactos.Add(contacto2);

            return contactos;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] Contacto contacto)
        {
            // TODO: clean up after test of what happens when you build obj graph by hand
            contacto.CiudadId = contacto.Ciudad.CiudadId;
            contacto.Ciudad = await _repo.GetCiudad(contacto.Ciudad.CiudadId);
            await _repo.AddContacto(contacto);
            var uriRecurso = $"http://localhost:5000/api/v1/contactos/{contacto.ContactoId}";
            return Created(uriRecurso, contacto);
        }

    }
}
