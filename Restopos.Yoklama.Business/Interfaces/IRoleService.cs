﻿using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IRoleService : ICrudableService<Role>
    {
        Role GetByIdWithDetails(int id);
    }
}