using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete.Constants
{
    public class ConstRoles
    {
        public const string ADMIN = "Admin";

        public Role Admin { get; } = new Role {Name=ADMIN };
    }
}
