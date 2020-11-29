using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IRoleDAL:ICrudableDAL<Role>
    {
        Role GetByIdWithDetails(int id);

        List<Privilege> GetPrivileges(int roleId);
        Role GetByName(string roleName);
    }
}
