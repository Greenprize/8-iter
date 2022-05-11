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
    public class Time_ssController : Controller
    {
        private readonly ApplicationContext _context;

        public Time_ssController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Time_ss
        public async Task<IActionResult> Index()
        {
              return View(await _context.Time_sss.ToListAsync());
        }

        // GET: Time_ss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Time_sss == null)
            {
                return NotFound();
            }

            var time_ss = await _context.Time_sss
                .FirstOrDefaultAsync(m => m.ID_Time == id);
            if (time_ss == null)
            {
                return NotFound();
            }

            return View(time_ss);
        }

        // GET: Time_ss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Time_ss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Time,Time_Lecture,Time_Work,Time_Labor,Id_Sem,Id_Subj")] Time_ss time_ss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(time_ss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(time_ss);
        }

        // GET: Time_ss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Time_sss == null)
            {
                return NotFound();
            }

            var time_ss = await _context.Time_sss.FindAsync(id);
            if (time_ss == null)
            {
                return NotFound();
            }
            return View(time_ss);
        }

        // POST: Time_ss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Time,Time_Lecture,Time_Work,Time_Labor,Id_Sem,Id_Subj")] Time_ss time_ss)
        {
            if (id != time_ss.ID_Time)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(time_ss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Time_ssExists(time_ss.ID_Time))
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
            return View(time_ss);
        }

        // GET: Time_ss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Time_sss == null)
            {
                return NotFound();
            }

            var time_ss = await _context.Time_sss
                .FirstOrDefaultAsync(m => m.ID_Time == id);
            if (time_ss == null)
            {
                return NotFound();
            }

            return View(time_ss);
        }

        // POST: Time_ss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Time_sss == null)
            {
                return Problem("Entity set 'ApplicationContext.Time_sss'  is null.");
            }
            var time_ss = await _context.Time_sss.FindAsync(id);
            if (time_ss != null)
            {
                _context.Time_sss.Remove(time_ss);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Time_ssExists(int id)
        {
          return _context.Time_sss.Any(e => e.ID_Time == id);
        }
    }
}
