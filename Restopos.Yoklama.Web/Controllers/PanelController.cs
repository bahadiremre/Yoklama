using Microsoft.AspNetCore.Mvc;
using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Controllers
{
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

            UserDetailViewModel model = new UserDetailViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                DepartmentName = user.Department?.Name
            };

            return View(model);
        }
    }
}
