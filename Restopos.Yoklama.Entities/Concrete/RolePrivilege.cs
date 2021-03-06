﻿using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class RolePrivilege : ICrudable
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }
    }
}
