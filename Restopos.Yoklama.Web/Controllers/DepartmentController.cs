using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
using Restopos.Yoklama.Web.Models;
using System.Collections.Generic;

namespace Restopos.Yoklama.Web.Controllers
{
    [Authorize(Policy = ConstPrivileges.LIST_DEPARTMENTS)]
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
