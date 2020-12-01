using Microsoft.EntityFrameworkCore;
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
        private readonly YoklamaDbContext db;
        public EfRolePrivilegeRepository(ICrudableDAL<RolePrivilege> crudableDAL,
            IMultipleAddableDAL<RolePrivilege> multipleAddableDAL,
            IMultipleRemovableDAL<RolePrivilege> multipleRemovableDAL, YoklamaDbContext db)
        {
            this.crudableDAL = crudableDAL;
            this.multipleAddableDAL = multipleAddableDAL;
            this.multipleRemovableDAL = multipleRemovableDAL;
            this.db = db;
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

        public List<RolePrivilege> GetByRoleId(int roleId)
        {
            return db.Set<RolePrivilege>().Where(x => x.RoleId == roleId).ToList();
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
            var rolePrivileges = db.Set<RolePrivilege>().Where(x => x.RoleId == id);
            db.Set<RolePrivilege>().RemoveRange(rolePrivileges);
            db.SaveChanges();
        }

        public void Update(RolePrivilege rolePrivilege)
        {
            crudableDAL.Update(rolePrivilege);
        }
    }
}
