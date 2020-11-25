using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCreatableRepository<CreatableTable> : ICreatableDAL<CreatableTable> where CreatableTable : class, ICreatable, new()
    {
        public void Add(CreatableTable creatableTable)
        {
            var context = new SqlDbContext();
            context.Set<CreatableTable>().Add(creatableTable);
            context.SaveChanges();
        }
    }
}
