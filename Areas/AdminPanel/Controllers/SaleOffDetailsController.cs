using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Context;
using BackendLahiye.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendLahiye.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SaleOffDetailsController : Controller
    {
        readonly AppDbContext _context;
        public SaleOffDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> SaleOffDetails()
        {
            var list = await _context.SaleOffDetails.Where(x => x.Status == DataStatus.Deleted!).Include(x => x.SaleOff).ToListAsync();

            return View(list);
        }


        public async Task<IActionResult> Create()
        {
            var model = await _context.SaleOffs.Where(x => x.Status == DataStatus.Deleted!).ToListAsync();

            var details = new SaleOffDetails();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] SaleOffDetails details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            await _context.SaleOffDetails.AddAsync(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("SaleOffDetailsList", "SaleOffDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var details = await _context.SaleOffDetails.FindAsync(id);
            var model = await _context.SaleOffs.ToListAsync();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] SaleOffDetails details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            details.Status = DataStatus.Updated;
            details.ModifatedDate = DateTime.Now;
            _context.SaleOffDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("SaleOffDetailsList", "SaleOffDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var details = _context.SaleOffDetails.Find(id);

            //_context.ProductDetails.Remove(details);

            details.Status = DataStatus.Deleted;
            details.ModifatedDate = DateTime.Now;
            _context.SaleOffDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("SaleOffDetailsList", "SaleOffDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _context.SaleOffDetails.Include(x => x.SaleOff).FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
    }
}
