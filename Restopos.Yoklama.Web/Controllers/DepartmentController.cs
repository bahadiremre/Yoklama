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
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
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

        [Authorize(Policy = ConstPrivileges.ADD_DEPARTMENT)]
        public ActionResult Add()
        {
            return View(new DepartmentViewModel());
        }

        [Authorize(Policy = ConstPrivileges.ADD_DEPARTMENT)]
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

        [Authorize(Policy = ConstPrivileges.UPDATE_DEPARTMENT)]
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

        [Authorize(Policy = ConstPrivileges.UPDATE_DEPARTMENT)]
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

        [Authorize(Policy = ConstPrivileges.DELETE_DEPARTMENT)]
        public JsonResult Delete(int id)
        {
            departmentService.Remove(new Department { Id = id });
            return Json(null);
        }
    }
}
