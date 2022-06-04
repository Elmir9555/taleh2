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
    public class BlogDetailsController : Controller
    {
        readonly AppDbContext _context;
        public BlogDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> BlogDetailsList()
        {
            var list = await _context.BlogDetails.Where(x => x.Status == DataStatus.Deleted!).Include(x => x.Blog).ToListAsync();

            return View(list);
        }


        public async Task<IActionResult> Create()
        {
            var model = await _context.Blogs.Where(x => x.Status == DataStatus.Deleted!).ToListAsync();

            var details = new BlogDetails();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] BlogDetails details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            await _context.BlogDetails.AddAsync(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("BlogDetailsList", "BlogDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var details = await _context.BlogDetails.FindAsync(id);
            var model = await _context.Blogs.Where(x=> x.Status == DataStatus.Deleted!).ToListAsync();

            return View((details, model));
        }
        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] BlogDetails details)
        {
            if (!ModelState.IsValid)
            {
                return View(details);
            }
            details.Status = DataStatus.Updated;
            details.ModifatedDate = DateTime.Now;
            _context.BlogDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("BlogDetailsList", "BlogDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var details = _context.BlogDetails.Find(id);

            //_context.ProductDetails.Remove(details);

            details.Status = DataStatus.Deleted;
            details.ModifatedDate = DateTime.Now;
            _context.BlogDetails.Update(details);
            await _context.SaveChangesAsync();

            return RedirectToAction("BlogDetailsList", "BlogDetails", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var details = await _context.BlogDetails.Include(x => x.Blog).FirstOrDefaultAsync(x => x.Id == id);
            return View(details);
        }
    }
}
