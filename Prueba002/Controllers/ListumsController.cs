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
    public class ListumsController : Controller
    {
        private readonly PropuestadeBasedeDatosdelProyectoFinalContext _context;

        public ListumsController(PropuestadeBasedeDatosdelProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: Listums
        public async Task<IActionResult> Index()
        {
            var propuestadeBasedeDatosdelProyectoFinalContext = _context.Lista.Include(l => l.IdUsuarioNavigation);
            return View(await propuestadeBasedeDatosdelProyectoFinalContext.ToListAsync());
        }

        // GET: Listums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lista == null)
            {
                return NotFound();
            }

            var listum = await _context.Lista
                .Include(l => l.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdLista == id);
            if (listum == null)
            {
                return NotFound();
            }

            return View(listum);
        }

        // GET: Listums/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Listums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLista,IdUsuario,NombreLista")] Listum listum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", listum.IdUsuario);
            return View(listum);
        }

        // GET: Listums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lista == null)
            {
                return NotFound();
            }

            var listum = await _context.Lista.FindAsync(id);
            if (listum == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", listum.IdUsuario);
            return View(listum);
        }

        // POST: Listums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLista,IdUsuario,NombreLista")] Listum listum)
        {
            if (id != listum.IdLista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListumExists(listum.IdLista))
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
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", listum.IdUsuario);
            return View(listum);
        }

        // GET: Listums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lista == null)
            {
                return NotFound();
            }

            var listum = await _context.Lista
                .Include(l => l.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdLista == id);
            if (listum == null)
            {
                return NotFound();
            }

            return View(listum);
        }

        // POST: Listums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lista == null)
            {
                return Problem("Entity set 'PropuestadeBasedeDatosdelProyectoFinalContext.Lista'  is null.");
            }
            var listum = await _context.Lista.FindAsync(id);
            if (listum != null)
            {
                _context.Lista.Remove(listum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListumExists(int id)
        {
            return (_context.Lista?.Any(e => e.IdLista == id)).GetValueOrDefault();
        }
    }
}