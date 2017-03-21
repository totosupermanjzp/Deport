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
    public class OutGoodsController : Controller
    {
        private readonly NameContext _context;

        public OutGoodsController(NameContext context)
        {
            _context = context;    
        }

        // GET: OutGoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.OutGoods.ToListAsync());
        }

        // GET: OutGoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outGoods = await _context.OutGoods.SingleOrDefaultAsync(m => m.ID == id);
            if (outGoods == null)
            {
                return NotFound();
            }

            return View(outGoods);
        }

        private bool OutGoodsExists(int id)
        {
            return _context.OutGoods.Any(e => e.ID == id);
        }
    }
}
