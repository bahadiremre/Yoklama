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
        private readonly YoklamaDbContext db;
        public EfCreatableRepository(YoklamaDbContext db)
        {
            this.db = db;
        }
        public void Add(CreatableTable creatableTable)
        {
            db.Set<CreatableTable>().Add(creatableTable);
            db.SaveChanges();
        }

        public void AddRange(List<CreatableTable> creatableTables)
        {
            db.Set<CreatableTable>().AddRange(creatableTables);
            db.SaveChanges();
        }
    }
}
