using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IRemovableService<RemovableTable> where RemovableTable : class, IRemovable, new()
    {
        void Remove(RemovableTable crudableTable);
    }
}
