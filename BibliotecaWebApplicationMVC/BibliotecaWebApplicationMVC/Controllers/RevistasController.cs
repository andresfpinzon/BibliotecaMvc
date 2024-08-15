using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWebApplicationMVC.Data;
using BibliotecaWebApplicationMVC.Models;

namespace BibliotecaWebApplicationMVC.Controllers
{
    public class RevistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RevistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Revistas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Revistas.Include(r => r.Publicacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Revistas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revista = await _context.Revistas
                .Include(r => r.Publicacion)
                .FirstOrDefaultAsync(m => m.RevistaId == id);
            if (revista == null)
            {
                return NotFound();
            }

            return View(revista);
        }

        // GET: Revistas/Create
        public IActionResult Create()
        {
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "PublicacionId", "PublicacionId");
            return View();
        }

        // POST: Revistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RevistaId,Numero,Nombre,FechaPublicacion,PublicacionId")] Revista revista)
        {
            if (ModelState.IsValid)
            {
                revista.RevistaId = Guid.NewGuid();
                _context.Add(revista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "PublicacionId", "PublicacionId", revista.PublicacionId);
            return View(revista);
        }

        // GET: Revistas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revista = await _context.Revistas.FindAsync(id);
            if (revista == null)
            {
                return NotFound();
            }
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "PublicacionId", "PublicacionId", revista.PublicacionId);
            return View(revista);
        }

        // POST: Revistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RevistaId,Numero,Nombre,FechaPublicacion,PublicacionId")] Revista revista)
        {
            if (id != revista.RevistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevistaExists(revista.RevistaId))
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
            ViewData["PublicacionId"] = new SelectList(_context.Publicaciones, "PublicacionId", "PublicacionId", revista.PublicacionId);
            return View(revista);
        }

        // GET: Revistas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revista = await _context.Revistas
                .Include(r => r.Publicacion)
                .FirstOrDefaultAsync(m => m.RevistaId == id);
            if (revista == null)
            {
                return NotFound();
            }

            return View(revista);
        }

        // POST: Revistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var revista = await _context.Revistas.FindAsync(id);
            if (revista != null)
            {
                _context.Revistas.Remove(revista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevistaExists(Guid id)
        {
            return _context.Revistas.Any(e => e.RevistaId == id);
        }
    }
}
