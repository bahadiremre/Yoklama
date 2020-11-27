using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Initializer
{
    public static class UserRoleInitializer
    {
        public static void SeedData(IPrivilegeService privilegeService, IUserService userService, IRoleService roleService)
        {
            List<Role> roles = roleService.GetAll();
            ConstRoles constRoles = new ConstRoles();
            ConstUser constUser = new ConstUser();
            Role foundAdminRole = roles.Find(x => x.Name == constRoles.Admin.Name);

            if (foundAdminRole == null)
            {
                List<Privilege> privileges = privilegeService.GetAll();
                constRoles.Admin.RolePrivileges = new List<RolePrivilege>();
                foreach (var item in privileges)
                {
                    constRoles.Admin.RolePrivileges.Add(new RolePrivilege
                    {
                        PrivilegeId = item.Id
                    });
                }

                roleService.Add(constRoles.Admin);
                foundAdminRole = constRoles.Admin;
            }

            List<User> users = userService.GetByRoleName(constRoles.Admin.Name);

            if (users?.Count <= 0)
            {
                User user = new User();
                user.Name = constUser.AdminUser.Name;
                user.Surname = constUser.AdminUser.Surname;
                user.Username = constUser.AdminUser.Username;
                user.Password = constUser.AdminUser.Password;
                user.UserRoles = new List<UserRole>();
                user.UserRoles.Add(new UserRole { RoleId=foundAdminRole.Id });

                userService.Add(user); ;
            }

        }
    }
}
