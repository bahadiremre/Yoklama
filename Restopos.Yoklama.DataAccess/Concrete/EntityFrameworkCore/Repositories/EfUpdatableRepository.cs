using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUpdatableRepository<UpdatableTable> : EfReadableRepository<UpdatableTable>, IUpdatableDAL<UpdatableTable> where UpdatableTable : class, IUpdatable, new()
    {
        public void Update(UpdatableTable updatableTable)
        {
            using var context = new SqlDbContext();
            context.Set<UpdatableTable>().Update(updatableTable);
            context.SaveChanges();
        }
    }
}
