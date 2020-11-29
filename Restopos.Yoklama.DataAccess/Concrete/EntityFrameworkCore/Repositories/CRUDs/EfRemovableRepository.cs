using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRemovableRepository<RemovableTable> : IRemovableDAL<RemovableTable> where RemovableTable : class, IRemovable, new()
    {
        private readonly IReadableDAL<RemovableTable> readableDAL;
        private readonly YoklamaDbContext db;
        public EfRemovableRepository(YoklamaDbContext db, IReadableDAL<RemovableTable> readableDAL)
        {
            this.db = db;
            this.readableDAL = readableDAL;
        }

        public List<RemovableTable> GetAll()
        {
            return readableDAL.GetAll();
        }

        public RemovableTable GetById(int id)
        {
            return readableDAL.GetById(id);
        }

        public void Remove(RemovableTable removableTable)
        {
            db.Set<RemovableTable>().Remove(removableTable);
            db.SaveChanges();
        }
    }
}
