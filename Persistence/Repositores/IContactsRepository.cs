using System.Collections.Generic;
using System.Threading.Tasks;
using Ectotec.Model;

namespace Ectotec.Persistence
{
    public interface IContactsRepository
    {
        public Task<IEnumerable<Contact>> GetContacts();
        public Task<int> AddContact(Contact contact);
    }
}
