using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Initializer
{
    public static class UserInitializer
    {
        public static void SeedData(IUserService userService, IRoleService roleService)
        {

            List<User> users = userService.GetByRoleName(ConstRoles.ADMIN);

            //Admin rolüne sahip kullanıcı yoksa
            if (users?.Count <= 0)
            {
                User user = new User();
                user.Name = ConstUser.NAME;
                user.Surname = ConstUser.SURNAME;
                user.Username = ConstUser.USERNAME;
                user.Password = ConstUser.PASSWORD;
                user.UserRoles = new List<UserRole>();
                user.UserRoles.Add(new UserRole { RoleId = roleService.GetByName(ConstRoles.ADMIN).Id });

                userService.Add(user); ;
            }
        }
    }
}
