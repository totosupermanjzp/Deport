using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Depot.Data;
using Depot.Models;
using Microsoft.AspNetCore.Identity;

namespace Depot.Controllers
{
    public class PersonController : Controller
    {
        private readonly NameContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PersonController(NameContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;    
        }

        // GET: Person
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var user = User.Identity.Name;
            if (user == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            var username = _userManager.FindByNameAsync(user).Result;
            var temp = username.PhoneNumber;
            if(user == null||(temp != "kcct" &&temp != "qnop"))
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DepartmentIDSortParam"] = sortOrder == "Date" ? "date_dec" : "Date";
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var persons = from p in _context.Persons
                          select p;
            if(!String.IsNullOrEmpty(searchString))
            {
                persons = persons.Where(p => p.PersonName.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "Date":
                    persons = persons.OrderBy(p => p.DepartmentId);
                    break;
                case "date_dec":
                    persons = persons.OrderByDescending(p => p.DepartmentId);
                    break;
                default:
                    persons = persons.OrderBy(p => p.DepartmentId);
                    break;
            }
            int pageSize = 5;
            if (page < 1)
            {
                page = 1;
            }
            return View(await SelectList<Person>.CreateAsync(persons.AsNoTracking(), page ?? 1, pageSize));
            //return View(await persons.AsNoTracking().ToListAsync());
            //return View(await _context.Persons.ToListAsync());
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,DepartmentId,PersonManage,PersonName,Power")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonID,DepartmentId,PersonManage,PersonName,Power")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.SingleOrDefaultAsync(m => m.PersonID == id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonID == id);
        }
    }
}
