using System;

/* En un proyecto mas grande seria mejor que el modelo fuese un proyecto separado */
namespace Ectotec.Modelo
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string Ciudad { get; set; }
    }
}
