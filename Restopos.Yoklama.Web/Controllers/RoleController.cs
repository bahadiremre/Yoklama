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
    public class RoleController : Controller
    {
        private readonly ICrudableService<Role> roleService;
        private readonly IPrivilegeService privilegeService;
        private readonly ICrudableService<RolePrivilege> rolePrivilegeService;

        public RoleController(ICrudableService<Role> roleService,
            IPrivilegeService privilegeService, ICrudableService<RolePrivilege> rolePrivilegeService)
        {
            this.roleService = roleService;
            this.privilegeService = privilegeService;
            this.rolePrivilegeService = rolePrivilegeService;
        }

        public IActionResult Index()
        {
            List<Role> roles = roleService.GetAll();
            List<RoleViewModel> model = new List<RoleViewModel>();

            if (roles?.Count > 0)
            {
                foreach (var item in roles)
                {
                    model.Add(new RoleViewModel
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }

            return View(model);
        }

        public IActionResult Add()
        {
            RoleWithPrivilegesViewModel model = new RoleWithPrivilegesViewModel();
            List<Privilege> privileges = privilegeService.GetAll();
            model.PrivilegesWithSelection = new List<PrivilegeSelectionViewModel>();

            if (privileges?.Count > 0)
            {
                foreach (var item in privileges)
                {
                    model.PrivilegesWithSelection.Add(new PrivilegeSelectionViewModel
                    {
                        Description = item.Description,
                        Id = item.Id,
                        Name = item.Name,
                        isSelected = false
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(RoleWithPrivilegesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role
                {
                    Name = model.Name
                };
                roleService.Add(role);


                List<PrivilegeSelectionViewModel> selectedPrivilegeModels = model.PrivilegesWithSelection.FindAll(x => x.isSelected);

                if (selectedPrivilegeModels?.Count > 0)
                {
                    List<Privilege> privileges = new List<Privilege>();

                    foreach (var item in selectedPrivilegeModels)
                    {
                        privileges.Add(new Privilege
                        {
                            Id=item.Id                            
                        });


                    }

                    rolePrivilegeService.Add(new RolePrivilege {  }
                        );
                }

                
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Role role = roleService.GetById(id);
            RoleDetailsViewModel model = new RoleDetailsViewModel();
            model.Id = role.Id;
            model.Name = role.Name;
            model.RolePrivileges = role.RolePrivileges;
            model.UserRoles = role.UserRoles;

            return View(model);
        }
    }
}
