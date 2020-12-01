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
        public UserRoleManager(IUserRoleDAL userRoleDAL)
        {
            this.userRoleDAL = userRoleDAL;
        }
        public void Add(UserRole userRole)
        {
            userRoleDAL.Add(userRole);
        }

        public void AddRange(List<UserRole> userRoles)
        {
            userRoleDAL.AddRange(userRoles);
        }

        public List<UserRole> GetAll()
        {
            return userRoleDAL.GetAll();
        }

        public UserRole GetById(int id)
        {
            return userRoleDAL.GetById(id);
        }

        public List<UserRole> GetByUserId(int userId)
        {
            return userRoleDAL.GetByUserId(userId);
        }

        public void Remove(UserRole userRole)
        {
            userRoleDAL.Remove(userRole);
        }

        public void RemoveAll(List<UserRole> userRoles)
        {
            userRoleDAL.RemoveAll(userRoles);
        }

        public void RemoveByUserId(int id)
        {
            userRoleDAL.RemoveByUserId(id);
        }

        public void Update(UserRole userRole)
        {
            userRoleDAL.Update(userRole);
        }
    }
}
