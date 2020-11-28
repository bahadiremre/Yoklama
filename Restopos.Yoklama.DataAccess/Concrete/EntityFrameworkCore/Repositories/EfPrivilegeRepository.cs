using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPrivilegeRepository : IPrivilegeDAL
    {
        private readonly ICreatableDAL<Privilege> creatableDAL;
        private readonly IUpdatableDAL<Privilege> updatableDAL;
        private readonly IReadableDAL<Privilege> readableDAL;
        private readonly YoklamaDbContext db;
        public EfPrivilegeRepository(
            ICreatableDAL<Privilege> creatableDAL, IUpdatableDAL<Privilege> updatableDAL,
            IReadableDAL<Privilege> readableDAL, YoklamaDbContext db)
        {
            this.creatableDAL = creatableDAL;
            this.updatableDAL = updatableDAL;
            this.readableDAL = readableDAL;
            this.db = db;
        }

        public void Add(Privilege privilege)
        {
            creatableDAL.Add(privilege);
        }

        public List<Privilege> GetAll()
        {
            return readableDAL.GetAll();
        }

        public Privilege GetById(int id)
        {
            return readableDAL.GetById(id);
        }

        public Privilege GetByName(string privilegeName)
        {
            return db.Set<Privilege>().FirstOrDefault(x => x.Name == privilegeName);
        }

        public void Update(Privilege privilege)
        {
            updatableDAL.Update(privilege);
        }
    }
}
