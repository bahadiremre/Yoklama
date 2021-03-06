﻿using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = ConstPrivileges.ADD_ROLE)]
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

        [Authorize(Policy = ConstPrivileges.ADD_ROLE)]
        [HttpPost]
        public IActionResult Add(RoleWithPrivilegesViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (roleService.GetByName(model.Name) == null)
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
                else
                {
                    ModelState.AddModelError("", "Bu isimde bir rol zaten var.");
                }

            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            Role role = roleService.GetByIdWithDetails(id);
            RoleDetailsViewModel model = new RoleDetailsViewModel();
            model.Id = role.Id;
            model.Name = role.Name;
            model.RolePrivileges = role.RolePrivileges.OrderBy(x=>x.Privilege.Name).ToList();
            model.UserRoles = role.UserRoles;

            return View(model);
        }

        [Authorize(Policy = ConstPrivileges.UPDATE_ROLE)]
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

        [Authorize(Policy = ConstPrivileges.UPDATE_ROLE)]
        [HttpPost]
        public IActionResult Update(RoleWithPrivilegesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Role searchingRole = roleService.GetByName(model.Name);
                if (model.Name == searchingRole?.Name && model.Id != searchingRole?.Id)
                {
                    ModelState.AddModelError("", "Bu isimde başka bir rol zaten var");
                    return View(model);
                }
                else if (model.Name == ConstRoles.ADMIN)
                {
                    ModelState.AddModelError("", "Admin rolü değiştirelemez");
                    return View(model);
                }

                Role role = new Role
                {
                    Id = model.Id,
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

        [Authorize(Policy = ConstPrivileges.DELETE_ROLE)]
        public JsonResult Delete(int id)
        {
            try
            {
                if (roleService.GetById(id)?.Name != ConstRoles.ADMIN)
                {
                    roleService.Remove(new Role { Id = id });
                    return Json(null);
                }
                else
                {
                    return Json("Uyarı: Admin rolü silinemez");
                }
            }
            catch (Exception)
            {
                return Json("Hata");
            }

        }
    }
}
