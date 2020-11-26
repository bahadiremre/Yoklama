﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
    public class AbsenceStatusController : Controller
    {
        private readonly IAbsenceStatusService absenceService;
        private readonly IUserService userService;
        private readonly ICrudableService<AbsenceType> absenceTypeCrudService;
        public AbsenceStatusController(IAbsenceStatusService absenceService,
            IUserService userService, ICrudableService<AbsenceType> absenceTypeCrudService)
        {
            this.absenceService = absenceService;
            this.userService = userService;
            this.absenceTypeCrudService = absenceTypeCrudService;
        }

        public IActionResult Index()
        {
            List<AbsenceStatus> absenceStatuses = absenceService.GetAllByDate(DateTime.Now);

            List<AbsenceStatusViewModel> model = new List<AbsenceStatusViewModel>();

            if (absenceStatuses?.Count > 0)
            {
                foreach (var item in absenceStatuses)
                {
                    model.Add(new AbsenceStatusViewModel
                    {
                        AbsenceType = item.AbsenceType,
                        EndDate = item.EndDate,
                        Id = item.Id,
                        StartDate = item.StartDate,
                        User = item.User
                    });
                }
            }

            return View(model);
        }

        public IActionResult Add()
        {
            AbsenceStatusViewModel model =
                new AbsenceStatusViewModel { StartDate = DateTime.Now.Date.AddHours(8), EndDate = DateTime.Now.Date.AddHours(18) };
            ViewBag.AbsenceTypes = new SelectList(absenceTypeCrudService.GetAll(), "Id", "Name");

            ViewBag.Users = new SelectList((from u in userService.GetAll()
                                            select new
                                            {
                                                u.Id,
                                                FullName = u.Name + " " + u.Surname
                                            }), "Id", "FullName");

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AbsenceStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                AbsenceStatus absenceStatus = new AbsenceStatus()
                {
                    AbsenceTypeId = model.AbsenceType.Id,
                    EndDate = model.EndDate,
                    StartDate = model.StartDate,
                    UserId = model.User.Id
                };

                absenceService.Add(absenceStatus);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}