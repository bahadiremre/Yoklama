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
        public void AddRange(List<MultipleAddableTable> multipleAddableTables)
        {
            using var context = new SqlDbContext();
            context.Set<MultipleAddableTable>().AddRange(multipleAddableTables);
            context.SaveChanges();
        }
    }
}
