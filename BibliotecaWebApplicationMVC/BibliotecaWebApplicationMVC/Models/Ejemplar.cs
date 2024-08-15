﻿using Mono.TextTemplating;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaWebApplicationMVC.Models
{
    public class Ejemplar
    {
        [Key]
        public int EjemplarId { get; set; }
        public int PublicacionId { get; set; }
        public int EstanteId { get; set; }

        // Navigation properties
        public Publicacion Publicacion { get; set; }
        public Estante Estante { get; set; }
    }
}
