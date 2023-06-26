using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Data;
using TesisPadel.Models;

namespace TesisPadel.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly TesisPadelDbContext _context;

        public LocalidadController(TesisPadelDbContext context)
        {
            _context = context;
        }

        // GET: Localidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Localidad.ToListAsync());
        }

        // GET: Localidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidad
                .FirstOrDefaultAsync(m => m.LocalidadId == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // GET: Localidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalidadId,LocalidadNombre")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localidad);
        }

        // GET: Localidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidad.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }
            return View(localidad);
        }

        // POST: Localidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalidadId,LocalidadNombre")] Localidad localidad)
        {
            if (id != localidad.LocalidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadExists(localidad.LocalidadId))
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
            return View(localidad);
        }

        // GET: Localidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidad
                .FirstOrDefaultAsync(m => m.LocalidadId == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // POST: Localidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localidad = await _context.Localidad.FindAsync(id);
            _context.Localidad.Remove(localidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidad.Any(e => e.LocalidadId == id);
        }
    }
}