using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class AutorLibro
    {
        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }

        public Guid LibroId { get; set; }
        public Libro Libro { get; set; }

    }
}
