using Microsoft.AspNetCore.Mvc;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
    public class AbsenceStatusController : Controller
    {
        private readonly IAbsenceStatusService absenceService;
        public AbsenceStatusController(IAbsenceStatusService absenceService)
        {
            this.absenceService = absenceService;
        }
        public IActionResult Index()
        {
            List<AbsenceStatus> absenceStatuses = absenceCrudService.GetAllByDate(DateTime.Now);

            return View();
        }
    }
}
