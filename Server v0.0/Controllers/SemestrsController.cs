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
    public class SemestrsController : Controller
    {
        private readonly ApplicationContext _context;

        public SemestrsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Semestrs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Semestrs.ToListAsync());
        }

        // GET: Semestrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Semestrs == null)
            {
                return NotFound();
            }

            var semestr = await _context.Semestrs
                .FirstOrDefaultAsync(m => m.Id_Sem == id);
            if (semestr == null)
            {
                return NotFound();
            }

            return View(semestr);
        }

        // GET: Semestrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Semestrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Sem")] Semestr semestr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(semestr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semestr);
        }

        // GET: Semestrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Semestrs == null)
            {
                return NotFound();
            }

            var semestr = await _context.Semestrs.FindAsync(id);
            if (semestr == null)
            {
                return NotFound();
            }
            return View(semestr);
        }

        // POST: Semestrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Sem")] Semestr semestr)
        {
            if (id != semestr.Id_Sem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(semestr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SemestrExists(semestr.Id_Sem))
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
            return View(semestr);
        }

        // GET: Semestrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Semestrs == null)
            {
                return NotFound();
            }

            var semestr = await _context.Semestrs
                .FirstOrDefaultAsync(m => m.Id_Sem == id);
            if (semestr == null)
            {
                return NotFound();
            }

            return View(semestr);
        }

        // POST: Semestrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Semestrs == null)
            {
                return Problem("Entity set 'ApplicationContext.Semestrs'  is null.");
            }
            var semestr = await _context.Semestrs.FindAsync(id);
            if (semestr != null)
            {
                _context.Semestrs.Remove(semestr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SemestrExists(int id)
        {
          return _context.Semestrs.Any(e => e.Id_Sem == id);
        }
    }
}
