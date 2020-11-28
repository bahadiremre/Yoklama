using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IUserService : ICrudableService<User>
    {
        bool LoginUser(string userName, string password);
        User GetByUsername(string username);
        User GetByIdWithDetails(int id);
        void ChangePassword(User user);
        List<User> GetByRoleName(string roleName);
        List<Role> GetRoles(int userId);
        bool IsUsernameUnique(string username);
    }
}
