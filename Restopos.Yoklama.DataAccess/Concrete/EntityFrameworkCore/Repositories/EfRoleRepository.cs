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
    public class EfRoleRepository : IRoleDAL
    {
        private readonly YoklamaDbContext db;
        private ICrudableDAL<Role> crudableDAL;
        public EfRoleRepository(ICrudableDAL<Role> crudableDAL,YoklamaDbContext db)
        {
            this.crudableDAL = crudableDAL;
            this.db = db;
        }

        public void Add(Role role)
        {
            crudableDAL.Add(role);
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
            Role role = db.Set<Role>().
                Include(x => x.RolePrivileges).ThenInclude(x => x.Privilege).
                Include(x => x.UserRoles).ThenInclude(x => x.User).
                FirstOrDefault(x => x.Id == id);

            return role;
        }

        public Role GetByName(string roleName)
        {
            return db.Set<Role>().FirstOrDefault(x => x.Name == roleName);
        }

        public List<Privilege> GetPrivileges(int roleId)
        {
            List<Privilege> privileges = db.Set<Privilege>().
                Where(x => x.RolePrivileges.Any(rp => rp.RoleId == roleId)).ToList();
            return privileges;
        }

        public void Remove(Role role)
        {
            crudableDAL.Remove(role);
        }

        public void Update(Role role)
        {
            crudableDAL.Update(role);
        }
    }
}
