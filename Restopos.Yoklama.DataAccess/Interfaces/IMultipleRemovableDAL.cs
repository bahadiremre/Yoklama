using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IMultipleRemovableDAL<MultipleRemovableTable> where MultipleRemovableTable : class, IRemovable, new()
    {
        void RemoveAll(List<MultipleRemovableTable> multipleRemovableTables);
    }
}
