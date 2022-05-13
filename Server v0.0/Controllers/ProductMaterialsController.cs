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
    public class ProductMaterialsController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductMaterialsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ProductMaterials
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ProductMaterial.Include(p => p.Material).Include(p => p.Product);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ProductMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductMaterial == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.ProductMaterial
                .Include(p => p.Material)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductMaterialId == id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            return View(productMaterial);
        }

        // GET: ProductMaterials/Create
        public IActionResult Create()
        {
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "MaterialId");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            return View();
        }

        // POST: ProductMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductMaterialId,Weight,ProductId,MaterialId")] ProductMaterial productMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "MaterialId", productMaterial.MaterialId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productMaterial.ProductId);
            return View(productMaterial);
        }

        // GET: ProductMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductMaterial == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.ProductMaterial.FindAsync(id);
            if (productMaterial == null)
            {
                return NotFound();
            }
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "MaterialId", productMaterial.MaterialId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productMaterial.ProductId);
            return View(productMaterial);
        }

        // POST: ProductMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductMaterialId,Weight,ProductId,MaterialId")] ProductMaterial productMaterial)
        {
            if (id != productMaterial.ProductMaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMaterialExists(productMaterial.ProductMaterialId))
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
            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "MaterialId", productMaterial.MaterialId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productMaterial.ProductId);
            return View(productMaterial);
        }

        // GET: ProductMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductMaterial == null)
            {
                return NotFound();
            }

            var productMaterial = await _context.ProductMaterial
                .Include(p => p.Material)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductMaterialId == id);
            if (productMaterial == null)
            {
                return NotFound();
            }

            return View(productMaterial);
        }

        // POST: ProductMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductMaterial == null)
            {
                return Problem("Entity set 'ApplicationContext.ProductMaterial'  is null.");
            }
            var productMaterial = await _context.ProductMaterial.FindAsync(id);
            if (productMaterial != null)
            {
                _context.ProductMaterial.Remove(productMaterial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMaterialExists(int id)
        {
          return _context.ProductMaterial.Any(e => e.ProductMaterialId == id);
        }
    }
}
