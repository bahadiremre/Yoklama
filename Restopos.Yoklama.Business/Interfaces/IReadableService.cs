using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Interfaces
{
    public interface IReadableService<ReadableTable> where ReadableTable : class, IReadable, new()
    {
        ReadableTable GetById(int id);

        List<ReadableTable> GetAll();
    }
}
