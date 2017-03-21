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
    public class DataDetailsController : Controller
    {
        private readonly NameContext _context;

        public DataDetailsController(NameContext context)
        {
            _context = context;    
        }

        // GET: DataDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataDetail.ToListAsync());
        }

        // GET: DataDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataDetail = await _context.DataDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (dataDetail == null)
            {
                return NotFound();
            }

            return View(dataDetail);
        }

        // GET: DataDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataID,Goodsname,TotalSaleMoney,butprice,buynumber,salenumber,saleprice")] DataDetail dataDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dataDetail);
        }

        // GET: DataDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataDetail = await _context.DataDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (dataDetail == null)
            {
                return NotFound();
            }
            return View(dataDetail);
        }

        // POST: DataDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataID,Goodsname,TotalSaleMoney,butprice,buynumber,salenumber,saleprice")] DataDetail dataDetail)
        {
            if (id != dataDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataDetailExists(dataDetail.ID))
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
            return View(dataDetail);
        }

        // GET: DataDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataDetail = await _context.DataDetail.SingleOrDefaultAsync(m => m.ID == id);
            if (dataDetail == null)
            {
                return NotFound();
            }

            return View(dataDetail);
        }

        // POST: DataDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataDetail = await _context.DataDetail.SingleOrDefaultAsync(m => m.ID == id);
            _context.DataDetail.Remove(dataDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DataDetailExists(int id)
        {
            return _context.DataDetail.Any(e => e.ID == id);
        }
    }
}
