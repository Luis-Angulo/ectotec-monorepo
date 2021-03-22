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
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _repo;
        public ContactsController(IContactsRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<Contact>> Get()
        {
            return await _repo.GetContacts();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] Contact contact)
        {
            await _repo.AddContact(contact);
            var uri = $"http://localhost:5000/api/v1/contactos/{contact.ContactId}";
            return Created(uri, contact);
        }
    }
}
