using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IMultipleRemovableService<MultipleRemovableTable> where MultipleRemovableTable : class, IRemovable, new()
    {
        void RemoveAll(List<MultipleRemovableTable> multipleRemovableTables);
    }
}
