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
    public class Grads_Of_SemestrController : Controller
    {
        private readonly ApplicationContext _context;

        public Grads_Of_SemestrController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Grads_Of_Semestr
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Grads_Of_Semestrs.Include(g => g.Student).Include(g => g.Time_ss);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Grads_Of_Semestr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grads_Of_Semestrs == null)
            {
                return NotFound();
            }

            var grads_Of_Semestr = await _context.Grads_Of_Semestrs
                .Include(g => g.Student)
                .Include(g => g.Time_ss)
                .FirstOrDefaultAsync(m => m.Grads_Of_Semestr_Id == id);
            if (grads_Of_Semestr == null)
            {
                return NotFound();
            }

            return View(grads_Of_Semestr);
        }

        // GET: Grads_Of_Semestr/Create
        public IActionResult Create()
        {
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud");
            ViewData["Id_Time"] = new SelectList(_context.Time_sss, "ID_Time", "Time_Labor");
            return View();
        }

        // POST: Grads_Of_Semestr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Grads_Of_Semestr_Id,Grade,Id_Time,Id_Stud")] Grads_Of_Semestr grads_Of_Semestr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grads_Of_Semestr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud", grads_Of_Semestr.Id_Stud);
            ViewData["Id_Time"] = new SelectList(_context.Time_sss, "ID_Time", "Time_Labor", grads_Of_Semestr.Id_Time);
            return View(grads_Of_Semestr);
        }

        // GET: Grads_Of_Semestr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grads_Of_Semestrs == null)
            {
                return NotFound();
            }

            var grads_Of_Semestr = await _context.Grads_Of_Semestrs.FindAsync(id);
            if (grads_Of_Semestr == null)
            {
                return NotFound();
            }
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud", grads_Of_Semestr.Id_Stud);
            ViewData["Id_Time"] = new SelectList(_context.Time_sss, "ID_Time", "Time_Labor", grads_Of_Semestr.Id_Time);
            return View(grads_Of_Semestr);
        }

        // POST: Grads_Of_Semestr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Grads_Of_Semestr_Id,Grade,Id_Time,Id_Stud")] Grads_Of_Semestr grads_Of_Semestr)
        {
            if (id != grads_Of_Semestr.Grads_Of_Semestr_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grads_Of_Semestr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Grads_Of_SemestrExists(grads_Of_Semestr.Grads_Of_Semestr_Id))
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
            ViewData["Id_Stud"] = new SelectList(_context.Students, "Id_Stud", "Id_Stud", grads_Of_Semestr.Id_Stud);
            ViewData["Id_Time"] = new SelectList(_context.Time_sss, "ID_Time", "Time_Labor", grads_Of_Semestr.Id_Time);
            return View(grads_Of_Semestr);
        }

        // GET: Grads_Of_Semestr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grads_Of_Semestrs == null)
            {
                return NotFound();
            }

            var grads_Of_Semestr = await _context.Grads_Of_Semestrs
                .Include(g => g.Student)
                .Include(g => g.Time_ss)
                .FirstOrDefaultAsync(m => m.Grads_Of_Semestr_Id == id);
            if (grads_Of_Semestr == null)
            {
                return NotFound();
            }

            return View(grads_Of_Semestr);
        }

        // POST: Grads_Of_Semestr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grads_Of_Semestrs == null)
            {
                return Problem("Entity set 'ApplicationContext.Grads_Of_Semestrs'  is null.");
            }
            var grads_Of_Semestr = await _context.Grads_Of_Semestrs.FindAsync(id);
            if (grads_Of_Semestr != null)
            {
                _context.Grads_Of_Semestrs.Remove(grads_Of_Semestr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Grads_Of_SemestrExists(int id)
        {
          return _context.Grads_Of_Semestrs.Any(e => e.Grads_Of_Semestr_Id == id);
        }
    }
}
