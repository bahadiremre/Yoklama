using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IMultipleAddableDAL<MultipleAddableTable> where MultipleAddableTable : class, ICreatable, new()
    {
        void AddRange(List<MultipleAddableTable> multipleAddableTables);
    }
}
