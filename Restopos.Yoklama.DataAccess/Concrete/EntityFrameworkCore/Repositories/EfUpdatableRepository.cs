using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUpdatableRepository<UpdatableTable> : IUpdatableDAL<UpdatableTable> where UpdatableTable : class, IUpdatable, new()
    {
        private readonly YoklamaDbContext db;
        private readonly IReadableDAL<UpdatableTable> readableDAL;
        public EfUpdatableRepository(YoklamaDbContext db, IReadableDAL<UpdatableTable> readableDAL)
        {
            this.db = db;
            this.readableDAL = readableDAL;
        }

        public List<UpdatableTable> GetAll()
        {
            return readableDAL.GetAll();
        }

        public UpdatableTable GetById(int id)
        {
            return readableDAL.GetById(id);
        }

        public void Update(UpdatableTable updatableTable)
        {
            db.Set<UpdatableTable>().Update(updatableTable);
            db.SaveChanges();
        }
    }
}
