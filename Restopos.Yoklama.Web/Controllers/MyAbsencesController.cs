using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class MyAbsencesController : Controller
    {
        private readonly IAbsenceStatusService absenceService;
        private readonly IUserService userService;
        public MyAbsencesController(IAbsenceStatusService absenceService, IUserService userService)
        {
            this.absenceService = absenceService;
            this.userService = userService;
        }

        public IActionResult Index(AbsenceStatusesByDateViewModel model)
        {
            User user = userService.GetByUsername(User.Identity.Name);
            ViewData["User"] = user.Name + " " + user.Surname;

            if (ModelState.IsValid)
            {
                if (model.SearchingStartDate == DateTime.MinValue)
                {
                    model.SearchingStartDate = DateTime.Now.Date;
                }
                if (model.SearchingEndDate == DateTime.MinValue)
                {
                    model.SearchingEndDate = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                }

                List<AbsenceStatus> absenceStatuses =
                    absenceService.GetByDate(model.SearchingStartDate, model.SearchingEndDate, user.Id);

                model.absenceStatuses = new List<AbsenceStatusViewModel>();
                if (absenceStatuses?.Count > 0)
                {
                    foreach (var item in absenceStatuses)
                    {
                        model.absenceStatuses.Add(new AbsenceStatusViewModel
                        {
                            AbsenceType = item.AbsenceType,
                            EndDate = item.EndDate,
                            Id = item.Id,
                            StartDate = item.StartDate,
                            User = item.User
                        });
                    }
                }
            }

            return View(model);
        }
    }
}
