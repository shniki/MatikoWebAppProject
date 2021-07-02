using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatikoWebAppProject.Data;
using MatikoWebAppProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace MatikoWebAppProject.Controllers
{
    [Authorize]
    public class WishListsController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;
        public static string idu;


        public WishListsController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: WishLists
      /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.WishList.ToListAsync());
        } */

        // GET: WishLists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishList
                .FirstOrDefaultAsync(m => m.UserEmail == id);
            if (wishList == null)
            {
                return NotFound();
            }

            return View(wishList);
        }

        // GET: WishLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserEmail,Counter")] WishList wishList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishList);
        }

        // GET: WishLists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishList.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }
            return View(wishList);
        }

        // POST: WishLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserEmail,Counter")] WishList wishList)
        {
            if (id != wishList.UserEmail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishListExists(wishList.UserEmail))
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
            return View(wishList);
        }

        // GET: WishLists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishList
                .FirstOrDefaultAsync(m => m.UserEmail == id);
            if (wishList == null)
            {
                return NotFound();
            }

            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var wishList = await _context.WishList.FindAsync(id);
            _context.WishList.Remove(wishList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        /*remember to change in both addToCart and addToWishlist the size, according to user input */
        public async Task<IActionResult> AddToWishListAsync(Products prod)
        {
            var wishlist = await _context.WishList
                .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value);
            if (wishlist == null)
                _context.WishList.Add(wishlist = new WishList { UserEmail = this.HttpContext.User.Claims.ElementAt(1).Value, Counter = 0 });
            _context.ProductsWishList.Add(new ProductsWishList { UserEmail = this.HttpContext.User.Claims.ElementAt(1).Value, Product = prod, ProductId = prod.Id, Size = "S" , Wishlist = wishlist});
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveFromWishListAsync(Products prod)
        {
            var wishlist = await _context.WishList
                .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value);
            if(wishlist != null)
            {
                _context.ProductsWishList.Remove(new ProductsWishList { Product = prod, ProductId = prod.Id, Size = "S", UserEmail = this.HttpContext.User.Claims.ElementAt(1).Value, Wishlist = wishlist });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool WishListExists(string id)
        {
            return _context.WishList.Any(e => e.UserEmail == id);
        }


        [Authorize]
        [HttpGet]

        // GET: Whishlist
        public async Task<IActionResult> Index(string id)
        {

            var q = from u in _context.ProductsWishList
                    where u.UserEmail.CompareTo(id) == 0
                    select u;


        
            ProductsWishList[] productswishlist = q.ToArray();
            
            ViewBag.popo = productswishlist;
        
            List<Products> list = new List<Products>();

            int[] productsid = new int[q.Count()];
            for (int i = 0; i < productsid.Length; i++)
                productsid[i] = productswishlist[i].ProductId;







            for (int i = 0; i < q.Count(); i++)
            {
                foreach (var line in _context.Products)
                {
                    if (productsid[i] == line.Id)
                        list.Add(line);
                }
            }


            idu = id;

            //  return View(h);
            //return View(h.ToList());

            return View(list);

        }

    }
}
