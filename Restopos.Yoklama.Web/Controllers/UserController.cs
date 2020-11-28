using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    [Authorize(Policy = ConstPrivileges.LIST_USERS)]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly ICrudableService<Department> departmentService;
        public UserController(IUserService userService,
            IRoleService roleService,
            ICrudableService<Department> departmentService)
        {
            this.userService = userService;
            this.roleService = roleService;
            this.departmentService = departmentService;
        }

        public IActionResult Index()
        {
            List<User> users = userService.GetAll();
            List<UserListViewModel> model = new List<UserListViewModel>();
            foreach (var item in users)
            {
                UserListViewModel modelItem = new UserListViewModel
                {
                    Department = item.Department,
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Username = item.Username
                };

                model.Add(modelItem);
            }

            return View(model);
        }

        public ActionResult Details(int id)
        {
            User user = userService.GetByIdWithDetails(id);

            UserDetailsViewModel model = new UserDetailsViewModel();
            model.AbsenceStatuses = user.AbsenceStatuses;
            model.Department = user.Department;
            model.Id = user.Id;
            model.Name = user.Name;
            model.Surname = user.Surname;
            model.Username = user.Username;
            model.Roles = user.UserRoles?.Count > 0 ? SetUserRolestoRoleList(user.UserRoles) : null;

            return View(model);
        }

        [Authorize(Policy = ConstPrivileges.UPDATE_USER)]
        public ActionResult Update(int id)
        {
            User user = userService.GetByIdWithDetails(id);
            RoleSelectionViewModel roleModel = new RoleSelectionViewModel();
            List<Role> roles = roleService.GetAll();
            ViewBag.Departments = new SelectList(departmentService.GetAll(), "Id", "Name");

            UserWithRoleSelectViewModel model = new UserWithRoleSelectViewModel
            {
                Department = user.Department,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username
            };

            model.RoleSelections = new List<RoleSelectionViewModel>();
            foreach (var item in roles)
            {
                model.RoleSelections.Add(new RoleSelectionViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    isSelected = user.UserRoles?.FirstOrDefault(x => x.RoleId == item.Id) != null
                });
            }

            return View(model);
        }

        [Authorize(Policy = ConstPrivileges.UPDATE_USER)]
        [HttpPost]
        public ActionResult Update(UserWithRoleSelectViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (IsUserNameValid(model.Id,model.Username))
                {
                    User user = new User
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Surname = model.Surname,
                        Username = model.Username,
                        DepartmentId = model.Department?.Id > 0 ? (int?)model.Department.Id : null
                    };

                    model.RoleSelections = model.RoleSelections.FindAll(x => x.isSelected);

                    user.UserRoles = new List<UserRole>();
                    if (model.RoleSelections?.Count > 0)
                    {

                        foreach (var item in model.RoleSelections)
                        {
                            user.UserRoles.Add(new UserRole
                            {
                                RoleId = item.Id
                            });
                        }
                    }

                    userService.Update(user);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Bu isimde bir kullanıcı adı zaten var.");
                }
               
            }
            return View(model);
        }


        [Authorize(Policy = ConstPrivileges.DELETE_USER)]
        public JsonResult Delete(int id)
        {
            userService.Remove(new User { Id = id });
            return Json(null);
        }


        public JsonResult IsUsernameUnique(int userId, string username)
        {
            return Json(IsUserNameValid(userId, username));
        }

        private bool IsUserNameValid(int userId, string username)
        {
            if (userService.IsUsernameUnique(username))
            {
                return true;
            }
            else if (userService.GetById(userId)?.Username==username)
            {
                return true;
            }
            return false;
        }

        private List<Role> SetUserRolestoRoleList(List<UserRole> userRoles)
        {
            List<Role> roles = new List<Role>();
            foreach (var item in userRoles)
            {
                roles.Add(item.Role);
            }

            return roles;
        }
    }
}
