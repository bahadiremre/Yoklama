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
        private readonly YoklamaDbContext db;
        public EfUserRoleRepository(ICrudableDAL<UserRole> crudableDAL,
            IMultipleAddableDAL<UserRole> multipleAddableDAL,
            IMultipleRemovableDAL<UserRole> multipleRemovableDAL,
            YoklamaDbContext db)
        {
            this.crudableDAL = crudableDAL;
            this.multipleAddableDAL = multipleAddableDAL;
            this.multipleRemovableDAL = multipleRemovableDAL;
            this.db = db;
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
            var userRoles = db.Set<UserRole>().Where(x => x.UserId == id);
            db.Set<UserRole>().RemoveRange(userRoles);
            db.SaveChanges();
        }

        public void Update(UserRole userRole)
        {
            crudableDAL.Update(userRole);
        }
    }
}
