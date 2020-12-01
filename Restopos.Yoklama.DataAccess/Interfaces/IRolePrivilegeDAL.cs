using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IRolePrivilegeDAL : ICrudableDAL<RolePrivilege>,
        IMultipleAddableDAL<RolePrivilege>, IMultipleRemovableDAL<RolePrivilege>
    {
        void RemoveByRoleId(int id);
        List<RolePrivilege> GetByRoleId(int roleId);
    }
}
