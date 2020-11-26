using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class RoleManager : IRoleService, ICrudableService<Role>
    {
        private readonly ICrudableDAL<Role> crudableDAL;
        private readonly IRoleDAL roleDAL;
        private readonly IRolePrivilegeService rolePrivilegeService;
        public RoleManager(ICrudableDAL<Role> crudableDAL, IRolePrivilegeService rolePrivilegeService, IRoleDAL roleDAL)
        {
            this.crudableDAL = crudableDAL;
            this.rolePrivilegeService = rolePrivilegeService;
            this.roleDAL = roleDAL;
        }
        public void Add(Role role)
        {
            crudableDAL.Add(role);
            //List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();

            //if (role.RolePrivileges?.Count > 0)
            //{
            //    foreach (var item in role.RolePrivileges)
            //    {
            //        rolePrivileges.Add(new RolePrivilege { RoleId = role.Id, PrivilegeId = item.PrivilegeId });
            //    }
            //    rolePrivilegeService.AddRange(rolePrivileges);
            //}
        }

        public List<Role> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public Role GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public Role GetByIdWithDetails(int id)
        {
            return roleDAL.GetByIdWithDetails(id);
        }

        public void Remove(Role role)
        {
            crudableDAL.Remove(role);
        }

        public void Update(Role role)
        {   
            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();

            if (role.RolePrivileges?.Count > 0)
            {
                foreach (var item in role.RolePrivileges)
                {
                    rolePrivileges.Add(new RolePrivilege { RoleId = role.Id, PrivilegeId = item.PrivilegeId });
                }

                rolePrivilegeService.RemoveByRoleId(role.Id);                
            }

            crudableDAL.Update(role);
        }
    }
}
