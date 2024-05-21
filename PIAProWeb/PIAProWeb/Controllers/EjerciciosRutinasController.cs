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
    public class EjerciciosRutinasController : Controller
    {
        private readonly GymContext _context;

        public EjerciciosRutinasController(GymContext context)
        {
            _context = context;
        }

        // GET: EjerciciosRutinas
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.EjerciciosRutinas.Include(e => e.IdEjercicioNavigation).Include(e => e.IdPesoNavigation).Include(e => e.IdRutinaNavigation);
            return View(await gymContext.ToListAsync());
        }

        // GET: EjerciciosRutinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EjerciciosRutinas == null)
            {
                return NotFound();
            }

            var ejerciciosRutina = await _context.EjerciciosRutinas
                .Include(e => e.IdEjercicioNavigation)
                .Include(e => e.IdPesoNavigation)
                .Include(e => e.IdRutinaNavigation)
                .FirstOrDefaultAsync(m => m.IdEjercicio == id);
            if (ejerciciosRutina == null)
            {
                return NotFound();
            }

            return View(ejerciciosRutina);
        }

        // GET: EjerciciosRutinas/Create
        public IActionResult Create()
        {
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "IdEjercicio", "IdEjercicio");
            ViewData["IdPeso"] = new SelectList(_context.Pesos, "IdPeso", "IdPeso");
            ViewData["IdRutina"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina");
            return View();
        }

        // POST: EjerciciosRutinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEjercicio,IdRutina,Series,Repeticiones,IdPeso")] EjerciciosRutina ejerciciosRutina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejerciciosRutina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "IdEjercicio", "IdEjercicio", ejerciciosRutina.IdEjercicio);
            ViewData["IdPeso"] = new SelectList(_context.Pesos, "IdPeso", "IdPeso", ejerciciosRutina.IdPeso);
            ViewData["IdRutina"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina", ejerciciosRutina.IdRutina);
            return View(ejerciciosRutina);
        }

        // GET: EjerciciosRutinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EjerciciosRutinas == null)
            {
                return NotFound();
            }

            var ejerciciosRutina = await _context.EjerciciosRutinas.FindAsync(id);
            if (ejerciciosRutina == null)
            {
                return NotFound();
            }
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "IdEjercicio", "IdEjercicio", ejerciciosRutina.IdEjercicio);
            ViewData["IdPeso"] = new SelectList(_context.Pesos, "IdPeso", "IdPeso", ejerciciosRutina.IdPeso);
            ViewData["IdRutina"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina", ejerciciosRutina.IdRutina);
            return View(ejerciciosRutina);
        }

        // POST: EjerciciosRutinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEjercicio,IdRutina,Series,Repeticiones,IdPeso")] EjerciciosRutina ejerciciosRutina)
        {
            if (id != ejerciciosRutina.IdEjercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejerciciosRutina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjerciciosRutinaExists(ejerciciosRutina.IdEjercicio))
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
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "IdEjercicio", "IdEjercicio", ejerciciosRutina.IdEjercicio);
            ViewData["IdPeso"] = new SelectList(_context.Pesos, "IdPeso", "IdPeso", ejerciciosRutina.IdPeso);
            ViewData["IdRutina"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina", ejerciciosRutina.IdRutina);
            return View(ejerciciosRutina);
        }

        // GET: EjerciciosRutinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EjerciciosRutinas == null)
            {
                return NotFound();
            }

            var ejerciciosRutina = await _context.EjerciciosRutinas
                .Include(e => e.IdEjercicioNavigation)
                .Include(e => e.IdPesoNavigation)
                .Include(e => e.IdRutinaNavigation)
                .FirstOrDefaultAsync(m => m.IdEjercicio == id);
            if (ejerciciosRutina == null)
            {
                return NotFound();
            }

            return View(ejerciciosRutina);
        }

        // POST: EjerciciosRutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EjerciciosRutinas == null)
            {
                return Problem("Entity set 'GymContext.EjerciciosRutinas'  is null.");
            }
            var ejerciciosRutina = await _context.EjerciciosRutinas.FindAsync(id);
            if (ejerciciosRutina != null)
            {
                _context.EjerciciosRutinas.Remove(ejerciciosRutina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjerciciosRutinaExists(int id)
        {
          return (_context.EjerciciosRutinas?.Any(e => e.IdEjercicio == id)).GetValueOrDefault();
        }
    }
}
