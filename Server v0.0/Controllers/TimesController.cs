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
    public class TimesController : Controller
    {
        private readonly ApplicationContext _context;

        public TimesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Times
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Time.Include(t => t.Semestr).Include(t => t.Subject);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Times/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Time == null)
            {
                return NotFound();
            }

            var time = await _context.Time
                .Include(t => t.Semestr)
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(m => m.TimeId == id);
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        // GET: Times/Create
        public IActionResult Create()
        {
            ViewData["SemestrId"] = new SelectList(_context.Semestr, "SemestrId", "SemestrId");
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId");
            return View();
        }

        // POST: Times/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeId,LectureTime,WorkTime,LaborTime,SemestrId,SubjectId")] Time time)
        {
            if (ModelState.IsValid)
            {
                _context.Add(time);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SemestrId"] = new SelectList(_context.Semestr, "SemestrId", "SemestrId", time.SemestrId);
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", time.SubjectId);
            return View(time);
        }

        // GET: Times/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Time == null)
            {
                return NotFound();
            }

            var time = await _context.Time.FindAsync(id);
            if (time == null)
            {
                return NotFound();
            }
            ViewData["SemestrId"] = new SelectList(_context.Semestr, "SemestrId", "SemestrId", time.SemestrId);
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", time.SubjectId);
            return View(time);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeId,LectureTime,WorkTime,LaborTime,SemestrId,SubjectId")] Time time)
        {
            if (id != time.TimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(time);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeExists(time.TimeId))
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
            ViewData["SemestrId"] = new SelectList(_context.Semestr, "SemestrId", "SemestrId", time.SemestrId);
            ViewData["SubjectId"] = new SelectList(_context.Set<Subject>(), "SubjectId", "SubjectId", time.SubjectId);
            return View(time);
        }

        // GET: Times/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Time == null)
            {
                return NotFound();
            }

            var time = await _context.Time
                .Include(t => t.Semestr)
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(m => m.TimeId == id);
            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Time == null)
            {
                return Problem("Entity set 'ApplicationContext.Time'  is null.");
            }
            var time = await _context.Time.FindAsync(id);
            if (time != null)
            {
                _context.Time.Remove(time);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeExists(int id)
        {
          return _context.Time.Any(e => e.TimeId == id);
        }
    }
}
