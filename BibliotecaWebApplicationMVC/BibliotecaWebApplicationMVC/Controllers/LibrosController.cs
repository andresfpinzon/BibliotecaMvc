using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaWebApplicationMVC.Data;
using BibliotecaWebApplicationMVC.Models;

namespace BibliotecaWebApplicationMVC.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var libros = await _context.Libros
                .Include(l => l.AutorLibros)
                    .ThenInclude(al => al.Autor)
                .ToListAsync();
            return View(libros);
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.AutorLibros)
                    .ThenInclude(al => al.Autor)
                .FirstOrDefaultAsync(m => m.LibroId == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewBag.Autores = _context.Autores.ToList();
            return View();
        }

        // POST: Libros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Titulo,NumeroPaginas,Formato")] Libro libro, Guid[] selectedAutores)
        {
            //if (ModelState.IsValid)
            {
                //var errors = ModelState.SelectMany(x => x.Value.Errors)
                //           .Select(x => x.ErrorMessage).ToList();
                // Aquí podrías hacer un `Debug.WriteLine(errors)` o pasar los errores a la vista para inspeccionarlos.
                //foreach (var error in errors)
                //{
                //    Console.WriteLine(error); // O usa Debug.WriteLine si estás en Visual Studio
                //}

                // Crear una nueva publicación
                var publicacion = new Publicacion
                {
                    PublicacionId = Guid.NewGuid()
                };

                // Guardar la publicación
                _context.Publicaciones.Add(publicacion);
                await _context.SaveChangesAsync();

                // Asignar la publicación al libro
                libro.PublicacionId = publicacion.PublicacionId;
                libro.LibroId = Guid.NewGuid();

                // Guardar el libro
                _context.Add(libro);
                await _context.SaveChangesAsync();

                // Guardar la relación AutorLibro
                if (selectedAutores != null)
                {
                    foreach (var autorId in selectedAutores)
                    {
                        var autorLibro = new AutorLibro
                        {
                            AutorId = autorId,
                            LibroId = libro.LibroId
                        };
                        _context.AutorLibros.Add(autorLibro);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Autores = _context.Autores.ToList();
            return View(libro);
        }


        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.Publicacion)
                .Include(l => l.AutorLibros)
                    .ThenInclude(al => al.Autor)
                .FirstOrDefaultAsync(m => m.LibroId == id);

            if (libro == null)
            {
                return NotFound();
            }

            ViewBag.Autores = _context.Autores.ToList();
            ViewBag.SelectedAutores = libro.AutorLibros.Select(al => al.AutorId).ToList() ?? new List<Guid>();

            return View(libro);
        }

        // POST: Libros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("LibroId,ISBN,Titulo,NumeroPaginas,Formato")] Libro libro, Guid[] selectedAutores)
        {
            if (id != libro.LibroId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    // Cargar el libro original desde la base de datos incluyendo la publicación
                    var libroFromDb = await _context.Libros
                        .Include(l => l.Publicacion) // Asegura que Publicacion esté incluida
                        .FirstOrDefaultAsync(l => l.LibroId == id);

                    if (libroFromDb == null)
                    {
                        return NotFound();
                    }

                    // Actualizar los campos que pueden cambiar
                    libroFromDb.ISBN = libro.ISBN;
                    libroFromDb.Titulo = libro.Titulo;
                    libroFromDb.NumeroPaginas = libro.NumeroPaginas;
                    libroFromDb.Formato = libro.Formato;
                    // No actualizamos PublicacionId para evitar el conflicto de clave foránea

                    // Guardar los cambios en el libro
                    _context.Update(libroFromDb);
                    await _context.SaveChangesAsync();

                    // Actualizar la relación AutorLibro
                    var existingAutorLibros = _context.AutorLibros.Where(al => al.LibroId == id);
                    _context.AutorLibros.RemoveRange(existingAutorLibros);

                    if (selectedAutores != null && selectedAutores.Any())
                    {
                        foreach (var autorId in selectedAutores)
                        {
                            var autorLibro = new AutorLibro
                            {
                                AutorId = autorId,
                                LibroId = libro.LibroId
                            };
                            _context.AutorLibros.Add(autorLibro);
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.LibroId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Autores = _context.Autores.ToList();
            ViewBag.SelectedAutores = selectedAutores != null ? selectedAutores.ToList() : new List<Guid>();
            return View(libro);
        }

        private bool LibroExists(Guid id)
        {
            return _context.Libros.Any(e => e.LibroId == id);
        }



    // GET: Libros/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.AutorLibros)
                    .ThenInclude(al => al.Autor)
                .FirstOrDefaultAsync(m => m.LibroId == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var libro = await _context.Libros
                .Include(l => l.AutorLibros)
                .Include(l => l.Publicacion) // Incluye la Publicacion asociada
                .FirstOrDefaultAsync(l => l.LibroId == id);

            if (libro != null)
            {
                // Eliminar relaciones en AutorLibro
                _context.AutorLibros.RemoveRange(libro.AutorLibros);

                // Eliminar la publicacion asociada
                if (libro.Publicacion != null)
                {
                    _context.Publicaciones.Remove(libro.Publicacion);
                }

                // Eliminar el libro
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }



        // Método para crear un nuevo autor
        [HttpPost]
        public async Task<IActionResult> CreateAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {
                autor.AutorId = Guid.NewGuid();
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(autor);
        }
    }
}

