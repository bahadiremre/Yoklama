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
    }
}
