using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IRemovableDAL<RemovableTable> : IReadableDAL<RemovableTable> where RemovableTable : class, IRemovable, new()
    {
        void Remove(RemovableTable removableTable);
    }
}
