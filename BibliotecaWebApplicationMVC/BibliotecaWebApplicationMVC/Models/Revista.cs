using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class Revista : Publicacion
    {
        
        public Guid RevistaId { get; set; }
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public Revista()
        {
            this.RevistaId = Guid.NewGuid();
        }
        // Navigation properties
    }
}
