using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class RolePrivilegeManager : IRolePrivilegeService
    {
        private readonly IRolePrivilegeDAL rolePrivilegeDAL;
        public RolePrivilegeManager(IRolePrivilegeDAL rolePrivilegeDAL)
        {
            this.rolePrivilegeDAL = rolePrivilegeDAL;
        }

        public void Add(RolePrivilege rolePrivilege)
        {
            rolePrivilegeDAL.Add(rolePrivilege);
        }

        public void AddRange(List<RolePrivilege> rolePrivileges)
        {
            rolePrivilegeDAL.AddRange(rolePrivileges);
        }

        public List<RolePrivilege> GetAll()
        {
            return rolePrivilegeDAL.GetAll();
        }

        public RolePrivilege GetById(int id)
        {
            return rolePrivilegeDAL.GetById(id);
        }

        public List<RolePrivilege> GetByRoleId(int RoleId)
        {
            return rolePrivilegeDAL.GetByRoleId(RoleId);
        }

        public void Remove(RolePrivilege rolePrivilege)
        {
            rolePrivilegeDAL.Remove(rolePrivilege);
        }

        public void RemoveAll(List<RolePrivilege> rolePrivileges)
        {
            rolePrivilegeDAL.RemoveAll(rolePrivileges);
        }

        public void RemoveByRoleId(int id)
        {
            rolePrivilegeDAL.RemoveByRoleId(id);
        }

        public void Update(RolePrivilege rolePrivilege)
        {
            rolePrivilegeDAL.Update(rolePrivilege);
        }
    }
}
