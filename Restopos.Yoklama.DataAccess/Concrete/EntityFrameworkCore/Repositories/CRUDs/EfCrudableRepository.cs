using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCrudableRepository<CrudableTable> : ICrudableDAL<CrudableTable> where CrudableTable : class, ICrudable, new()
    {
        private readonly ICreatableDAL<CrudableTable> creatableDAL;
        private readonly IUpdatableDAL<CrudableTable> updatableDAL;
        private readonly IRemovableDAL<CrudableTable> removableDAL;
        private readonly IReadableDAL<CrudableTable> readableDAL;

        public EfCrudableRepository(
            ICreatableDAL<CrudableTable> creatableDAL, IUpdatableDAL<CrudableTable> updatableDAL,
            IRemovableDAL<CrudableTable> removableDAL, IReadableDAL<CrudableTable> readableDAL)
        {
            this.creatableDAL = creatableDAL;
            this.updatableDAL = updatableDAL;
            this.removableDAL = removableDAL;
            this.readableDAL = readableDAL;
        }

        public void Add(CrudableTable creatableTable)
        {
            creatableDAL.Add(creatableTable);
        }

        public List<CrudableTable> GetAll()
        {
            return readableDAL.GetAll();
        }

        public CrudableTable GetById(int id)
        {
            return readableDAL.GetById(id);
        }

        public void Remove(CrudableTable removableTable)
        {
            removableDAL.Remove(removableTable);
        }

        public void Update(CrudableTable updatableTable)
        {
            updatableDAL.Update(updatableTable);
        }
    }
}
