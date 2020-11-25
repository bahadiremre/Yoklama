using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IPrivilegeDAL : ICreatableDAL<Privilege>, IUpdatableDAL<Privilege>
    {
        Privilege GetByName(string privilegeName);
    }
}
