using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Interfaces
{
    public interface IReadableDAL<ReadableTable> where ReadableTable : class, IReadable, new()
    {
        ReadableTable GetById(int id);

        List<ReadableTable> GetAll();
    }
}
