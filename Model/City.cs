using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ectotec.Model
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string StateName { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}