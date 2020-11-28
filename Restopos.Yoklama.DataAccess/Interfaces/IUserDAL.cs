using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IUserDAL : ICrudableDAL<User>
    {
        bool LoginUser(string userName, string password);

        User GetByUsername(string username);

        User GetByIdWithDetails(int id);

        List<User> GetByRoleName(string roleName);
                
        void ChangePassword(User user);

        List<Role> GetRoles(int userId);
        bool IsUsernameUnique(string username);
    }
}
