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
        private ICrudableDAL<Role> crudableDAL;
        public EfRoleRepository(ICrudableDAL<Role> crudableDAL)
        {
            this.crudableDAL = crudableDAL;
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
            using var context = new SqlDbContext();
            Role role = context.Set<Role>().
                Include(x => x.RolePrivileges).ThenInclude(x => x.Privilege).
                Include(x => x.UserRoles).ThenInclude(x => x.User).
                FirstOrDefault(x => x.Id == id);

            return role;
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
