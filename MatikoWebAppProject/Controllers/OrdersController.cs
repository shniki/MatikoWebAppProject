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
        public async Task<IActionResult> Index(string userEmail = null)
        {
            if (userEmail != null)
            {
                var orders = from o in _context.Orders where o.UserEmail.CompareTo(userEmail) == 0 select o;
                return View(await orders.ToListAsync());
            }
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
        public void Cart2(int id)
        {
            //int ddd = 100;
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




        }

        [Authorize]
        [HttpGet]

        // GET: Cart3 for checkout 
        public IActionResult Cart3(float total, string id)
        {

            //save the order in DB

            var order = from o in _context.Orders where (o.UserEmail == HttpContext.User.Claims.ElementAt(1).Value && o.status == Status.Cart) select o;
            order.First().status = Status.Paid;
            order.First().DateOrder = DateTime.Today;
            order.First().EstimatedDateArrival = DateTime.Today.AddDays(14);
            _context.Users.Find(HttpContext.User.Claims.ElementAt(1).Value).AllOrdersMade.Add(order.First());
            _context.Orders.Add(new Orders() { status = Status.Cart, DateOrder = DateTime.Today, EstimatedDateArrival = DateTime.Today.AddDays(14), FullPrice = 0, Products = new List<ProductsOrders>(), UserEmail = HttpContext.User.Claims.ElementAt(1).Value });
            _context.SaveChanges();

            var j = from u in _context.Orders
                    where u.UserEmail.CompareTo(idu) == 0
                    select u;
            j.First().FullPrice = total;


            string[] vs = new string[2];
            vs[0] = id;
            ViewBag.kkk = vs;

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
            return View();
            // change to thank you page
        }























        [Authorize]
        [HttpGet]

        // GET: Cart
        public async Task<IActionResult> Cart(int? products, int isAddition = -1, string size = "", int isFromWishlist = 0, string discount= "")
        {
            if (products.HasValue && isAddition == 1)
            {
                var user = _context.Users.Include(o => o.AllOrdersMade).ThenInclude(po => po.Products).Where(c => c.Email == HttpContext.User.Claims.ElementAt(1).Value).FirstOrDefault();
                var Product = _context.Products.Find(products);
                var ShoppingCart = from o in _context.Orders.Include(o => o.Products) where (o.UserEmail == HttpContext.User.Claims.ElementAt(1).Value && o.status == Status.Cart) select o;
                if (ShoppingCart.First().Products == null)
                    ShoppingCart.First().Products = new List<ProductsOrders>();
                if (ShoppingCart.First().Products.Where(p => p.ProductId == products).FirstOrDefault() != null)
                {

                    if (ShoppingCart.First().Products.Where(p => p.ProductId == products && p.Size == size).FirstOrDefault() != null && ShoppingCart.First().Products.Where(p => p.ProductId == products && p.Size == size).FirstOrDefault().Amount >= 1)
                    {
                        ShoppingCart.First().Products.Where(p => p.ProductId == products).FirstOrDefault().Amount += 1;
                        _context.ProductsOrders.Update(ShoppingCart.First().Products.Where(p => p.ProductId == products).FirstOrDefault());
                        ShoppingCart.First().FullPrice += Product.Price;
                        _context.SaveChanges();
                        _context.Orders.Update(ShoppingCart.First());
                        _context.SaveChanges();
                    }
                    else
                    {
                        return View("DifferentSize");
                    }
                }
                else
                {
                    ShoppingCart.First().Products.Add(new ProductsOrders() { ProductId = (int)products, Product = _context.Products.Find(products), Order = ShoppingCart.First(), Amount = 1, OrderId = ShoppingCart.First().Id, Size = size });

                    ShoppingCart.First().FullPrice += Product.Price;
                    _context.Orders.Update(ShoppingCart.First());
                    _context.SaveChanges();
                }

                if (isFromWishlist == 1)
                {
                    var pw = from p in _context.ProductsWishList where (p.ProductId == products && p.UserEmail == HttpContext.User.Claims.ElementAt(1).Value) select p;
                    _context.ProductsWishList.Remove(pw.First());
                    _context.SaveChanges();
                }

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else if (products.HasValue && isAddition == 0)
            {
                var cart2 = await _context.Orders
               .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value && m.status == Status.Cart);
                if (cart2 != null)
                {
                    ProductsOrders po = _context.ProductsOrders.FirstOrDefault(p => p.ProductId == products && p.OrderId == cart2.Id);
                    Products p = _context.Products.FirstOrDefault(p => p.Id == po.ProductId);
                    cart2.FullPrice -= p.Price * po.Amount;
                    cart2.Products.Remove(po);
                    _context.ProductsOrders.Remove(po);
                    _context.Update(cart2);
                    _context.SaveChanges();
                }
            }

            var q = from u in _context.Orders
                    where (u.UserEmail.CompareTo(this.HttpContext.User.Claims.ElementAt(1).Value) == 0 && u.status == Status.Cart)
                    select u.Id;

            ViewBag.pp = q.First().ToString();

            var cart3 = from u in _context.Orders
                        where (u.UserEmail.CompareTo(this.HttpContext.User.Claims.ElementAt(1).Value) == 0 && u.status == Status.Cart)
                        select u;

            var sum = 0.0;
            var ps = (from po in _context.ProductsOrders where po.OrderId == cart3.First().Id select po).ToList();
            foreach (var item in ps)
            {
                var prod = from p in _context.Products where p.Id == item.ProductId select p;
                sum += item.Amount * prod.First().Price;
            }
            ViewBag.subtotal = sum;

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


            idu = this.HttpContext.User.Claims.ElementAt(1).Value;

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
        //public async Task<IActionResult> RemoveFromCartAsync(Products prod)
        //{
        //    var cart = await _context.Orders
        //        .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value && m.status == Status.Cart);
        //    if (cart != null)
        //    {
        //        ProductsOrders po = _context.ProductsOrders.Find(cart.UserEmail, prod.Id);
        //        cart.FullPrice -= po.Product.Price * po.Amount;
        //        _context.ProductsOrders.Remove(po);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}




/*              if (HttpContext.User == null || HttpContext.User.Claims == null || HttpContext.User.Claims.Count == 0)
          {
              return View("Login", "Users");
          }
          if (products.HasValue && isAddition == 1)
          {
              var prod = await _context.Products.FirstOrDefaultAsync(m => m.Id == products);
              var user = await _context.Users
                  .FirstOrDefaultAsync(m => m.Email == this.HttpContext.User.Claims.ElementAt(1).Value);
              var cart1 = await _context.Orders
                  .FirstOrDefaultAsync(m => m.UserEmail == this.HttpContext.User.Claims.ElementAt(1).Value && m.status == Status.Cart);
              cart1.FullPrice += prod.Price;
              if (cart1.Products.Find(p => p.ProductId == products) != null)
              {
                  cart1.Products.Find(m => m.ProductId == products).Amount++;
              }
              else
              {
                  cart1.Products.Add(new ProductsOrders { Amount = 1, Order = cart1, OrderId = cart1.Id, Product = prod, ProductId = prod.Id, Size = size });
                  _context.ProductsOrders.Add(new ProductsOrders { Amount = 1, Order = cart1, OrderId = cart1.Id, Product = prod, ProductId = prod.Id, Size = size });
              }
              _context.Update(cart1);
              _context.SaveChanges();
          }
*/