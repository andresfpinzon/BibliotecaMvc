﻿using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class Libro : Publicacion
    {
        
        public Guid LibroId { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int NumeroPaginas { get; set; }

        public Libro()
        {
            this.LibroId = Guid.NewGuid();
        }

        // Propiedades de navegacion
        public ICollection<AutorLibro> AutorLibros { get; set; } = new List<AutorLibro>();
    }
}
