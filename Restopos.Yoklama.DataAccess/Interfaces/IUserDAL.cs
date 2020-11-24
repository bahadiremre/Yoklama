using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IUserDAL
    {
        bool LoginUser(string userName, string password);
    }
}
