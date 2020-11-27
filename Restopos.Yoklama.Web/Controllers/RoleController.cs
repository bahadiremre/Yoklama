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
    [Authorize(Policy = ConstPrivileges.LIST_ROLES)]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly IPrivilegeService privilegeService;

        public RoleController(IRoleService roleService, IPrivilegeService privilegeService)
        {
            this.roleService = roleService;
            this.privilegeService = privilegeService;
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

                List<PrivilegeSelectionViewModel> selectedPrivilegeModels =
                    model.PrivilegesWithSelection.FindAll(x => x.isSelected);

                if (selectedPrivilegeModels?.Count > 0)
                {
                    List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();

                    foreach (var item in selectedPrivilegeModels)
                    {
                        rolePrivileges.Add(new RolePrivilege { PrivilegeId = item.Id });
                    }

                    role.RolePrivileges = rolePrivileges;
                }

                roleService.Add(role);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Role role = roleService.GetByIdWithDetails(id);
            RoleDetailsViewModel model = new RoleDetailsViewModel();
            model.Id = role.Id;
            model.Name = role.Name;
            model.RolePrivileges = role.RolePrivileges;
            model.UserRoles = role.UserRoles;

            return View(model);
        }

        public IActionResult Update(int id)
        {
            Role role = roleService.GetByIdWithDetails(id);

            RoleWithPrivilegesViewModel model = new RoleWithPrivilegesViewModel();
            model.Id = role.Id;
            model.Name = role.Name;

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
                        isSelected = role.RolePrivileges?.FirstOrDefault(x => x.PrivilegeId == item.Id) != null
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(RoleWithPrivilegesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Role role = new Role
                {
                    Id=model.Id,
                    Name = model.Name
                };

                List<PrivilegeSelectionViewModel> selectedPrivilegeModels =
                    model.PrivilegesWithSelection.FindAll(x => x.isSelected);

                if (selectedPrivilegeModels?.Count > 0)
                {
                    List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();

                    foreach (var item in selectedPrivilegeModels)
                    {
                        rolePrivileges.Add(new RolePrivilege { PrivilegeId = item.Id });
                    }

                    role.RolePrivileges = rolePrivileges;
                }

                roleService.Update(role);


                return RedirectToAction("Index");
            }
            return View(model);
        }

        public JsonResult Delete(int id)
        {
            roleService.Remove(new Role { Id = id });
            return Json(null);
        }
    }
}
