using System.ComponentModel.DataAnnotations;
using System;

namespace Ectotec.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
