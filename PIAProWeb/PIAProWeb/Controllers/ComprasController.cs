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
    public class ComprasController : Controller
    {
        private readonly GymContext _context;

        public ComprasController(GymContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Compras.Include(c => c.IdMetodoPagoNavigation).Include(c => c.IdPaqueteNavigation).Include(c => c.IdUsuarioNavigation);
            return View(await gymContext.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdMetodoPagoNavigation)
                .Include(c => c.IdPaqueteNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "Metodo");
            ViewData["IdPaquete"] = new SelectList(_context.Rutinas, "IdRutina", "Nombre");
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,IdMetodoPago,FechaCompra,PrecioTotal,IdUsuario,IdPaquete")] ComprasHR compra)
        {
            if (ModelState.IsValid)
            {
                Compra compra1 = new Compra
                {
                    IdCompra = compra.IdCompra,
                    IdMetodoPago = compra.IdMetodoPago,
                    FechaCompra = compra.FechaCompra,
                    PrecioTotal = compra.PrecioTotal,
                    IdUsuario = compra.IdUsuario,
                    IdPaquete = compra.IdPaquete,
                };
                _context.Add(compra1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", compra.IdMetodoPago);
            ViewData["IdPaquete"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina", compra.IdPaquete);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", compra.IdUsuario);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", compra.IdMetodoPago);
            ViewData["IdPaquete"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina", compra.IdPaquete);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", compra.IdUsuario);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompra,IdMetodoPago,FechaCompra,PrecioTotal,IdUsuario,IdPaquete")] Compra compra)
        {
            if (id != compra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.IdCompra))
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
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", compra.IdMetodoPago);
            ViewData["IdPaquete"] = new SelectList(_context.Rutinas, "IdRutina", "IdRutina", compra.IdPaquete);
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", compra.IdUsuario);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compras == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdMetodoPagoNavigation)
                .Include(c => c.IdPaqueteNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compras == null)
            {
                return Problem("Entity set 'GymContext.Compras'  is null.");
            }
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
          return (_context.Compras?.Any(e => e.IdCompra == id)).GetValueOrDefault();
        }
    }
}
