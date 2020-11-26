using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IRolePrivilegeService : ICrudableService<RolePrivilege>,
        IMultipleAddableService<RolePrivilege>, IMultipleRemovableService<RolePrivilege>
    {
        void RemoveByRoleId(int id);
    }
}
