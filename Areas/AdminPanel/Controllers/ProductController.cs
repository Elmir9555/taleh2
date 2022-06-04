using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Context;
using BackendLahiye.Entities;
using BackendLahiye.UniteOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BackendLahiye.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        readonly IUow _uow;
        readonly IWebHostEnvironment _env;
        readonly AppDbContext _context;
        public ProductController(IUow uow, IWebHostEnvironment env, AppDbContext context)
        {
            _uow = uow;
            _env = env;
            _context = context;
        }

        public async Task<IActionResult> ProductList()
        {
            var list = await _context.Products.Where(x => x.Status != DataStatus.Deleted).Include(x => x.Category).OrderByDescending(x => x.Id).ToListAsync();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var list = await _uow.GetRepository<Category>().GetAllOrderByAsync(x => x.Id, false);

            return View((new Product(), list));
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] Product model)
        {
            if (!ModelState.IsValid)
                return View();
            if (!model.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View();
            }


            string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/product", fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await model.Photo.CopyToAsync(stream);
            }
            model.Image = fileName;

            await _uow.GetRepository<Product>().CreateAsync(model);
            await _uow.SaveChangeAsync();

            return RedirectToAction("ProductList", "Product", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = await _uow.GetRepository<Product>().FindAsync(id);
            var list = await _uow.GetRepository<Category>().GetAllOrderByAsync(x => x.Id, false);
            return View((category, list));
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, [Bind(Prefix = "Item1")] Product model)
        {
            var Dbentity = await _uow.GetRepository<Product>().FindAsync(id);

            if (!ModelState.IsValid) return View(model);

            if (!model.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("", "Sekil formatinda bir fayl secin.");
                return View(model);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/product", Dbentity.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "AdminPanel/img/product", fileName);
            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await model.Photo.CopyToAsync(stream);
            }

            Dbentity.Image = fileName;
            Dbentity.Name = model.Name;
            Dbentity.Status = DataStatus.Updated;
            Dbentity.ModifatedDate = DateTime.Now;
            Dbentity.CategoryId = model.CategoryId;

            await _uow.SaveChangeAsync();
            return RedirectToAction("ProductList", "Product", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _uow.GetRepository<Product>().FindAsync(id);
            if (entity == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "AdminPanel/img/product", entity.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            //_uow.GetRepository<Category>().Delete(entity);

            entity.Image = string.Empty;
            entity.Status = DataStatus.Deleted;
            entity.ModifatedDate = DateTime.Now;
            
            await _uow.SaveChangeAsync();

            return RedirectToAction("ProductList", "Product", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.Products.Include(x => x.Category).OrderByDescending(x => x.Id).FirstOrDefaultAsync(x=> x.Id==id);

            return View(entity);
        }
    }
}
