using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IUpdatableDAL<UpdatableTable> : IReadableDAL<UpdatableTable> where UpdatableTable : class, IUpdatable, new()
    {
        void Update(UpdatableTable updatableTable);
    }
}
