using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDAL userRoleDAL;
        private readonly ICrudableDAL<UserRole> crudableDAL;
        private readonly IMultipleAddableDAL<UserRole> multipleAddableDAL;
        private readonly IMultipleRemovableDAL<UserRole> multipleRemovableDAL;
        public UserRoleManager(ICrudableDAL<UserRole> crudableDAL,
            IMultipleAddableDAL<UserRole> multipleAddableDAL,
            IMultipleRemovableDAL<UserRole> multipleRemovableDAL,
            IUserRoleDAL userRoleDAL)
        {
            this.crudableDAL = crudableDAL;
            this.multipleAddableDAL = multipleAddableDAL;
            this.multipleRemovableDAL = multipleRemovableDAL;
            this.userRoleDAL = userRoleDAL;
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
            userRoleDAL.RemoveByUserId(id);
        }

        public void Update(UserRole userRole)
        {
            crudableDAL.Update(userRole);
        }
    }
}
