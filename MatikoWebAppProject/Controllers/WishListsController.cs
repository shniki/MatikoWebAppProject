﻿using System;
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

        public WishListsController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: WishLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.WishList.ToListAsync());
        }

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

        //need to change the size to whatever the user put in his input box 
        public async Task<IActionResult> addToCartAsync(Products prod)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == this.HttpContext.User.Claims.ElementAt(1).Value);
            var cart = await _context.Orders
                .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value && m.status == Status.Cart);
            cart.FullPrice += prod.Price;
            _context.ProductsOrders.Add(new ProductsOrders { Amount = 1, Order = cart, OrderId = cart.Id, Product = prod, ProductId = prod.Id, Size = "S"});
            return RedirectToAction(nameof(Index));
        }

        private bool WishListExists(string id)
        {
            return _context.WishList.Any(e => e.UserEmail == id);
        }
    }
}
