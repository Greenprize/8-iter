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
    public class GradsOfSemestrsController : Controller
    {
        private readonly ApplicationContext _context;

        public GradsOfSemestrsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: GradsOfSemestrs
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.GradsOfSemestr.Include(g => g.Student).Include(g => g.Time);
            return View(await applicationContext.ToListAsync());
        }

        // GET: GradsOfSemestrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GradsOfSemestr == null)
            {
                return NotFound();
            }

            var gradsOfSemestr = await _context.GradsOfSemestr
                .Include(g => g.Student)
                .Include(g => g.Time)
                .FirstOrDefaultAsync(m => m.GradsOfSemestrId == id);
            if (gradsOfSemestr == null)
            {
                return NotFound();
            }

            return View(gradsOfSemestr);
        }

        // GET: GradsOfSemestrs/Create
        public IActionResult Create()
        {
            ViewData["StudId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId");
            ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TimeId");
            return View();
        }

        // POST: GradsOfSemestrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradsOfSemestrId,Grade,StudId,TimeId")] GradsOfSemestr gradsOfSemestr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradsOfSemestr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId", gradsOfSemestr.StudId);
            ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TimeId", gradsOfSemestr.TimeId);
            return View(gradsOfSemestr);
        }

        // GET: GradsOfSemestrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GradsOfSemestr == null)
            {
                return NotFound();
            }

            var gradsOfSemestr = await _context.GradsOfSemestr.FindAsync(id);
            if (gradsOfSemestr == null)
            {
                return NotFound();
            }
            ViewData["StudId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId", gradsOfSemestr.StudId);
            ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TimeId", gradsOfSemestr.TimeId);
            return View(gradsOfSemestr);
        }

        // POST: GradsOfSemestrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradsOfSemestrId,Grade,StudId,TimeId")] GradsOfSemestr gradsOfSemestr)
        {
            if (id != gradsOfSemestr.GradsOfSemestrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradsOfSemestr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradsOfSemestrExists(gradsOfSemestr.GradsOfSemestrId))
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
            ViewData["StudId"] = new SelectList(_context.Set<Student>(), "StudentId", "StudentId", gradsOfSemestr.StudId);
            ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TimeId", gradsOfSemestr.TimeId);
            return View(gradsOfSemestr);
        }

        // GET: GradsOfSemestrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GradsOfSemestr == null)
            {
                return NotFound();
            }

            var gradsOfSemestr = await _context.GradsOfSemestr
                .Include(g => g.Student)
                .Include(g => g.Time)
                .FirstOrDefaultAsync(m => m.GradsOfSemestrId == id);
            if (gradsOfSemestr == null)
            {
                return NotFound();
            }

            return View(gradsOfSemestr);
        }

        // POST: GradsOfSemestrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GradsOfSemestr == null)
            {
                return Problem("Entity set 'ApplicationContext.GradsOfSemestr'  is null.");
            }
            var gradsOfSemestr = await _context.GradsOfSemestr.FindAsync(id);
            if (gradsOfSemestr != null)
            {
                _context.GradsOfSemestr.Remove(gradsOfSemestr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradsOfSemestrExists(int id)
        {
          return _context.GradsOfSemestr.Any(e => e.GradsOfSemestrId == id);
        }
    }
}
