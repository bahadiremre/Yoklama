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
    public class AbsenceTypeController : Controller
    {
        private readonly ICrudableService<AbsenceType> absenceTypeService;

        public AbsenceTypeController(ICrudableService<AbsenceType> absenceTypeService)
        {
            this.absenceTypeService = absenceTypeService;
        }

        public IActionResult Index()
        {
            List<AbsenceType> absenceTypes = absenceTypeService.GetAll();
            List<AbsenceTypeViewModel> model = new List<AbsenceTypeViewModel>();

            if (absenceTypes?.Count > 0)
            {
                foreach (var item in absenceTypes)
                {
                    model.Add(new AbsenceTypeViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        IsHourly = item.IsHourly
                    });
                }
            }

            return View(model);
        }

        public IActionResult Add()
        {
            return View(new AbsenceTypeViewModel());
        }

        [HttpPost]
        public IActionResult Add(AbsenceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                AbsenceType absenceType = new AbsenceType
                {
                    Name = model.Name,
                    IsHourly = model.IsHourly
                };

                absenceTypeService.Add(absenceType);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            AbsenceType absenceType = absenceTypeService.GetById(id);

            AbsenceTypeViewModel model = new AbsenceTypeViewModel
            {
                Id = absenceType.Id,
                IsHourly = absenceType.IsHourly,
                Name = absenceType.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AbsenceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                absenceTypeService.Update(new AbsenceType
                {
                    Id=model.Id,
                    IsHourly=model.IsHourly,
                    Name=model.Name
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public JsonResult Delete(int id)
        {
            absenceTypeService.Remove(new AbsenceType { Id = id });
            return Json(null);
        }
    }
}
