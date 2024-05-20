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
    public class GruposMuscularesController : Controller
    {
        private readonly GymContext _context;

        public GruposMuscularesController(GymContext context)
        {
            _context = context;
        }

        // GET: GruposMusculares
        public async Task<IActionResult> Index()
        {
              return _context.GruposMusculares != null ? 
                          View(await _context.GruposMusculares.ToListAsync()) :
                          Problem("Entity set 'GymContext.GruposMusculares'  is null.");
        }

        // GET: GruposMusculares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GruposMusculares == null)
            {
                return NotFound();
            }

            var gruposMusculare = await _context.GruposMusculares
                .FirstOrDefaultAsync(m => m.IdGruposMusculares == id);
            if (gruposMusculare == null)
            {
                return NotFound();
            }

            return View(gruposMusculare);
        }

        // GET: GruposMusculares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GruposMusculares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGruposMusculares,Musculo")] GruposMusculare gruposMusculare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gruposMusculare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gruposMusculare);
        }

        // GET: GruposMusculares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GruposMusculares == null)
            {
                return NotFound();
            }

            var gruposMusculare = await _context.GruposMusculares.FindAsync(id);
            if (gruposMusculare == null)
            {
                return NotFound();
            }
            return View(gruposMusculare);
        }

        // POST: GruposMusculares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGruposMusculares,Musculo")] GruposMusculare gruposMusculare)
        {
            if (id != gruposMusculare.IdGruposMusculares)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gruposMusculare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GruposMusculareExists(gruposMusculare.IdGruposMusculares))
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
            return View(gruposMusculare);
        }

        // GET: GruposMusculares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GruposMusculares == null)
            {
                return NotFound();
            }

            var gruposMusculare = await _context.GruposMusculares
                .FirstOrDefaultAsync(m => m.IdGruposMusculares == id);
            if (gruposMusculare == null)
            {
                return NotFound();
            }

            return View(gruposMusculare);
        }

        // POST: GruposMusculares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GruposMusculares == null)
            {
                return Problem("Entity set 'GymContext.GruposMusculares'  is null.");
            }
            var gruposMusculare = await _context.GruposMusculares.FindAsync(id);
            if (gruposMusculare != null)
            {
                _context.GruposMusculares.Remove(gruposMusculare);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GruposMusculareExists(int id)
        {
          return (_context.GruposMusculares?.Any(e => e.IdGruposMusculares == id)).GetValueOrDefault();
        }
    }
}
