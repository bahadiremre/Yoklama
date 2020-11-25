using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRemovableRepository<RemovableTable> : EfReadableRepository<RemovableTable>, IRemovableDAL<RemovableTable> where RemovableTable : class, IRemovable, new()
    {

        public void Remove(RemovableTable removableTable)
        {
            var context = new SqlDbContext();
            context.Set<RemovableTable>().Remove(removableTable);
            context.SaveChanges();
        }
    }
}
