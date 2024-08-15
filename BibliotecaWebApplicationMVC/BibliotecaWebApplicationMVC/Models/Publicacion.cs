using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public abstract class Publicacion
    {
        [Key]
        public int PublicacionId { get; set; }

        // Navigation properties
        public ICollection<Ejemplar> Ejemplares { get; set; } = new List<Ejemplar>();
    }
}
