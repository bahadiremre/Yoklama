using Microsoft.EntityFrameworkCore;
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
        private readonly YoklamaDbContext db;
        public EfReadableRepository(YoklamaDbContext db)
        {
            this.db = db;
        }
        public List<ReadableTable> GetAll()
        {
            return db.Set<ReadableTable>().ToList();
        }

        public ReadableTable GetById(int id)
        {
            return db.Set<ReadableTable>().Find(id);
        }
    }
}
