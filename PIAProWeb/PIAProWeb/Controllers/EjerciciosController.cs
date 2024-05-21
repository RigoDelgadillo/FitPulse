using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIAProWeb.Models.dbModels;

namespace PIAProWeb.Controllers
{
    public class EjerciciosController : Controller
    {
        private readonly GymContext _context;

        public EjerciciosController(GymContext context)
        {
            _context = context;
        }

        // GET: Ejercicios
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Ejercicios.Include(e => e.IdGruposMuscularesNavigation);
            return View(await gymContext.ToListAsync());
        }

        // GET: Ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .Include(e => e.IdGruposMuscularesNavigation)
                .FirstOrDefaultAsync(m => m.IdEjercicio == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // GET: Ejercicios/Create
        public IActionResult Create()
        {
            ViewData["IdGruposMusculares"] = new SelectList(_context.GruposMusculares, "IdGruposMusculares", "Musculo");
            return View();
        }

        // POST: Ejercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEjercicio,Nombre,Descripcion,IdGruposMusculares")] EjercicioHR ejercicio)
        {
            if (ModelState.IsValid)
            {
                Ejercicio ejercicio1 = new Ejercicio
                {
                    Nombre = ejercicio.Nombre,
                    Descripcion = ejercicio.Descripcion,
                    IdGruposMusculares = ejercicio.IdGruposMusculares
                };
                _context.Ejercicios.Add(ejercicio1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGruposMusculares"] = new SelectList(_context.GruposMusculares, "IdGruposMusculares", "IdGruposMusculares", ejercicio.IdGruposMusculares);
            return View(ejercicio);
        }

        // GET: Ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            ViewData["IdGruposMusculares"] = new SelectList(_context.GruposMusculares, "IdGruposMusculares", "IdGruposMusculares", ejercicio.IdGruposMusculares);
            return View(ejercicio);
        }

        // POST: Ejercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEjercicio,Nombre,Descripcion,IdGruposMusculares")] Ejercicio ejercicio)
        {
            if (id != ejercicio.IdEjercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjercicioExists(ejercicio.IdEjercicio))
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
            ViewData["IdGruposMusculares"] = new SelectList(_context.GruposMusculares, "IdGruposMusculares", "IdGruposMusculares", ejercicio.IdGruposMusculares);
            return View(ejercicio);
        }

        // GET: Ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ejercicios == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .Include(e => e.IdGruposMuscularesNavigation)
                .FirstOrDefaultAsync(m => m.IdEjercicio == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // POST: Ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ejercicios == null)
            {
                return Problem("Entity set 'GymContext.Ejercicios'  is null.");
            }
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjercicioExists(int id)
        {
          return (_context.Ejercicios?.Any(e => e.IdEjercicio == id)).GetValueOrDefault();
        }
    }
}
