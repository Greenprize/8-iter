using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server_v0._0;
using Server_v0._0.Models;

namespace Server_v0._0.Controllers
{
    public class SyllabusController : Controller
    {
        private readonly ApplicationContext _context;

        public SyllabusController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Syllabus
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Syllabuses.Include(s => s.Student).Include(s => s.Subject);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Syllabus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Syllabuses == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabuses
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Syllabus_Id == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // GET: Syllabus/Create
        public IActionResult Create()
        {
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud");
            ViewData["Id_Subj"] = new SelectList(_context.Subjects, "Id_Subj", "Id_Subj");
            return View();
        }

        // POST: Syllabus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Syllabus_Id,Grade,Id_Subj,Id_Stud")] Syllabus syllabus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(syllabus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud", syllabus.Id_Stud);
            ViewData["Id_Subj"] = new SelectList(_context.Subjects, "Id_Subj", "Id_Subj", syllabus.Id_Subj);
            return View(syllabus);
        }

        // GET: Syllabus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Syllabuses == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabuses.FindAsync(id);
            if (syllabus == null)
            {
                return NotFound();
            }
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud", syllabus.Id_Stud);
            ViewData["Id_Subj"] = new SelectList(_context.Subjects, "Id_Subj", "Id_Subj", syllabus.Id_Subj);
            return View(syllabus);
        }

        // POST: Syllabus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Syllabus_Id,Grade,Id_Subj,Id_Stud")] Syllabus syllabus)
        {
            if (id != syllabus.Syllabus_Id)
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
                    if (!SyllabusExists(syllabus.Syllabus_Id))
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
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud", syllabus.Id_Stud);
            ViewData["Id_Subj"] = new SelectList(_context.Subjects, "Id_Subj", "Id_Subj", syllabus.Id_Subj);
            return View(syllabus);
        }

        // GET: Syllabus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Syllabuses == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabuses
                .Include(s => s.Student)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Syllabus_Id == id);
            if (syllabus == null)
            {
                return NotFound();
            }

            return View(syllabus);
        }

        // POST: Syllabus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Syllabuses == null)
            {
                return Problem("Entity set 'ApplicationContext.Syllabuses'  is null.");
            }
            var syllabus = await _context.Syllabuses.FindAsync(id);
            if (syllabus != null)
            {
                _context.Syllabuses.Remove(syllabus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SyllabusExists(int id)
        {
          return _context.Syllabuses.Any(e => e.Syllabus_Id == id);
        }
    }
}
