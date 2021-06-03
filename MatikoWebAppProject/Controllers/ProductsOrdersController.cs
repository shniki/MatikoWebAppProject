using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatikoWebAppProject.Data;
using MatikoWebAppProject.Models;

namespace MatikoWebAppProject.Controllers
{
    public class ProductsOrdersController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;

        public ProductsOrdersController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: ProductsOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsOrders.ToListAsync());
        }

        // GET: ProductsOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsOrders = await _context.ProductsOrders
                .FirstOrDefaultAsync(m => m.ProductsOrdersId == id);
            if (productsOrders == null)
            {
                return NotFound();
            }

            return View(productsOrders);
        }

        // GET: ProductsOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductsOrdersId,Size,Amount")] ProductsOrders productsOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsOrders);
        }

        // GET: ProductsOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsOrders = await _context.ProductsOrders.FindAsync(id);
            if (productsOrders == null)
            {
                return NotFound();
            }
            return View(productsOrders);
        }

        // POST: ProductsOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductsOrdersId,Size,Amount")] ProductsOrders productsOrders)
        {
            if (id != productsOrders.ProductsOrdersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsOrdersExists(productsOrders.ProductsOrdersId))
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
            return View(productsOrders);
        }

        // GET: ProductsOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsOrders = await _context.ProductsOrders
                .FirstOrDefaultAsync(m => m.ProductsOrdersId == id);
            if (productsOrders == null)
            {
                return NotFound();
            }

            return View(productsOrders);
        }

        // POST: ProductsOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsOrders = await _context.ProductsOrders.FindAsync(id);
            _context.ProductsOrders.Remove(productsOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsOrdersExists(int id)
        {
            return _context.ProductsOrders.Any(e => e.ProductsOrdersId == id);
        }
    }
}
