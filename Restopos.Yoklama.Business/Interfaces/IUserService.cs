﻿using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IUserService : ICrudableService<User>
    {
        bool LoginUser(string userName, string password);
        User GetByUsername(string username);
    }
}