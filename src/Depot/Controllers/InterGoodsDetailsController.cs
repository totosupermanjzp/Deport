using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Depot.Data;
using Depot.Models;

namespace Depot.Controllers
{
    public class InterGoodsDetailsController : Controller
    {
        private readonly NameContext _context;

        public InterGoodsDetailsController(NameContext context)
        {
            _context = context;    
        }

        // GET: InterGoodsDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.InterGoodsDetail.ToListAsync());
        }

        // GET: InterGoodsDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interGoodsDetail = await _context.InterGoodsDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (interGoodsDetail == null)
            {
                return NotFound();
            }

            return View(interGoodsDetail);
        }

        // GET: InterGoodsDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterGoodsDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,goodsName,interBookID,number,saleID,salemanName,price")] InterGoodsDetail interGoodsDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interGoodsDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(interGoodsDetail);
        }

        // GET: InterGoodsDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interGoodsDetail = await _context.InterGoodsDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (interGoodsDetail == null)
            {
                return NotFound();
            }
            return View(interGoodsDetail);
        }

        // POST: InterGoodsDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,goodsName,interBookID,number,saleID,salemanName")] InterGoodsDetail interGoodsDetail)
        {
            if (id != interGoodsDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interGoodsDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterGoodsDetailExists(interGoodsDetail.ID))
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
            return View(interGoodsDetail);
        }

        // GET: InterGoodsDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interGoodsDetail = await _context.InterGoodsDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (interGoodsDetail == null)
            {
                return NotFound();
            }

            return View(interGoodsDetail);
        }

        // POST: InterGoodsDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interGoodsDetail = await _context.InterGoodsDetail.SingleOrDefaultAsync(m => m.ID == id);
            _context.InterGoodsDetail.Remove(interGoodsDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> InGoods(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var interGoodsDetail = await _context.InterGoodsDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (interGoodsDetail == null)
            {
                return NotFound();
            }
            return View(interGoodsDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InGoods(int? id,[Bind("ID,goodsName,interBookID,number,saleID,salemanName,price")] InterGoodsDetail interGoodsDetail)
        {
            try
            {
                var username = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    var intergoods =  new Name
                    {
                        EnrollmentDate = DateTime.Now,
                        Goods = interGoodsDetail.goodsName,
                        GoodsRFID = interGoodsDetail.interBookID,
                        number = interGoodsDetail.number,
                        price = interGoodsDetail.price,
                        InterPerson = username,
                    };
                    _context.Names.Add(intergoods);
                    await _context.SaveChangesAsync();
                    var name = await _context.InterGoodsDetail.SingleOrDefaultAsync(m => m.ID == id);
                    _context.InterGoodsDetail.Remove(name);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(interGoodsDetail);
        }

        private bool InterGoodsDetailExists(int id)
        {
            return _context.InterGoodsDetail.Any(e => e.ID == id);
        }
    }
}
