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
        private readonly ICrudableDAL<RolePrivilege> crudableDAL;
        private readonly IMultipleAddableDAL<RolePrivilege> multipleAddableDAL;
        private readonly IMultipleRemovableDAL<RolePrivilege> multipleRemovableDAL;
        public RolePrivilegeManager(ICrudableDAL<RolePrivilege> crudableDAL,
            IMultipleAddableDAL<RolePrivilege> multipleAddableDAL,
            IMultipleRemovableDAL<RolePrivilege> multipleRemovableDAL,
            IRolePrivilegeDAL rolePrivilegeDAL)
        {
            this.crudableDAL = crudableDAL;
            this.multipleAddableDAL = multipleAddableDAL;
            this.multipleRemovableDAL = multipleRemovableDAL;
            this.rolePrivilegeDAL = rolePrivilegeDAL;
        }

        public void Add(RolePrivilege rolePrivilege)
        {
            crudableDAL.Add(rolePrivilege);
        }

        public void AddRange(List<RolePrivilege> rolePrivileges)
        {
            multipleAddableDAL.AddRange(rolePrivileges);
        }

        public List<RolePrivilege> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public RolePrivilege GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public void Remove(RolePrivilege rolePrivilege)
        {
            crudableDAL.Remove(rolePrivilege);
        }

        public void RemoveAll(List<RolePrivilege> rolePrivileges)
        {
            multipleRemovableDAL.RemoveAll(rolePrivileges);
        }

        public void RemoveByRoleId(int id)
        {
            rolePrivilegeDAL.RemoveByRoleId(id);
        }

        public void Update(RolePrivilege rolePrivilege)
        {
            crudableDAL.Update(rolePrivilege);
        }
    }
}
