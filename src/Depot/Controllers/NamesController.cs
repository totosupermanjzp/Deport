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
    public class NamesController : Controller
    {
        private readonly NameContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
       // private OutGoods _outGood;

        public NamesController(NameContext context, UserManager<ApplicationUser> userManager /*OutGoods outGood*/)
        {
            _userManager = userManager;
            _context = context;
            //_outGood = outGood;
        }

        // GET: Names
        /*
         * sortOrder:排序的方法:name_des、date_des、Date
         * searchString:搜索字符
         * page:页码
         * currentFilter:中间值作用，刷新时重新还原到对话框中
         */
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int ?page)
        {
            var user = User.Identity.Name;
            if(user == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            var username = _userManager.FindByNameAsync(user).Result;
            var temp = username.PhoneNumber;
            if (username == null || (temp != "kcct" && temp != "qnop" && temp !="itfu"))
            {
                return RedirectToAction(nameof(Index), "Home");
            }                          
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_des" : " ";
            ViewData["DataSortParm"] = sortOrder == "Date" ? "date_des" : "Date";
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            ViewData["CurrentFilter"] = searchString;
            var names = from n in _context.Names
                        select n;
            if(!String.IsNullOrEmpty(searchString))
            {
                names = names.Where(n => n.Goods.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_des":
                    names = names.OrderByDescending(n => n.number);
                    break;
                case "Date":
                    names = names.OrderBy(n => n.EnrollmentDate);
                    break;
                case "date_des":
                    names = names.OrderByDescending(n => n.EnrollmentDate);
                    break;
                default:
                    names = names.OrderBy(n => n.number);
                    break;
            }
            int pageSize = 5;
            if(page < 1 )
            {
                page = 1;
            }
            //return View(await _context.Names.ToListAsync());
            //return View(await names.AsNoTracking().ToListAsync());
            return View(await SelectList<Name>.CreateAsync(names.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Names/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var name = await _context.Names
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Git)
                .AsNoTracking()
                //.FirstOrDefaultAsync();
                .SingleOrDefaultAsync(m => m.ID == id);
            if (name == null)
            {
                return NotFound();
            }

            return View(name);
        }

        // GET: Names/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Names/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Goods,number,location,price")] Name name)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    name.EnrollmentDate = DateTime.Now;
                    _context.Add(name);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("","Error");
            }
            return View(name);
        }

        // GET: Names/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var name = await _context.Names.SingleOrDefaultAsync(m => m.ID == id);
            if (name == null)
            {
                return NotFound();
            }
            return View(name);
        }

        // POST: Names/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EnrollmentDate,Goods,number")] Name name)
        {
            if (id != name.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(name);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NameExists(name.ID))
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
            return View(name);
        }

        // GET: Names/Delete/5
        public async Task<IActionResult> Delete(int? id,bool ? saveChangeError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var name = await _context.Names.SingleOrDefaultAsync(m => m.ID == id);
            if (name == null)
            {
                return NotFound();
            }
            if(saveChangeError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete fail";
            }
            return View(name);
        }

        // POST: Names/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var name = await _context.Names.SingleOrDefaultAsync(m => m.ID == id);
            _context.Names.Remove(name);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NameExists(int id)
        {
            return _context.Names.Any(e => e.ID == id);
        }

        public async Task<IActionResult> OutGoods(int? id)
        {
            var goods = await _context.Names.SingleOrDefaultAsync(m => m.ID == id);
            var username = User.Identity.Name;
            if(goods ==null)
            {
                return NotFound();
            }
            var outgoods = new OutGoods
            {
                EnrollmentDate = DateTime.Now,
                //ID = goods.ID,
                location = goods.location,
                Goods = goods.Goods,
                number = goods.number,
                personname = username,
                price = (goods.price + 2)
            };
            _context.OutGoods.Add(outgoods);
            await _context.SaveChangesAsync();
            var name = await _context.Names.SingleOrDefaultAsync(m => m.ID == id);
            _context.Names.Remove(name);
            await _context.SaveChangesAsync();

            //return RedirectToAction("Index");
            return View();
        }
    }
    //SaveChange方法发出INSERT语句
}
