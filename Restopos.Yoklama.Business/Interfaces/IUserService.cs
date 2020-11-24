using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IUserService
    {
        bool LoginUser(string userName, string password);
    }
}
