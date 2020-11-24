using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCrudableRepository<CrudableTable> : EfUpdatableRepository<CrudableTable>, ICrudableDAL<CrudableTable> where CrudableTable : class, ICrudable, new()
    {
        public void Add(CrudableTable crudableTable)
        {
            var context = new SqlDbContext();
            context.Set<CrudableTable>().Add(crudableTable);
            context.SaveChanges();
        }

        public void Remove(CrudableTable crudableTable)
        {
            var context = new SqlDbContext();
            context.Set<CrudableTable>().Remove(crudableTable);
            context.SaveChanges();
        }
    }
}
