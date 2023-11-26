using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba002.Models.dbModels;

namespace Prueba002.Controllers
{
    public class ListaAlbumsController : Controller
    {
        private readonly PropuestadeBasedeDatosdelProyectoFinalContext _context;

        public ListaAlbumsController(PropuestadeBasedeDatosdelProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: ListaAlbums
        public async Task<IActionResult> Index()
        {
            var propuestadeBasedeDatosdelProyectoFinalContext = _context.ListaAlbums.Include(l => l.IdAlbumNavigation).Include(l => l.IdListaNavigation);
            return View(await propuestadeBasedeDatosdelProyectoFinalContext.ToListAsync());
        }

        // GET: ListaAlbums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ListaAlbums == null)
            {
                return NotFound();
            }

            var listaAlbum = await _context.ListaAlbums
                .Include(l => l.IdAlbumNavigation)
                .Include(l => l.IdListaNavigation)
                .FirstOrDefaultAsync(m => m.IdLista == id);
            if (listaAlbum == null)
            {
                return NotFound();
            }

            return View(listaAlbum);
        }

        // GET: ListaAlbums/Create
        public IActionResult Create()
        {
            ViewData["IdAlbum"] = new SelectList(_context.Albums, "IdAlbum", "IdAlbum");
            ViewData["IdLista"] = new SelectList(_context.Lista, "IdLista", "IdLista");
            return View();
        }

        // POST: ListaAlbums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLista,IdAlbum,FechaAgregado")] ListaAlbum listaAlbum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaAlbum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlbum"] = new SelectList(_context.Albums, "IdAlbum", "IdAlbum", listaAlbum.IdAlbum);
            ViewData["IdLista"] = new SelectList(_context.Lista, "IdLista", "IdLista", listaAlbum.IdLista);
            return View(listaAlbum);
        }

        // GET: ListaAlbums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListaAlbums == null)
            {
                return NotFound();
            }

            var listaAlbum = await _context.ListaAlbums.FindAsync(id);
            if (listaAlbum == null)
            {
                return NotFound();
            }
            ViewData["IdAlbum"] = new SelectList(_context.Albums, "IdAlbum", "IdAlbum", listaAlbum.IdAlbum);
            ViewData["IdLista"] = new SelectList(_context.Lista, "IdLista", "IdLista", listaAlbum.IdLista);
            return View(listaAlbum);
        }

        // POST: ListaAlbums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLista,IdAlbum,FechaAgregado")] ListaAlbum listaAlbum)
        {
            if (id != listaAlbum.IdLista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaAlbum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaAlbumExists(listaAlbum.IdLista))
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
            ViewData["IdAlbum"] = new SelectList(_context.Albums, "IdAlbum", "IdAlbum", listaAlbum.IdAlbum);
            ViewData["IdLista"] = new SelectList(_context.Lista, "IdLista", "IdLista", listaAlbum.IdLista);
            return View(listaAlbum);
        }

        // GET: ListaAlbums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListaAlbums == null)
            {
                return NotFound();
            }

            var listaAlbum = await _context.ListaAlbums
                .Include(l => l.IdAlbumNavigation)
                .Include(l => l.IdListaNavigation)
                .FirstOrDefaultAsync(m => m.IdLista == id);
            if (listaAlbum == null)
            {
                return NotFound();
            }

            return View(listaAlbum);
        }

        // POST: ListaAlbums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ListaAlbums == null)
            {
                return Problem("Entity set 'PropuestadeBasedeDatosdelProyectoFinalContext.ListaAlbums'  is null.");
            }
            var listaAlbum = await _context.ListaAlbums.FindAsync(id);
            if (listaAlbum != null)
            {
                _context.ListaAlbums.Remove(listaAlbum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaAlbumExists(int id)
        {
          return (_context.ListaAlbums?.Any(e => e.IdLista == id)).GetValueOrDefault();
        }
    }
}
