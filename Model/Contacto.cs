using System.ComponentModel.DataAnnotations;
using System;

/* En un proyecto mas grande seria mejor que el modelo fuese un proyecto separado */
namespace Ectotec.Modelo
{
    public class Contacto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public Ciudad Ciudad { get; set; }
    }
}
