using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Entities.Concrete.Constants;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDAL roleDAL;
        private readonly IRolePrivilegeService rolePrivilegeService;
        public RoleManager(IRolePrivilegeService rolePrivilegeService, IRoleDAL roleDAL)
        {
            this.rolePrivilegeService = rolePrivilegeService;
            this.roleDAL = roleDAL;
        }
        public void Add(Role role)
        {
            roleDAL.Add(role);
        }

        public List<Role> GetAll()
        {
            return roleDAL.GetAll();
        }

        public Role GetById(int id)
        {
            return roleDAL.GetById(id);
        }

        public Role GetByIdWithDetails(int id)
        {
            return roleDAL.GetByIdWithDetails(id);
        }

        public Role GetByName(string roleName)
        {
            return roleDAL.GetByName(roleName);
        }

        public List<Privilege> GetPrivileges(int roleId)
        {
            return roleDAL.GetPrivileges(roleId);
        }

        public void Remove(Role role)
        {
            if (role.Name!=ConstRoles.ADMIN)
            {
                roleDAL.Remove(role);
            }
            else
            {
                throw new Exception("Admin rolü silinemez");
            }
            
        }

        public void Update(Role role)
        {
            rolePrivilegeService.RemoveByRoleId(role.Id);

            roleDAL.Update(role);
        }
    }
}
