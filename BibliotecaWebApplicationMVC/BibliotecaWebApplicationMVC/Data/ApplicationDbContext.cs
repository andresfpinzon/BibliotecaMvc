using BibliotecaWebApplicationMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaWebApplicationMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Libro>().ToTable("Libros");
            modelBuilder.Entity<Revista>().ToTable("Revistas");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(ul => new { ul.UserId, ul.LoginProvider, ul.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            modelBuilder.Entity<AutorLibro>()
                .HasKey(al => new { al.AutorId, al.LibroId });

            modelBuilder.Entity<Ejemplar>()
                .HasOne(e => e.Publicacion)
                .WithMany(p => p.Ejemplares)
                .HasForeignKey(e => e.PublicacionId);

            modelBuilder.Entity<Estante>()
                .HasOne(e => e.Estanteria)
                .WithMany(es => es.Estantes)
                .HasForeignKey(e => e.EstanteriaId);
        }


        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Ejemplar> Ejemplares { get; set; }
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Estanteria> Estanterias { get; set; }
        public DbSet<Revista> Revistas { get; set; }

    }
}
