using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IPrivilegeService : ICreatableService<Privilege>, IUpdatableService<Privilege>
    {
        List<Privilege> GetAllConstPrivileges();

        Privilege GetByName(string privilegeName);

    }
}
