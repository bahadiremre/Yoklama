using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Initializer
{
    public static class RoleInitializer
    {
        public static void SeedData(IPrivilegeService privilegeService, IRoleService roleService)
        {
            List<Role> roles = roleService.GetAll();
            ConstRoles constRoles = new ConstRoles();
            ConstUser constUser = new ConstUser();
            Role foundAdminRole = roles.Find(x => x.Name == constRoles.Admin.Name);
            List<Privilege> privileges = privilegeService.GetAll();


            if (foundAdminRole == null)
            {

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
            else
            {
                Role adminRoleWithDetails = roleService.GetByIdWithDetails(foundAdminRole.Id);
                List<RolePrivilege> adminRolePrivileges = adminRoleWithDetails.RolePrivileges;
                bool isPrivAddedToRole = false;

                if (adminRolePrivileges?.Count > 0)
                {
                    foreach (var priv in privileges)
                    {
                        if (!IsPrivInRolePrivileges(priv, adminRolePrivileges))
                        {
                            adminRolePrivileges.Add(new RolePrivilege
                            {
                                PrivilegeId = priv.Id
                            });
                            isPrivAddedToRole = true;
                        }
                    }
                }
                else
                {
                    adminRolePrivileges = new List<RolePrivilege>();
                    isPrivAddedToRole = true;
                    foreach (var item in privileges)
                    {
                        adminRolePrivileges.Add(new RolePrivilege
                        {
                            PrivilegeId = item.Id
                        });
                    }
                }
                if (isPrivAddedToRole)
                {
                    foundAdminRole.RolePrivileges = adminRolePrivileges;

                    roleService.Update(foundAdminRole);
                }
            }
        }

        private static bool IsPrivInRolePrivileges(Privilege privilege, List<RolePrivilege> rolePrivileges)
        {
            foreach (var rolePriv in rolePrivileges)
            {
                if (rolePriv.PrivilegeId == privilege.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
