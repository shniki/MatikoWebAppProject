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
    public class OrdersController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;
        public static string idu;

        public OrdersController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }


        [Authorize]
        [HttpGet]

        // GET: Cart2 for remove
        public async Task<IActionResult> Cart2(int id)
        {
            int ddd = 100;
            var q = from u in _context.Orders
                    where u.UserEmail.CompareTo(idu) == 0
                    select u.Id;


            var h = from u in _context.ProductsOrders
                    where u.OrderId.CompareTo(q.First()) == 0
                    select u;

            ProductsOrders[] productsOrders = h.ToArray();
            List<ProductsOrders> list = h.ToList();
            for (int i = 0; i < productsOrders.Length; i++)
            {
                if (productsOrders[i].ProductId == id)
                {
                    list.Remove(productsOrders[i]);
                    _context.ProductsOrders.Remove(productsOrders[i]);
                    _context.SaveChanges();


                    break;
                }
            }
            //
            ViewBag.popo = productsOrders;
            List<Products> list2 = new List<Products>();
            int[] productsid = new int[h.Count()];
            for (int i = 0; i < productsid.Length; i++)
                productsid[i] = productsOrders[i].ProductId;

            for (int i = 0; i < h.Count(); i++)
            {
                foreach (var line in _context.Products)
                {
                    if (productsid[i] == line.Id)
                        list2.Add(line);
                }
            }

            //  return View(Cart(idu));

            return Redirect("~/Orders/Cart/" + idu);
        }

        [Authorize]
        [HttpGet]

        // GET: Cart3 for checkout 
        public IActionResult Cart3(float total)
        {
            var j = from u in _context.Orders
                    where u.UserEmail.CompareTo(idu) == 0
                    select u;
            j.First().FullPrice = total;

            var user = from u in _context.Users where u.Email.CompareTo(j.First().UserEmail) == 0 select u;
            user.First().AllOrdersMade.Add(j.First());


            /*       var q = from u in _context.Orders
                           where u.UserEmail.CompareTo(idu) == 0
                           select u.Id;


                   var h = from u in _context.ProductsOrders
                           where u.OrderId.CompareTo(q.First()) == 0
                           select u;

                   ProductsOrders[] productsOrders = h.ToArray();

                   for(int i=0; i<productsOrders.Length;i++)
                   {
                       _context.ProductsOrders.Find(productsOrders[i]).Size = size[i];
                       _context.ProductsOrders.Find(productsOrders[i]).Amount = foo[i];
                   }

                   */
            _context.SaveChanges();

            //return View();
            return RedirectToAction(nameof(Index), "Home");
            // change to thank you page
        }






















        [Authorize]
        [HttpGet]

        // GET: Cart
        public async Task<IActionResult> Cart(string id)
        {
            /* if (HttpContext.Session.GetString("email") != null)
                 return RedirectToAction("Login","Users");*/
            // return View("Cart" ,await _context.Orders.Where(a => a.Id.Equals(id)).ToListAsync());

            // var orders =  _context.Orders.FirstOrDefaultAsync(m => m.Id.CompareTo(id) == 0 && m.status == Status.Cart);


            /*
             var posts = await _applicationDbContext.Posts
                  .Include(p => p.Account)
                  .Include(p => p.Recording)
                  .Where(p => p.AccountId == accountId && p.Type == postType)
                  .Where(Post.IsValid)
                  .OrderByDesceding(p => p.Occured)
                   .ToListAsync();
          */




            var q = from u in _context.Orders
                    where u.UserEmail.CompareTo(id) == 0
                    select u.Id;


            var h = from u in _context.ProductsOrders
                    where u.OrderId.CompareTo(q.First()) == 0
                    select u;

            ProductsOrders[] productsOrders = h.ToArray();
            //
            //ViewBag["popo"] = productsOrders;
            ViewBag.popo = productsOrders;
            //
            List<Products> list = new List<Products>();

            int[] productsid = new int[h.Count()];
            for (int i = 0; i < productsid.Length; i++)
                productsid[i] = productsOrders[i].ProductId;







            for (int i = 0; i < h.Count(); i++)
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

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserEmail,status,FullPrice,DateOrder,EstimatedDateArrival")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserEmail,status,FullPrice,DateOrder,EstimatedDateArrival")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //need to change the size to whatever the user put in his input box 
        public async Task<IActionResult> AddToCartAsync(Products prod)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == this.HttpContext.User.Claims.ElementAt(1).Value);
            var cart = await _context.Orders
                .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value && m.status == Status.Cart);
            cart.FullPrice += prod.Price;
            _context.ProductsOrders.Add(new ProductsOrders { Amount = 1, Order = cart, OrderId = cart.Id, Product = prod, ProductId = prod.Id, Size = "S" });
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveFromCartAsync(Products prod)
        {
            var cart = await _context.Orders
                .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value && m.status == Status.Cart);
            if (cart != null)
            {
                ProductsOrders po = _context.ProductsOrders.Find(cart.UserEmail, prod.Id);
                cart.FullPrice -= po.Product.Price * po.Amount;
                _context.ProductsOrders.Remove(po);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
