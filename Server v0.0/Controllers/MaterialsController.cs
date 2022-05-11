using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server_v0._0.Models;

namespace Server_v0._0.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly ApplicationContext _context;

        public MaterialsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
              return View(await _context.Computers.ToListAsync());
        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Computers == null)
            {
                return NotFound();
            }

            var material = await _context.Computers
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialId,Title_M,PricePerGram")] Material material)
        {
            if (ModelState.IsValid)
            {
                _context.Add(material);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(material);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Computers == null)
            {
                return NotFound();
            }

            var material = await _context.Computers.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialId,Title_M,PricePerGram")] Material material)
        {
            if (id != material.MaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(material);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.MaterialId))
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
            return View(material);
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Computers == null)
            {
                return NotFound();
            }

            var material = await _context.Computers
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Computers == null)
            {
                return Problem("Entity set 'ApplicationContext.Computers'  is null.");
            }
            var material = await _context.Computers.FindAsync(id);
            if (material != null)
            {
                _context.Computers.Remove(material);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
          return _context.Computers.Any(e => e.MaterialId == id);
        }
    }
}
