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
    public class PreguntaTestsController : Controller
    {
        private readonly PropuestadeBasedeDatosdelProyectoFinalContext _context;

        public PreguntaTestsController(PropuestadeBasedeDatosdelProyectoFinalContext context)
        {
            _context = context;
        }

        // GET: PreguntaTests
        public async Task<IActionResult> Index()
        {
            var propuestadeBasedeDatosdelProyectoFinalContext = _context.PreguntaTests.Include(p => p.IdTestNavigation);
            return View(await propuestadeBasedeDatosdelProyectoFinalContext.ToListAsync());
        }

        // GET: PreguntaTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PreguntaTests == null)
            {
                return NotFound();
            }

            var preguntaTest = await _context.PreguntaTests
                .Include(p => p.IdTestNavigation)
                .FirstOrDefaultAsync(m => m.IdPregunta == id);
            if (preguntaTest == null)
            {
                return NotFound();
            }

            return View(preguntaTest);
        }

        // GET: PreguntaTests/Create
        public IActionResult Create()
        {
            ViewData["IdTest"] = new SelectList(_context.Tests, "IdTest", "IdTest");
            return View();
        }

        // POST: PreguntaTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPregunta,IdTest,Descripcion")] PreguntaTestHR preguntaTest)
        {
            if (ModelState.IsValid)
            {
                PreguntaTest preguntatest1 = new PreguntaTest() { 
                    IdTest=preguntaTest.IdTest,
                    Descripcion=preguntaTest.Descripcion
                };
                _context.PreguntaTests.Add(preguntatest1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTest"] = new SelectList(_context.Tests, "IdTest", "IdTest", preguntaTest.IdTest);
            return View(preguntaTest);
        }

        // GET: PreguntaTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PreguntaTests == null)
            {
                return NotFound();
            }

            var preguntaTest = await _context.PreguntaTests.FindAsync(id);
            if (preguntaTest == null)
            {
                return NotFound();
            }
            ViewData["IdTest"] = new SelectList(_context.Tests, "IdTest", "IdTest", preguntaTest.IdTest);
            return View(preguntaTest);
        }

        // POST: PreguntaTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPregunta,IdTest,Descripcion")] PreguntaTest preguntaTest)
        {
            if (id != preguntaTest.IdPregunta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preguntaTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntaTestExists(preguntaTest.IdPregunta))
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
            ViewData["IdTest"] = new SelectList(_context.Tests, "IdTest", "IdTest", preguntaTest.IdTest);
            return View(preguntaTest);
        }

        // GET: PreguntaTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PreguntaTests == null)
            {
                return NotFound();
            }

            var preguntaTest = await _context.PreguntaTests
                .Include(p => p.IdTestNavigation)
                .FirstOrDefaultAsync(m => m.IdPregunta == id);
            if (preguntaTest == null)
            {
                return NotFound();
            }

            return View(preguntaTest);
        }

        // POST: PreguntaTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PreguntaTests == null)
            {
                return Problem("Entity set 'PropuestadeBasedeDatosdelProyectoFinalContext.PreguntaTests'  is null.");
            }
            var preguntaTest = await _context.PreguntaTests.FindAsync(id);
            if (preguntaTest != null)
            {
                _context.PreguntaTests.Remove(preguntaTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntaTestExists(int id)
        {
          return (_context.PreguntaTests?.Any(e => e.IdPregunta == id)).GetValueOrDefault();
        }
    }
}
