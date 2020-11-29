using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public HomeController(IDepartmentService departmentService, IUserService userService, IRoleService roleService)
        {
            this.departmentService = departmentService;
            this.userService = userService;
            this.roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (LoginUser(model))
                {
                    User user = userService.GetByUsername(model.UserName);
                    List<Role> roles = userService.GetRoles(user.Id);

                    List<Privilege> privileges = new List<Privilege>();

                    if (roles?.Count > 0)
                    {
                        privileges = GetRolesPrivileges(roles);
                    }

                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName)
                    };

                    if (privileges?.Count > 0)
                    {
                        foreach (var priv in privileges)
                        {
                            claims.Add(new Claim(priv.Name, priv.Name));
                        }
                    }

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Panel");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }
            }
            return View(model);
        }

        private List<Privilege> GetRolesPrivileges(List<Role> roles)
        {
            List<Privilege> privileges = new List<Privilege>();
            foreach (var role in roles)
            {
                List<Privilege> privilegesFromService = roleService.GetPrivileges(role.Id);
                if (privileges.Count > 0)
                {
                    foreach (var privFromService in privilegesFromService)
                    {
                        if (privileges.Find(x => x.Id == privFromService.Id) == null)
                        {
                            privileges.Add(privFromService);
                        }
                    }
                }
                else
                {
                    privileges.AddRange(roleService.GetPrivileges(role.Id));
                }
            }
            return privileges;
        }

        private bool LoginUser(UserSignInViewModel model)
        {
            return userService.LoginUser(model.UserName, model.Password);
        }

        public IActionResult SignUp()
        {
            ViewBag.Departments = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userService.IsUsernameUnique(model.Username))
                {
                    User user = new User
                    {
                        Name = model.Name,
                        DepartmentId = model.DepartmentId > 0 ? model.DepartmentId : null,
                        Password = model.Password,
                        Surname = model.Surname,
                        Username = model.Username
                    };
                    userService.Add(user);

                    ViewBag.SuccessMessage = "Kullanıcınız başarılı bir şekilde kaydedildi";
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Bu isimde bir kullanıcı adı zaten var.");
                }
            }
            ViewBag.Departments = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View(model);
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ErrorMessage = exceptionHandler?.Error?.Message;

            return View();
        }

        public IActionResult StatusCodePage(int? code)
        {
            ViewBag.StatusCode = code;

            if (code == 404)
            {
                ViewBag.Message = "Aradığınız sayfa bulunamadı";
            }

            return View();
        }

        public JsonResult IsUsernameUnique(string username)
        {
            return Json(userService.IsUsernameUnique(username));
        }
    }
}
