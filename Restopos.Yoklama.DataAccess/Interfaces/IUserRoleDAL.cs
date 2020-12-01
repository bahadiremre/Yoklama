using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IUserRoleDAL : ICrudableDAL<UserRole>,
        IMultipleAddableDAL<UserRole>, IMultipleRemovableDAL<UserRole>
    {
        void RemoveByUserId(int id);
        List<UserRole> GetByUserId(int userId);
    }
}
