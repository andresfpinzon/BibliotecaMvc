using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class Publicacion
    {
        [Key]
        public Guid PublicacionId { get; set; }

        public Publicacion()
        {
            this.PublicacionId = Guid.NewGuid();
        }

        // Navigation properties
        public ICollection<Ejemplar> Ejemplares { get; set; } = new List<Ejemplar>();
    }
}
