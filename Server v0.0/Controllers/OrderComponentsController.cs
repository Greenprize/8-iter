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
    public class OrderComponentsController : Controller
    {
        private readonly ApplicationContext _context;

        public OrderComponentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: OrderComponents
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.OrderComponent.Include(o => o.Product).Include(o => o.Sale);
            return View(await applicationContext.ToListAsync());
        }

        // GET: OrderComponents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderComponent == null)
            {
                return NotFound();
            }

            var orderComponent = await _context.OrderComponent
                .Include(o => o.Product)
                .Include(o => o.Sale)
                .FirstOrDefaultAsync(m => m.OrderComponentId == id);
            if (orderComponent == null)
            {
                return NotFound();
            }

            return View(orderComponent);
        }

        // GET: OrderComponents/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId");
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "SaleId", "SaleId");
            return View();
        }

        // POST: OrderComponents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderComponentId,Quanity,SaleId,ProductId")] OrderComponent orderComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", orderComponent.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "SaleId", "SaleId", orderComponent.SaleId);
            return View(orderComponent);
        }

        // GET: OrderComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderComponent == null)
            {
                return NotFound();
            }

            var orderComponent = await _context.OrderComponent.FindAsync(id);
            if (orderComponent == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", orderComponent.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "SaleId", "SaleId", orderComponent.SaleId);
            return View(orderComponent);
        }

        // POST: OrderComponents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderComponentId,Quanity,SaleId,ProductId")] OrderComponent orderComponent)
        {
            if (id != orderComponent.OrderComponentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderComponentExists(orderComponent.OrderComponentId))
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
            ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "ProductId", "ProductId", orderComponent.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Set<Sale>(), "SaleId", "SaleId", orderComponent.SaleId);
            return View(orderComponent);
        }

        // GET: OrderComponents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderComponent == null)
            {
                return NotFound();
            }

            var orderComponent = await _context.OrderComponent
                .Include(o => o.Product)
                .Include(o => o.Sale)
                .FirstOrDefaultAsync(m => m.OrderComponentId == id);
            if (orderComponent == null)
            {
                return NotFound();
            }

            return View(orderComponent);
        }

        // POST: OrderComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderComponent == null)
            {
                return Problem("Entity set 'ApplicationContext.OrderComponent'  is null.");
            }
            var orderComponent = await _context.OrderComponent.FindAsync(id);
            if (orderComponent != null)
            {
                _context.OrderComponent.Remove(orderComponent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderComponentExists(int id)
        {
          return _context.OrderComponent.Any(e => e.OrderComponentId == id);
        }
    }
}
