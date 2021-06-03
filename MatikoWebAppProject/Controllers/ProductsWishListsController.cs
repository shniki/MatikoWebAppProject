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
    public class ProductsWishListsController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;

        public ProductsWishListsController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: ProductsWishLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductsWishList.ToListAsync());
        }

        // GET: ProductsWishLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsWishList = await _context.ProductsWishList
                .FirstOrDefaultAsync(m => m.ProductsWishListId == id);
            if (productsWishList == null)
            {
                return NotFound();
            }

            return View(productsWishList);
        }

        // GET: ProductsWishLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductsWishLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductsWishListId,Size")] ProductsWishList productsWishList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productsWishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productsWishList);
        }

        // GET: ProductsWishLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsWishList = await _context.ProductsWishList.FindAsync(id);
            if (productsWishList == null)
            {
                return NotFound();
            }
            return View(productsWishList);
        }

        // POST: ProductsWishLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductsWishListId,Size")] ProductsWishList productsWishList)
        {
            if (id != productsWishList.ProductsWishListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productsWishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsWishListExists(productsWishList.ProductsWishListId))
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
            return View(productsWishList);
        }

        // GET: ProductsWishLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productsWishList = await _context.ProductsWishList
                .FirstOrDefaultAsync(m => m.ProductsWishListId == id);
            if (productsWishList == null)
            {
                return NotFound();
            }

            return View(productsWishList);
        }

        // POST: ProductsWishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productsWishList = await _context.ProductsWishList.FindAsync(id);
            _context.ProductsWishList.Remove(productsWishList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsWishListExists(int id)
        {
            return _context.ProductsWishList.Any(e => e.ProductsWishListId == id);
        }
    }
}
