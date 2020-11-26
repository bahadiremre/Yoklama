using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface ICreatableService<CreatableTable> where CreatableTable : class, ICreatable, new()
    {
        void Add(CreatableTable creatableTable);
        void AddRange(List<CreatableTable> creatableTables);
    }
}
