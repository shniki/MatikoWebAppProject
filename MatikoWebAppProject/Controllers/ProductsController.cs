using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatikoWebAppProject.Data;
using MatikoWebAppProject.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MatikoWebAppProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;

        public ProductsController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            var q = from c in _context.Categories where c.Id == products.CategoriesId select c;
            ViewBag.productscategoryName = q.First().Name;
            ViewBag.productscategorySizes= q.First().Sizes;
            ViewBag.rate = int.Parse(products.Rate.ToString());

            return View(products);
        }

        public IActionResult Shirts()
        {
            var q = from p in _context.Products where p.CategoriesId==1 select p;
            ViewBag.shirts = q.ToListAsync();

            return View();
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,color,Category,Gender,ImageUrl,Rate")] Products products)
        {
            if (ModelState.IsValid)
            {
                products.CategoriesId = products.Category.Id;
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }


        public async Task<IActionResult> Search(string name)
        {
            var q = from a in _context.Products.Include(a => a.Category)
                    where (a.Name.Contains(name))
                    select a;
            return View("Index", await q.ToListAsync());
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,color,CategoriesId,Category,Gender,ImageUrl,Rate")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public ActionResult Statistics()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Statistics()
        {
            //statistic 1- how many orders every customer had made, there is only one shopping cart
            ICollection < Stat > statistic1 = new Collection<Stat>();
            var result1 = from c in _context.Users.Include(o => o.AllOrdersMade)
                          where (c.AllOrdersMade.Count) > 0
                          orderby (c.AllOrdersMade.Count) descending
                          select c;
            foreach (var v in result1)
            {
                statistic1.Add(new Stat(v.FirstName + " "  + v.LastName, v.AllOrdersMade.Count()));
            }

            ViewBag.data = statistic1;
            //finish first statistic
            //statistic 2- which brand the customers prefer to order
            ICollection<Stat> statistic2 = new Collection<Stat>();

            var result2 = new int[12];//create empty result table
            for (int i = 0; i < 12; i++)
                result2[i] = 0;

            var products = new List<Products>();
            foreach (var p in _context.Products)
                products.Add(p);
            foreach (var pro in _context.ProductsOrders)
            {
                result2[(int)products.Find(m => m.Id == pro.ProductId).color]+= pro.Amount;
            }
            for (int i = 0; i < result2.Length; i++)
           {  
               if(result2[i] > 0)
                statistic2.Add(new Stat(((Color)i).ToString(),result2[i]));   
           }

            ViewBag.data2 = statistic2;

            return View();
        }
        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        internal class ResultPair
        {
            public string Color { get; set; }
            public int count { get; set; }
        }
    }
}
    public class Stat
    {
        public string Key;
        public int Values;
        public Stat(string key, int values)
        {
            Key = key;
            Values = values;
        }
    }
