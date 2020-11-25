using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface ICrudableService<CrudableTable> : IUpdatableService<CrudableTable>, 
        ICreatableService<CrudableTable>,
        IRemovableService<CrudableTable> where CrudableTable : class, ICrudable, new()
    {
                  
    }
}
