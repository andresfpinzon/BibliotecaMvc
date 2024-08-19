using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class Estante
    {
        [Key]
        public int EstanteId { get; set; }
        public string CodigoEstante { get; set; }
        public int? EstanteriaId { get; set; }

        // Navigation properties
        public Estanteria Estanteria { get; set; }
        public ICollection<Ejemplar> Ejemplares { get; set; } = new List<Ejemplar>();
    }
}
