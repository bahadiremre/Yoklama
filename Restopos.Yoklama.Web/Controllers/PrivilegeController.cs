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
    [Authorize(Policy = ConstPrivileges.LIST_PRIVILEGES)]
    public class PrivilegeController : Controller
    {
        private readonly IPrivilegeService privilegeService;
        public PrivilegeController(IPrivilegeService privilegeService)
        {
            this.privilegeService = privilegeService;
        }

        public IActionResult Index()
        {
            List<Privilege> privileges = privilegeService.GetAll();
            List<PrivilegeViewModel> model = new List<PrivilegeViewModel>();

            if (privileges?.Count > 0)
            {
                foreach (var item in privileges)
                {
                    model.Add(new PrivilegeViewModel
                    {
                        Description = item.Description,
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            Privilege privilege = privilegeService.GetById(id);
            PrivilegeViewModel model = new PrivilegeViewModel
            {
                Description = privilege.Description,
                Id = privilege.Id,
                Name = privilege.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(PrivilegeViewModel model)
        {
            if (ModelState.IsValid)
            {
                privilegeService.Update(new Privilege
                {
                    Description = model.Description,
                    Name = model.Name,
                    Id = model.Id
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
