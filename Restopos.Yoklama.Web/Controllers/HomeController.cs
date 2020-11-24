using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        private readonly ICrudableService<User> userCrudService;
        private readonly ICrudableService<Department> departmentCrudService;
        private readonly IUserService userService;

        public HomeController(ICrudableService<User> userCrudService,
            ICrudableService<Department> departmentCrudService, IUserService userService)
        {
            this.userCrudService = userCrudService;
            this.departmentCrudService = departmentCrudService;
            this.userService = userService;
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
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.UserName),
                        new Claim(ClaimTypes.NameIdentifier,model.UserName)
                    };
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
        private bool LoginUser(UserSignInViewModel model)
        {
            return userService.LoginUser(model.UserName, model.Password);
        }

        public IActionResult SignUp()
        {
            ViewBag.Departments = new SelectList(departmentCrudService.GetAll(), "Id", "Name");
            return View(new UserSignUpViewModel());
        }

        [HttpPost]
        public IActionResult SignUp(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    DepartmentId = model.DepartmentId > 0 ? model.DepartmentId : null,
                    Password = model.Password,
                    Surname = model.Surname,
                    Username = model.Username
                };
                userCrudService.Add(user);

                ViewBag.SuccessMessage = "Kullanıcınız başarılı bir şekilde kaydedildi";
                return View();
            }
            return View(model);
        }
    }
}
