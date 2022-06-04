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
    public class ProductDetailsController : Controller
    {
        readonly AppDbContext _context;
        public ProductDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductDetailsList()
        {
            var list = await _context.ProductDetails.Where(x=> x.Status != DataStatus.Deleted!).Include(x => x.Product).ToListAsync();

            return View(list);
        }



        public async Task<IActionResult> Create()
        {
            var model = await _context.Products.Where(x => x.Status != DataStatus.Deleted!).OrderByDescending(x=> x.Id).ToListAsync();

            var details = new ProductDetails();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] ProductDetails details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            await _context.ProductDetails.AddAsync(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductDetailsList", "ProductDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var details = await _context.ProductDetails.FindAsync(id);
            var model = await _context.Products.ToListAsync();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] ProductDetails details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            details.Status = DataStatus.Updated;
            details.ModifatedDate = DateTime.Now;
            _context.ProductDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductDetailsList", "ProductDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var details = _context.ProductDetails.Find(id);

            //_context.ProductDetails.Remove(details);

            details.Status = DataStatus.Deleted;
            details.ModifatedDate = DateTime.Now;
            _context.ProductDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductDetailsList", "ProductDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _context.ProductDetails.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
    }
}
