using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System.Linq;
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

        public List<User> GetByRoleName(string roleName)
        {
            return userDAL.GetByRoleName(roleName);
        }

        public User GetByUsername(string username)
        {
            return userDAL.GetByUsername(username);
        }

        public List<Role> GetRoles(int userId)
        {
            return userDAL.GetRoles(userId);
        }

        public bool IsUsernameUnique(string username)
        {
            return userDAL.IsUsernameUnique(username);
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
            List<UserRole> userRolesFromService = userRoleService.GetByUserId(user.Id);

            List<UserRole> userRolesToBeAdded;
            List<UserRole> userRolesToBeRemoved;

            if (user.UserRoles?.Count > 0)
            {
                if (userRolesFromService?.Count > 0)
                {
                    userRolesToBeAdded = user.UserRoles.Where(x => userRolesFromService.Any(ur => ur.UserId != x.UserId)).ToList();
                    userRolesToBeRemoved = userRolesFromService.Where(x => user.UserRoles.Any(ur => ur.UserId != x.UserId)).ToList();

                    userRoleService.RemoveAll(userRolesToBeRemoved);
                    user.UserRoles = userRolesToBeAdded;
                }
            }
            else
            {
                userRoleService.RemoveByUserId(user.Id);
            }

            userDAL.Update(user);
        }

    }
}
