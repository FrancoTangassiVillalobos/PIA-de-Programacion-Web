using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba002.Models;
using Prueba002.Models.dbModels;

namespace Prueba002.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Albums1Controller : Controller
    {
        private readonly PropuestadeBasedeDatosdelProyectoFinalContext _context;

        public Albums1Controller(PropuestadeBasedeDatosdelProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Albums1
        public async Task<IActionResult> Index()
        {
            var propuestadeBasedeDatosdelProyectoFinalContext = _context.Albums.Include(a => a.IdArtistaNavigation).Include(a => a.IdGeneroNavigation);
            return View(await propuestadeBasedeDatosdelProyectoFinalContext.ToListAsync());
        }

        // GET: Albums1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.IdArtistaNavigation)
                .Include(a => a.IdGeneroNavigation)
                .FirstOrDefaultAsync(m => m.IdAlbum == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums1/Create
        public IActionResult Create()
        {
            ViewData["IdArtista"] = new SelectList(_context.Artista, "IdArtista", "IdArtista");
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "IdGenero");
            return View();
        }

        // POST: Albums1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlbum,NombreAlbum,IdGenero,IdArtista,FotoAlbum")] Album1HR album)
        {
            if (ModelState.IsValid)
            {
                Album album1 = new Album
                {
                    NombreAlbum = album.NombreAlbum,
                    IdGenero = album.IdGenero,
                    IdArtista = album.IdArtista,
                    FotoAlbum = album.FotoAlbum
                };
                _context.Albums.Add(album1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArtista"] = new SelectList(_context.Artista, "IdArtista", "IdArtista", album.IdArtista);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", album.IdGenero);
            return View(album);
        }

        // GET: Albums1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["IdArtista"] = new SelectList(_context.Artista, "IdArtista", "IdArtista", album.IdArtista);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", album.IdGenero);
            return View(album);
        }

        // POST: Albums1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlbum,NombreAlbum,IdGenero,IdArtista,FotoAlbum")] Album album)
        {
            if (id != album.IdAlbum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.IdAlbum))
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
            ViewData["IdArtista"] = new SelectList(_context.Artista, "IdArtista", "IdArtista", album.IdArtista);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "IdGenero", album.IdGenero);
            return View(album);
        }

        // GET: Albums1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.IdArtistaNavigation)
                .Include(a => a.IdGeneroNavigation)
                .FirstOrDefaultAsync(m => m.IdAlbum == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'PropuestadeBasedeDatosdelProyectoFinalContext.Albums'  is null.");
            }
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return (_context.Albums?.Any(e => e.IdAlbum == id)).GetValueOrDefault();
        }
    }
}