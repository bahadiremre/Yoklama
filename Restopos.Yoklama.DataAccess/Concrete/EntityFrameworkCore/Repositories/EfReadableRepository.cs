using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReadableRepository<ReadableTable> : IReadableDAL<ReadableTable> where ReadableTable : class, IReadable, new()
    {
        public List<ReadableTable> GetAll()
        {
            using var context = new SqlDbContext();
            return context.Set<ReadableTable>().ToList();
        }

        public ReadableTable GetById(int id)
        {
            using var context = new SqlDbContext();
            return context.Set<ReadableTable>().Find(id);
        }
    }
}
