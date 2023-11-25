using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba002.Models.dbModels;

namespace Prueba002.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArtistasController : Controller
    {
        private readonly PropuestadeBasedeDatosdelProyectoFinalContext _context;

        public ArtistasController(PropuestadeBasedeDatosdelProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Artistas
        public async Task<IActionResult> Index()
        {
              return _context.Artista != null ? 
                          View(await _context.Artista.ToListAsync()) :
                          Problem("Entity set 'PropuestadeBasedeDatosdelProyectoFinalContext.Artista'  is null.");
        }

        // GET: Artistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artista == null)
            {
                return NotFound();
            }

            var artistum = await _context.Artista
                .FirstOrDefaultAsync(m => m.IdArtista == id);
            if (artistum == null)
            {
                return NotFound();
            }

            return View(artistum);
        }

        // GET: Artistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArtista,Nombre")] Artistum artistum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artistum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artistum);
        }

        // GET: Artistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artista == null)
            {
                return NotFound();
            }

            var artistum = await _context.Artista.FindAsync(id);
            if (artistum == null)
            {
                return NotFound();
            }
            return View(artistum);
        }

        // POST: Artistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArtista,Nombre")] Artistum artistum)
        {
            if (id != artistum.IdArtista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artistum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistumExists(artistum.IdArtista))
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
            return View(artistum);
        }

        // GET: Artistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artista == null)
            {
                return NotFound();
            }

            var artistum = await _context.Artista
                .FirstOrDefaultAsync(m => m.IdArtista == id);
            if (artistum == null)
            {
                return NotFound();
            }

            return View(artistum);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artista == null)
            {
                return Problem("Entity set 'PropuestadeBasedeDatosdelProyectoFinalContext.Artista'  is null.");
            }
            var artistum = await _context.Artista.FindAsync(id);
            if (artistum != null)
            {
                _context.Artista.Remove(artistum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistumExists(int id)
        {
          return (_context.Artista?.Any(e => e.IdArtista == id)).GetValueOrDefault();
        }
    }
}
