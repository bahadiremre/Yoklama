using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfMultipleAddableRepository<MultipleAddableTable> : IMultipleAddableDAL<MultipleAddableTable> where
        MultipleAddableTable : class, ICreatable, new()
    {
        private readonly YoklamaDbContext db;
        public EfMultipleAddableRepository(YoklamaDbContext db)
        {
            this.db = db;
        }
        public void AddRange(List<MultipleAddableTable> multipleAddableTables)
        {
            db.Set<MultipleAddableTable>().AddRange(multipleAddableTables);
            db.SaveChanges();
        }
    }
}
