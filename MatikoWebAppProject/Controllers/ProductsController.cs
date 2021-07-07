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


        public IActionResult Shirts(string sort="0", string gender="0", string color="0")
        {
            Color _color=Color.Black;
            switch (color) {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender=Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = from p in _context.Products where p.CategoriesId == 1 select p; //all
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }

            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.shirts = arr;
            ViewBag.shirtsLength = arr.Count;
            ViewBag.shirtsSort = sort;
            ViewBag.shirtsGender = gender;
            ViewBag.shirtsColor = color;
            return View();
        }

        public IActionResult Jeans(string sort = "0", string gender = "0", string color = "0")
        {
            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = from p in _context.Products where p.CategoriesId == 2 select p; //all
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }

            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.jeans = arr;
            ViewBag.jeansLength = arr.Count;
            ViewBag.jeansSort = sort;
            ViewBag.jeansGender = gender;
            ViewBag.jeansColor = color;
            return View();
        }

        public IActionResult Swimwear(string sort = "0", string gender = "0", string color = "0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = from p in _context.Products where p.CategoriesId == 6 select p; //all
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }

            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.swimwear = arr;
            ViewBag.swimwearLength = arr.Count;
            ViewBag.swimwearSort = sort;
            ViewBag.swimwearGender = gender;
            ViewBag.swimwearColor = color;
            return View();
        }

        public IActionResult Shorts(string sort = "0", string gender = "0", string color = "0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = from p in _context.Products where p.CategoriesId == 5 select p; //all
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }

            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.shorts = arr;
            ViewBag.shortsLength = arr.Count;
            ViewBag.shortsSort = sort;
            ViewBag.shortsGender = gender;
            ViewBag.shortsColor = color;
            return View();
        }

        public IActionResult Accessories(string sort = "0", string gender = "0", string color = "0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = from p in _context.Products where p.CategoriesId == 4 select p; //all
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }

            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.accessories = arr;
            ViewBag.accessoriesLength = arr.Count;
            ViewBag.accessoriesSort = sort;
            ViewBag.accessoriesGender = gender;
            ViewBag.accessoriesColor = color;
            return View();
        }

        public IActionResult Shoes(string sort = "0", string gender = "0", string color = "0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = from p in _context.Products where p.CategoriesId == 3 select p; //all
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }

            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.shoes = arr;
            ViewBag.shoesLength = arr.Count;
            ViewBag.shoesSort = sort;
            ViewBag.shoesGender = gender;
            ViewBag.shoesColor = color;
            return View();
        }

        public IActionResult New(string sort = "0", string gender = "0", string color = "0", string category="0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var s = (from p in _context.Products orderby p.Id descending select p).Take(18);
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }
            if (category != "0") 
            {
                s2 = from p in s where p.CategoriesId.ToString().Equals(category) select p;
                s = s2;
            }
            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.news = arr;
            ViewBag.newsLength = arr.Count;
            ViewBag.newsSort = sort;
            ViewBag.newsGender = gender;
            ViewBag.newsColor = color;
            ViewBag.newsCategory = category;
            return View();
        }

        public IActionResult Outlet(string sort = "0", string gender = "0", string color = "0", string category = "0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

           /* var s = from p in _context.Products
                    where
(p.Price < 20 & p.CategoriesId == 1)
| (p.Price < 44 & p.CategoriesId == 2)
| (p.Price < 52 & p.CategoriesId == 3)
| (p.Price < 8 & p.CategoriesId == 4)
| (p.Price < 44 & p.CategoriesId == 5)
| (p.Price < 28 & p.CategoriesId == 6)
                    select p;*/

            var items = from pro in _context.Products
                        group pro by pro.CategoriesId into prod
                        select new { CategoriesId = prod.Key, Min = prod.Min(p=>p.Price) };
            var s = from prd in _context.Products
                     join pro in items on prd.CategoriesId equals pro.CategoriesId
                     where prd.Price == pro.Min
                     select prd;

            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }
            if (category != "0")
            {
                s2 = from p in s where p.CategoriesId.ToString().Equals(category) select p;
                s = s2;
            }
            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.outlet = arr;
            ViewBag.outletLength = arr.Count;
            ViewBag.outletSort = sort;
            ViewBag.outletGender = gender;
            ViewBag.outletColor = color;
            ViewBag.outletCategory = category;
            return View();
        }

        public IActionResult Popular(string sort = "0", string gender = "0", string color = "0", string category = "0")
        {

            Color _color = Color.Black;
            switch (color)
            {
                case "4": _color = Color.Black; break;
                case "5": _color = Color.Blue; break;
                case "7": _color = Color.Green; break;
                case "10": _color = Color.Grey; break;
                case "11": _color = Color.Multi; break;
                case "8": _color = Color.Orange; break;
                case "9": _color = Color.Pink; break;
                case "3": _color = Color.Purple; break;
                case "1": _color = Color.Red; break;
                case "6": _color = Color.White; break;
                case "2": _color = Color.Yellow; break;
            }

            Gender _gender = Gender.Unisex;
            switch (gender)
            {
                case "1": _gender = Gender.Woman; break;
                case "2": _gender = Gender.Man; break;
                case "3": _gender = Gender.Unisex; break;
            }

            var items = from pro in _context.ProductsOrders
                     group pro by pro.ProductId into prod
                     select new { Id = prod.Key, Purc = prod.Count()};
            var s = (from prd in _context.Products
                    join pro in items on prd.Id equals pro.Id
                    where pro.Purc > 0
                    orderby pro.Purc
                    select prd).Take(6);
            var s2 = s;

            if (gender != "0")
            {
                s2 = from p in s where p.Gender == _gender select p;
                s = s2;
            }
            if (color != "0")
            {
                s2 = from p in s where p.color == _color select p;
                s = s2;
            }
            if (category != "0")
            {
                s2 = from p in s where p.CategoriesId.ToString().Equals(category) select p;
                s = s2;
            }
            switch (sort)
            {
                case "2": s2 = from p in s orderby p.Price descending select p; s = s2; break;
                case "3": s2 = from p in s orderby p.Price select p; s = s2; break;
                case "4": s2 = from p in s orderby p.Rate descending select p; s = s2; break;
            }

            ICollection<Products> arr = new Collection<Products>();
            foreach (var item in s)
            {
                arr.Add(item);
            }

            ViewBag.popular = arr;
            ViewBag.popularLength = arr.Count;
            ViewBag.popularSort = sort;
            ViewBag.popularGender = gender;
            ViewBag.popularColor = color;
            ViewBag.popularCategory = category;
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
        public async Task<IActionResult> Create([Bind("Id,Name,Price,color,CategoriesId,Gender,ImageUrl,Rate")] Products products)
        {
            var cat = from c in _context.Categories where c.Id == products.CategoriesId select c;
            products.Category = cat.First();
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
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
