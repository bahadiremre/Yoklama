using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IUpdatableService<UpdatableTable> : IReadableService<UpdatableTable> where UpdatableTable : class, IUpdatable, new()
    {
        void Update(UpdatableTable updatableTable);
    }
}
