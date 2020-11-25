using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ICrudableService<Department> departmentService;
        public DepartmentController(ICrudableService<Department> departmentService)
        {
            this.departmentService = departmentService;
        }

        public ActionResult Index()
        {
            List<Department> departments = departmentService.GetAll();
            List<DepartmentViewModel> model = new List<DepartmentViewModel>();
            foreach (var item in departments)
            {
                model.Add(new DepartmentViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return View(model);
        }

        public ActionResult Add()
        {
            return View(new DepartmentViewModel());
        }

        [HttpPost]
        public ActionResult Add(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                departmentService.Add(new Department { Name = model.Name });

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public ActionResult Update(int id)
        {
            var department = departmentService.GetById(id);
            DepartmentViewModel model = new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                departmentService.Update(new Department
                {
                    Id = model.Id,
                    Name = model.Name
                });
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public JsonResult Delete(int id)
        {
            departmentService.Remove(new Department { Id = id });
            return Json(null);
        }
    }
}
