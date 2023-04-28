
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Identity.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly dbContext _context;

        public SolicitudesController(dbContext context)
        {
            _context = context;
        }

        // GET: Solicitudes
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
              return _context.Solicitudes != null ? 
                          View(await _context.Solicitudes.ToListAsync()) :
                          Problem("Entity set 'dbContext.Solicitudes'  is null.");
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitudes = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            return View(solicitudes);
        }

        // GET: Solicitudes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usuario,IdProducto,Cantidad")] Solicitudes solicitudes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitudes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitudes);
        }

        // GET: Solicitudes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitudes = await _context.Solicitudes.FindAsync(id);
            if (solicitudes == null)
            {
                return NotFound();
            }
            return View(solicitudes);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usuario,IdProducto,Cantidad")] Solicitudes solicitudes)
        {
            if (id != solicitudes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitudes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudesExists(solicitudes.Id))
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
            return View(solicitudes);
        }

        // GET: Solicitudes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitudes = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            return View(solicitudes);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Solicitudes == null)
            {
                return Problem("Entity set 'dbContext.Solicitudes'  is null.");
            }
            var solicitudes = await _context.Solicitudes.FindAsync(id);
            if (solicitudes != null)
            {
                _context.Solicitudes.Remove(solicitudes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudesExists(int id)
        {
          return (_context.Solicitudes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
