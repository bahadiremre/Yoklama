using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RolePrivilege> RolePrivileges { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
