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
    public class SyllabusesController : Controller
    {
        private readonly ApplicationContext _context;

        public SyllabusesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Syllabuses
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Syllabus.Include(s => s.Student).Include(s => s.Subject);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Syllabuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Syllabus == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.SyllabusId == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // GET: Syllabuses/Create
        public IActionResult Create()
        {
            ViewData["StudId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId");
            return View();
        }

        // POST: Syllabuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SyllabusId,Grade,StudId,SubjectId")] Syllabus syllabus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(syllabus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudId"] = new SelectList(_context.Student, "StudentId", "StudentId", syllabus.StudId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", syllabus.SubjectId);
            return View(syllabus);
        }

        // GET: Syllabuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Syllabus == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus.FindAsync(id);
            if (syllabus == null)
            {
                return NotFound();
            }
            ViewData["StudId"] = new SelectList(_context.Student, "StudentId", "StudentId", syllabus.StudId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", syllabus.SubjectId);
            return View(syllabus);
        }

        // POST: Syllabuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SyllabusId,Grade,StudId,SubjectId")] Syllabus syllabus)
        {
            if (id != syllabus.SyllabusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(syllabus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SyllabusExists(syllabus.SyllabusId))
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
            ViewData["StudId"] = new SelectList(_context.Student, "StudentId", "StudentId", syllabus.StudId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectId", syllabus.SubjectId);
            return View(syllabus);
        }

        // GET: Syllabuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Syllabus == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.SyllabusId == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // POST: Syllabuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Syllabus == null)
            {
                return Problem("Entity set 'ApplicationContext.Syllabus'  is null.");
            }
            var syllabus = await _context.Syllabus.FindAsync(id);
            if (syllabus != null)
            {
                _context.Syllabus.Remove(syllabus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SyllabusExists(int id)
        {
          return _context.Syllabus.Any(e => e.SyllabusId == id);
        }
    }
}
