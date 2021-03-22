using System.Collections.Generic;
using System.Threading.Tasks;
using Ectotec.Model;
using Microsoft.EntityFrameworkCore;

namespace Ectotec.Persistence
{
    public sealed class ContactsRepository : IContactsRepository
    {
        private readonly EctotecContext _ctx;
        public ContactsRepository(EctotecContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> AddContact(Contact contacto)
        {
            _ctx.Contacts.Attach(contacto);
            return await _ctx.SaveChangesAsync();
        }
        public async Task<IEnumerable<Contact>> GetContacts() =>
            await _ctx.Contacts.ToListAsync();
    }
}