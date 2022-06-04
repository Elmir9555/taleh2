using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Entities;
using BackendLahiye.UniteOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BackendLahiye.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SubcribeController : Controller
    {
        readonly IUow _uow;
        readonly IWebHostEnvironment _env;
        public SubcribeController(IUow uow, IWebHostEnvironment env)
        {
            _uow = uow;
            _env = env;
        }

        public async Task<IActionResult> SubcribeList()
        {
            var list = await _uow.GetRepository<Subcribe>().GetAllOrderByAsync(x => x.Id, false);

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subcribe model)
        {
            if (!ModelState.IsValid)
                return View();
           
            await _uow.GetRepository<Subcribe>().CreateAsync(model);
            await _uow.SaveChangeAsync();

            return RedirectToAction("SubcribeList", "Subcribe", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Update(int id)
        {
            var entity = await _uow.GetRepository<Subcribe>().FindAsync(id);
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Subcribe model)
        {
            var Dbentity = await _uow.GetRepository<Subcribe>().FindAsync(id);
            
            Dbentity.Email = model.Email;
            Dbentity.Status = DataStatus.Updated;
            Dbentity.ModifatedDate = DateTime.Now;

            await _uow.SaveChangeAsync();
            return RedirectToAction("SubcribeList", "Subcribe", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _uow.GetRepository<Subcribe>().FindAsync(id);
            if (entity == null) return NotFound();
            
            //_uow.GetRepository<Category>().Delete(entity);

            entity.Status = DataStatus.Deleted;
            entity.ModifatedDate = DateTime.Now;
            await _uow.SaveChangeAsync();

            return RedirectToAction("SubcribeList", "Subcribe", new { area = "AdminPanel" });
        }

        public async Task<IActionResult> Details(int id)
        {
            var entity = await _uow.GetRepository<Subcribe>().FindAsync(id);
            return View(entity);
        }
    }
}
