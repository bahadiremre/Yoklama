using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
using Restopos.Yoklama.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
    [Authorize(Policy = ConstPrivileges.LIST_ABSENCETYPES)]
    public class AbsenceTypeController : Controller
    {
        private readonly IAbsenceTypeService absenceTypeService;
        private readonly IAbsenceStatusService absenceStatusService;
        public AbsenceTypeController(IAbsenceTypeService absenceTypeService, IAbsenceStatusService absenceStatusService)
        {
            this.absenceTypeService = absenceTypeService;
            this.absenceStatusService = absenceStatusService;
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

        [Authorize(Policy = ConstPrivileges.ADD_ABSENCETYPE)]
        public IActionResult Add()
        {
            return View(new AbsenceTypeViewModel());
        }

        [Authorize(Policy = ConstPrivileges.ADD_ABSENCETYPE)]
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

        [Authorize(Policy = ConstPrivileges.UPDATE_ABSENCETYPE)]
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

        [Authorize(Policy = ConstPrivileges.UPDATE_ABSENCETYPE)]
        [HttpPost]
        public IActionResult Update(AbsenceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                absenceTypeService.Update(new AbsenceType
                {
                    Id = model.Id,
                    IsHourly = model.IsHourly,
                    Name = model.Name
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Policy = ConstPrivileges.DELETE_ABSENCETYPE)]
        public JsonResult Delete(int id)
        {
            try
            {
                if (absenceStatusService.GetByType(id)?.Count == 0)
                {
                    absenceTypeService.Remove(new AbsenceType { Id = id });
                }
                else
                {
                    return Json("Uyarı: Bu devamsızlık türüne ait yoklama kaydı olduğu için işlem gerçekleştirilemiyor!");
                }

                return Json(null);
            }
            catch (Exception ex)
            {
                return Json("Hata");
            }

        }
    }
}
