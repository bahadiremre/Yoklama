using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class RoleManager : ICrudableService<Role>
    {
        private readonly ICrudableDAL<Role> crudableDAL;
        public RoleManager(ICrudableDAL<Role> crudableDAL)
        {
            this.crudableDAL = crudableDAL;
        }
        public void Add(Role role)
        {
            crudableDAL.Add(role);
        }

        public List<Role> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public Role GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public void Remove(Role role)
        {
            crudableDAL.Remove(role);
        }

        public void Update(Role role)
        {
            crudableDAL.Update(role);
        }
    }
}
