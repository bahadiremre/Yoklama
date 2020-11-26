using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfMultipleRemovableRepository<MultipleRemovableTable> : IMultipleRemovableDAL<MultipleRemovableTable> where
        MultipleRemovableTable : class, IRemovable, new()
    {
        public void RemoveAll(List<MultipleRemovableTable> multipleRemovableTables)
        {
            using var context = new SqlDbContext();
            context.Set<MultipleRemovableTable>().RemoveRange(multipleRemovableTables);
            context.SaveChanges();
        }
    }
}
