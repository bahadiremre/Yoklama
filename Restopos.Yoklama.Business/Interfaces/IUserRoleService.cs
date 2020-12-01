using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IUserRoleService : ICrudableService<UserRole>,
        IMultipleAddableService<UserRole>, IMultipleRemovableService<UserRole>
    {
        void RemoveByUserId(int id);
        List<UserRole> GetByUserId(int userId);
    }
}

