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
    public class ReviewsController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;

        public ReviewsController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,UserEmail,Title,Describtion,Rate")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                var r = from c in _context.Reviews where c.ProductId == reviews.ProductId select c;
                int num = r.Count();

                _context.Add(reviews);

                double oldSum = (_context.Products.Find(reviews.ProductId).Rate) * num;
                _context.Products.Find(reviews.ProductId).Rate = (oldSum + reviews.Rate) / (num + 1);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviews);
        }

        public async Task<IActionResult> Submitted(int id, string title, string desc, int rate)
        {
            if (HttpContext.User != null && HttpContext.User.Claims != null && HttpContext.User.Claims.Count() > 0)
            {
                Reviews rev = new Reviews();
                rev.ProductId = id;
                rev.UserEmail = HttpContext.User.Claims.ElementAt(1).Value; 
                rev.Title = title;
                rev.Describtion = desc;
                rev.Rate = rate;
                _context.Reviews.Add(rev);
                _context.SaveChanges();

                var r = from c in _context.Reviews where c.ProductId == id select c;
                int num = r.Count();

                double oldSum = (_context.Products.Find(id).Rate) * (num - 1);
                _context.Products.Find(id).Rate = (oldSum + rate) / num;
                _context.SaveChanges();

                return View(rev);
            }
            else
                return RedirectToAction("Login","Users");
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,UserEmail,Title,Describtion,Rate")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
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
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
