using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ectotec.Modelo {
    public class Ciudad {
        public int CiudadId { get; set; }
        [Required]
        public string NombreCiudad { get; set; }
        [Required]
        public string NombreEstado { get; set; }
        public IEnumerable<Contacto> Contactos { get; set; }
    }
}