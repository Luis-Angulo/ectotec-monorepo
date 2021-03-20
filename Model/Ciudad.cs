using System.ComponentModel.DataAnnotations;

namespace Ectotec.Modelo {
    public class Ciudad {
        public int Id { get; set; }
        [Required]
        public string NombreCiudad { get; set; }
        [Required]
        public string NombreEstado { get; set; }
    }
}