using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Ectotec.Modelo;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;

namespace Ectotec.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contacto> Get()
        {
            _logger.LogInformation("ContactsController.Get");
            // TODO: replace with actual query when persistence is added
            var contactos = new List<Contacto>();
            var contacto1 = new Contacto() { Nombre = "primer contacto", Email = "mail1@gmail.com", Ciudad = "Obregon", Fecha = DateTime.Now, Telefono = "1234" };
            var contacto2 = new Contacto() { Nombre = "segundo contacto", Email = "mail2@gmail.com", Ciudad = "Navojoa", Fecha = DateTime.Now, Telefono = "5678" };
            contactos.Add(contacto1);
            contactos.Add(contacto2);

            return contactos;
        }

        [HttpPost]
        [ProducesResponseType(202)]
        public async Task<ActionResult> Post([FromBody] Contacto contacto)
        {

            Console.WriteLine(contacto);
            _logger.LogInformation("Contacto.Post called");
            // TODO: replace with actual persistence when persistence is added
            var resourceURI = $"http://localhost:5000/api/contactos/{1}";
            return Created(resourceURI, new { Message = "OK" });
        }
    }
}
