using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete.Constants
{
    public class ConstRoles
    {
        public const string ADMIN = "Admin";
        public const string MEMBER = "Üye";

        public Role Admin { get; } = new Role {Name=ADMIN };
        public Role Member { get; } = new Role { Name = MEMBER };
    }
}
