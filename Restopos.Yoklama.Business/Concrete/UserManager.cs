using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL userDAL;
        private readonly IUserRoleService userRoleService;

        public UserManager(IUserDAL userDAL, IUserRoleService userRoleService)
        {
            this.userDAL = userDAL;
            this.userRoleService = userRoleService;
        }

        public void Add(User user)
        {
            userDAL.Add(user);
        }

        public void ChangePassword(User user)
        {
            userDAL.ChangePassword(user);
        }

        public List<User> GetAll()
        {
            return userDAL.GetAll();
        }

        public User GetById(int id)
        {
            return userDAL.GetById(id);
        }

        public User GetByIdWithDetails(int id)
        {
            return userDAL.GetByIdWithDetails(id);
        }

        public User GetByUsername(string username)
        {
            return userDAL.GetByUsername(username);
        }

        public bool LoginUser(string userName, string password)
        {
            return userDAL.LoginUser(userName, password);
        }

        public void Remove(User user)
        {
            userDAL.Remove(user);
        }

        public void Update(User user)
        {
            List<UserRole> userRoles = new List<UserRole>();

            if (user.UserRoles?.Count > 0)
            {
                foreach (var item in user.UserRoles)
                {
                    userRoles.Add(new UserRole
                    {
                        RoleId = item.RoleId,
                        UserId = user.Id
                    });
                }

                userRoleService.RemoveByUserId(user.Id);
            }

            userDAL.Update(user);
        }

    }
}
