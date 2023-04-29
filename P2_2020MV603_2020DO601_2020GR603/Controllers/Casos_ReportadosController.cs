using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020MV603_2020DO601_2020GR603.Models;

namespace P2_2020MV603_2020DO601_2020GR603.Controllers
{
    public class Casos_ReportadosController : Controller
    {
        private readonly casosDbContext _context;

        public Casos_ReportadosController(casosDbContext context)
        {
            _context = context;
        }

        // GET: Casos_Reportados
        public async Task<IActionResult> Index()
        {
              return _context.Casos_Reportados != null ? 
                          View(await _context.Casos_Reportados.ToListAsync()) :
                          Problem("Entity set 'casosDbContext.Casos_Reportados'  is null.");
        }

        // GET: Casos_Reportados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Casos_Reportados == null)
            {
                return NotFound();
            }

            var casos_Reportados = await _context.Casos_Reportados
                .FirstOrDefaultAsync(m => m.id_Casos == id);
            if (casos_Reportados == null)
            {
                return NotFound();
            }

            return View(casos_Reportados);
        }

        // GET: Casos_Reportados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Casos_Reportados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_Casos,casos_Confirmados,casos_Recuperados,casos_Fallecidos")] Casos_Reportados casos_Reportados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casos_Reportados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casos_Reportados);
        }

        // GET: Casos_Reportados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Casos_Reportados == null)
            {
                return NotFound();
            }

            var casos_Reportados = await _context.Casos_Reportados.FindAsync(id);
            if (casos_Reportados == null)
            {
                return NotFound();
            }
            return View(casos_Reportados);
        }

        // POST: Casos_Reportados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Casos,casos_Confirmados,casos_Recuperados,casos_Fallecidos")] Casos_Reportados casos_Reportados)
        {
            if (id != casos_Reportados.id_Casos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casos_Reportados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Casos_ReportadosExists(casos_Reportados.id_Casos))
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
            return View(casos_Reportados);
        }

        // GET: Casos_Reportados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Casos_Reportados == null)
            {
                return NotFound();
            }

            var casos_Reportados = await _context.Casos_Reportados
                .FirstOrDefaultAsync(m => m.id_Casos == id);
            if (casos_Reportados == null)
            {
                return NotFound();
            }

            return View(casos_Reportados);
        }

        // POST: Casos_Reportados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Casos_Reportados == null)
            {
                return Problem("Entity set 'casosDbContext.Casos_Reportados'  is null.");
            }
            var casos_Reportados = await _context.Casos_Reportados.FindAsync(id);
            if (casos_Reportados != null)
            {
                _context.Casos_Reportados.Remove(casos_Reportados);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Casos_ReportadosExists(int id)
        {
          return (_context.Casos_Reportados?.Any(e => e.id_Casos == id)).GetValueOrDefault();
        }
    }
}
