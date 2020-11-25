using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class Privilege : ICreatable, IUpdatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<RolePrivilege> RolePrivileges { get; set; }
    }
}
