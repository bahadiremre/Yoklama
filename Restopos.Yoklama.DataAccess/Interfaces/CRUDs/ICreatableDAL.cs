using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface ICreatableDAL<CreatableTable> where CreatableTable : class, ICreatable, new()
    {
        void Add(CreatableTable creatableTable);
    }
}
