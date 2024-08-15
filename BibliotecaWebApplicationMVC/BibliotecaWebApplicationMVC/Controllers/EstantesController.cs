﻿using System;
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
    public class EstantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Estantes.Include(e => e.Estanteria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Estantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estante = await _context.Estantes
                .Include(e => e.Estanteria)
                .FirstOrDefaultAsync(m => m.EstanteId == id);
            if (estante == null)
            {
                return NotFound();
            }

            return View(estante);
        }

        // GET: Estantes/Create
        public IActionResult Create()
        {
            ViewData["EstanteriaId"] = new SelectList(_context.Estanterias, "EstanteriaId", "EstanteriaId");
            return View();
        }

        // POST: Estantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstanteId,CodigoEstante,EstanteriaId")] Estante estante)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(estante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstanteriaId"] = new SelectList(_context.Estanterias, "EstanteriaId", "EstanteriaId", estante.EstanteriaId);
            return View(estante);
        }

        // GET: Estantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estante = await _context.Estantes.FindAsync(id);
            if (estante == null)
            {
                return NotFound();
            }
            ViewData["EstanteriaId"] = new SelectList(_context.Estanterias, "EstanteriaId", "EstanteriaId", estante.EstanteriaId);
            return View(estante);
        }

        // POST: Estantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstanteId,CodigoEstante,EstanteriaId")] Estante estante)
        {
            if (id != estante.EstanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstanteExists(estante.EstanteId))
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
            ViewData["EstanteriaId"] = new SelectList(_context.Estanterias, "EstanteriaId", "EstanteriaId", estante.EstanteriaId);
            return View(estante);
        }

        // GET: Estantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estante = await _context.Estantes
                .Include(e => e.Estanteria)
                .FirstOrDefaultAsync(m => m.EstanteId == id);
            if (estante == null)
            {
                return NotFound();
            }

            return View(estante);
        }

        // POST: Estantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estante = await _context.Estantes.FindAsync(id);
            if (estante != null)
            {
                _context.Estantes.Remove(estante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstanteExists(int id)
        {
            return _context.Estantes.Any(e => e.EstanteId == id);
        }
    }
}
