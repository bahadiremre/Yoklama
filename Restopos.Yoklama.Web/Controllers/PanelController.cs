using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    [Authorize]
    public class PanelController : Controller
    {
        private readonly IUserService userService;
        public PanelController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            var user = userService.GetByUsername(User.Identity.Name);

            UserSummaryViewModel model = new UserSummaryViewModel
            {
                Id = user.Id,
                Name = user?.Name,
                Surname = user?.Surname,
                Username = user?.Username,
                DepartmentName = user?.Department?.Name
            };

            return View(model);
        }

        public IActionResult ChangePassword(int id)
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.UserId = id;

            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userService.GetById(model.UserId);

                if (model.OldPassword.Equals(model.NewPassword))
                {
                    ModelState.AddModelError("", "Eski şifre ile yeni şifre aynı olamaz.");
                }
                if (!user.Password.Equals(model.OldPassword))
                {
                    ModelState.AddModelError("", "Eski şifrenizi yanlış girdiniz.");
                }

                if (ModelState.ErrorCount > 0)
                {
                    return View(model);
                }

                userService.ChangePassword(new User { Id = model.UserId, Password = model.NewPassword });
                ViewBag.SuccessMessage = "Şifreniz değiştirildi";
                return View();
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
