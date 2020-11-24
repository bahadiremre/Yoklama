using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface ICrudableDAL<CrudableTable> : IUpdatableDAL<CrudableTable> where CrudableTable : class, ICrudable, new()
    {
        void Add(CrudableTable crudableTable);

        void Remove(CrudableTable crudableTable);
    }
}
