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
    public class UserController : Controller
    {
        private readonly ICrudableService<User> crudService;
        public UserController(ICrudableService<User> crudService)
        {
            this.crudService = crudService;
        }

        public IActionResult Index()
        {
            List<User> users = crudService.GetAll();
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
                //Kullaniciya ait rolleri getir
                List<UserRole> userRoles = item.UserRoles?.FindAll(x => x.UserId == item.Id);
                if (userRoles != null)
                {
                    foreach (var userrole in userRoles)
                    {
                        modelItem.Roles.Add(userrole.Role);
                    }
                }

                model.Add(modelItem);
            }

            return View(model);
        }
    }
}
