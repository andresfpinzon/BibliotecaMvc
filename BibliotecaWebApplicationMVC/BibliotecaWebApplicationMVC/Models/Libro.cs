using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class Libro
    {
        [Key]
        public Guid LibroId { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Formato { get; set; }
        public int NumeroPaginas { get; set; }
        public Guid? PublicacionId { get; set; }
        public Publicacion Publicacion { get; set; }
        public string PortadaUrl { get; set; }
        public string ContraportadaUrl { get; set; }

        public Libro()
        {
            this.LibroId = Guid.NewGuid(); 
        }

        // Propiedades de navegación
        public ICollection<AutorLibro> AutorLibros { get; set; } = new List<AutorLibro>();
    }
}

