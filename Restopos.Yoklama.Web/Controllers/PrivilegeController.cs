using Microsoft.AspNetCore.Mvc;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
    public class PrivilegeController : Controller
    {
        private readonly IPrivilegeService privilegeService;
        public PrivilegeController(IPrivilegeService privilegeService)
        {
            this.privilegeService = privilegeService;
        }

        public IActionResult Index()
        {
            List<Privilege> privileges= privilegeService.GetAll();

            return View(privileges);
        }

        public IActionResult Update(int id)
        {
            Privilege privilege = privilegeService.GetById(id);

            return View(privilege);
        }

        [HttpPost]
        public IActionResult Update(Privilege model)
        {
            if (ModelState.IsValid)
            {
                privilegeService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
