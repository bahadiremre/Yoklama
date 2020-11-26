using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRoleRepository : IUserRoleDAL
    {
        private readonly ICrudableDAL<UserRole> crudableDAL;
        private readonly IMultipleAddableDAL<UserRole> multipleAddableDAL;
        private readonly IMultipleRemovableDAL<UserRole> multipleRemovableDAL;
        public EfUserRoleRepository(ICrudableDAL<UserRole> crudableDAL,
            IMultipleAddableDAL<UserRole> multipleAddableDAL,
            IMultipleRemovableDAL<UserRole> multipleRemovableDAL)
        {
            this.crudableDAL = crudableDAL;
            this.multipleAddableDAL = multipleAddableDAL;
            this.multipleRemovableDAL = multipleRemovableDAL;
        }

        public void Add(UserRole userRole)
        {
            crudableDAL.Add(userRole);
        }

        public void AddRange(List<UserRole> userRoles)
        {
            multipleAddableDAL.AddRange(userRoles);
        }

        public List<UserRole> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public UserRole GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public void Remove(UserRole userRole)
        {
            crudableDAL.Remove(userRole);
        }

        public void RemoveAll(List<UserRole> userRoles)
        {
            multipleRemovableDAL.RemoveAll(userRoles);
        }

        public void RemoveByUserId(int id)
        {
            using var context = new SqlDbContext();
            var userRoles = context.Set<UserRole>().Where(x => x.UserId == id);
            context.Set<UserRole>().RemoveRange(userRoles);
            context.SaveChanges();
        }

        public void Update(UserRole userRole)
        {
            crudableDAL.Update(userRole);
        }
    }
}
