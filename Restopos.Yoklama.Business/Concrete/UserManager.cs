using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class UserManager : ICrudableService<User>
    {
        private readonly ICrudableDAL<User> crudableDAL;
        public UserManager(ICrudableDAL<User> crudableDAL)
        {
            this.crudableDAL = crudableDAL;
        }
        public void Add(User user)
        {
            crudableDAL.Add(user);
        }

        public List<User> GetAll()
        {
            return crudableDAL.GetAll();
        }

        public User GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public void Remove(User user)
        {
            crudableDAL.Remove(user);
        }

        public void Update(User user)
        {
            crudableDAL.Update(user);
        }
    }
}
