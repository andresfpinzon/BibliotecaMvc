﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWebApplicationMVC.Data;
using BibliotecaWebApplicationMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaWebApplicationMVC.Controllers
{
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autores
        [Authorize(Roles ="Bibliotecario, Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autores.ToListAsync());
        }

        // GET: Autores/Details/5
        [Authorize(Roles = "Bibliotecario, Administrador")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .Include(a => a.AutorLibros) // Incluye los libros asociados al autor
                .ThenInclude(al => al.Libro) // Incluye los detalles de los libros
                .FirstOrDefaultAsync(m => m.AutorId == id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }


        // GET: Autores/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Autores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create([Bind("AutorId,Nombres,Apellidos,Nacionalidad,FotoUrl")] Autor autor, IFormFile foto)
        {
            //if (ModelState.IsValid)
            {
                if (foto != null && foto.Length > 0)
                {
                    var fileName = Path.GetFileName(foto.FileName);
                    var filePath = Path.Combine("wwwroot/images/autores", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await foto.CopyToAsync(stream);
                    }

                    autor.FotoUrl = "/images/autores/" + fileName;  // Almacena la URL de la foto
                }

                autor.AutorId = Guid.NewGuid();
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }


        // GET: Autores/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Autores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(Guid id, [Bind("AutorId,Nombres,Apellidos,Nacionalidad,FotoUrl")] Autor autor, IFormFile foto)
        {
            if (id != autor.AutorId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    var autorExistente = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(a => a.AutorId == id);

                    if (foto != null && foto.Length > 0)
                    {
                        var fileName = Path.GetFileName(foto.FileName);
                        var filePath = Path.Combine("wwwroot/images/autores", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await foto.CopyToAsync(stream);
                        }

                        autor.FotoUrl = "/images/autores/" + fileName;  // Almacena la nueva URL de la foto
                    }
                    else
                    {
                        autor.FotoUrl = autorExistente?.FotoUrl;  // Mantiene la URL de la foto existente si no se carga una nueva
                    }

                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.AutorId))
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
            return View(autor);
        }



        // GET: Autores/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .FirstOrDefaultAsync(m => m.AutorId == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(Guid id)
        {
            return _context.Autores.Any(e => e.AutorId == id);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
