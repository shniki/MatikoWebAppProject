using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatikoWebAppProject.Data;
using MatikoWebAppProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MatikoWebAppProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly MatikoWebAppProjectContext _context;

        public UsersController(MatikoWebAppProjectContext context)
        {
            _context = context;
        }

     
        public IActionResult InfoAndPersonalOrders()
        {
            return View();
        }
        public IActionResult PersonalArea()
        {
            return View();
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("FirstName,Email,PhoneNumber,Address,City,Country,ZipCode")] Users users)
        {
            /* if (id != users.Email)
             {
                 return NotFound();
             }*/

            /// users.LastName = "Samuel";
            ///users.Password = "hagayh11";

         _context.Attach(users);


         _context.Entry(users).Property(p => p.FirstName).IsModified = true;
           // _context.Entry(users).Property(p => p.Email).IsModified = true;
            _context.Entry(users).Property(p => p.Address).IsModified = true;
         _context.Entry(users).Property(p => p.PhoneNumber).IsModified = true;
         _context.Entry(users).Property(p => p.ZipCode).IsModified = true;
         _context.Entry(users).Property(p => p.City).IsModified = true;
         _context.Entry(users).Property(p => p.Country).IsModified = true;
         _context.Entry(users).Property(p => p.LastName).IsModified = users.LastName != null;
         _context.Entry(users).Property(p => p.Password).IsModified = users.Password != null;



         _context.SaveChanges();

            return RedirectToAction(nameof(Index), "Home");







            //  if (ModelState.IsValid)
            //  {
            try
            {
                   _context.Update(users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.Email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
            //    }
                return RedirectToAction(nameof(Index));
            }
            //return View(users);
            return RedirectToAction(nameof(Index), "Home");

        }



        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        private bool UsersExists(string id)
        {
            return _context.Users.Any(e => e.Email == id);
        }

        //GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult EditUser()
        {
            return View();
        }

        public IActionResult EditAddressBook()
        {
            return View();
        }

        public IActionResult AddressBook()
        {
            return View();
        }


        // POST: Users/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Email,FirstName,LastName,Birthday,ZipCode,PhoneNumber,Address,City,Country,Password")] Users user)
        {
            if (ModelState.IsValid)
            {
                var q = _context.Users.FirstOrDefault(u => u.Email == user.Email);

                if (q == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();

                    var u = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                    Signin(u);

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewData["Error"] = "Unable to comply; cannot register this user.";
                }
            }
            return View(user);
        }
        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email,Password")] Users users)
        {
            //var q = _context.Users.FirstOrDefault(u => u.Email == users.Email && u.Password == users.Password);
            var q = from u in _context.Users
                    where u.Email == users.Email && u.Password == users.Password
                    select u;
            if (q.Count() > 0)
            {
                /*HttpContext.Session.SetString("Email", q.First().Email);
                HttpContext.Session.SetString("Name", q.First().FirstName + " " + q.First().LastName);
                */
                Signin(q.First());

                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                ViewData["Error"] = "Username and/or password are incorrect.";
            }
            return View(users);
        }

        private async void Signin(Users account)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.FirstName + " " + account.LastName),
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.MobilePhone, account.PhoneNumber),
                    new Claim(ClaimTypes.Role, account.Type.ToString()),
                    new Claim(ClaimTypes.StreetAddress, account.Address),
                    new Claim(ClaimTypes.StateOrProvince, account.City),
                    new Claim(ClaimTypes.PostalCode, account.ZipCode.ToString()),
                    new Claim(ClaimTypes.Country, account.Country),

                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
