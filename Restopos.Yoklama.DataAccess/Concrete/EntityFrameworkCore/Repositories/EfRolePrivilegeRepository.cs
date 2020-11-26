using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRolePrivilegeRepository : IRolePrivilegeDAL
    {
        private readonly ICrudableDAL<RolePrivilege> crudableDAL;
        private readonly IMultipleAddableDAL<RolePrivilege> multipleAddableDAL;
        private readonly IMultipleRemovableDAL<RolePrivilege> multipleRemovableDAL;

        public EfRolePrivilegeRepository(ICrudableDAL<RolePrivilege> crudableDAL,
            IMultipleAddableDAL<RolePrivilege> multipleAddableDAL,
            IMultipleRemovableDAL<RolePrivilege> multipleRemovableDAL)
        {
            this.crudableDAL = crudableDAL;
            this.multipleAddableDAL = multipleAddableDAL;
            this.multipleRemovableDAL = multipleRemovableDAL;
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
            using var context = new SqlDbContext();
            var rolePrivileges = context.Set<RolePrivilege>().Where(x => x.RoleId == id);
            context.Set<RolePrivilege>().RemoveRange(rolePrivileges);
            context.SaveChanges();
        }

        public void Update(RolePrivilege rolePrivilege)
        {
            crudableDAL.Update(rolePrivilege);
        }
    }
}
