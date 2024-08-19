using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class AutorLibro
    {
        // Fk autor
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }

        // Fk libro
        public Guid LibroId { get; set; }
        public Libro Libro { get; set; }

    }
}
