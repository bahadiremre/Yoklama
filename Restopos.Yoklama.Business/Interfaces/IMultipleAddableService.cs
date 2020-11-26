using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IMultipleAddableService<MultipleAddableTable> where MultipleAddableTable : class, ICreatable, new()
    {
        void AddRange(List<MultipleAddableTable> multipleAddableTables);
    }
}
