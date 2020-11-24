using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class UserManager : ICrudableService<User>, IUserService
    {
        private readonly ICrudableDAL<User> crudableDAL;
        private readonly IUserDAL userDAL;

        public UserManager(ICrudableDAL<User> crudableDAL, IUserDAL userDAL)
        {
            this.crudableDAL = crudableDAL;
            this.userDAL = userDAL;
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

        public User GetByUsername(string username)
        {
            return userDAL.GetByUsername(username);
        }

        public bool LoginUser(string userName, string password)
        {
            return userDAL.LoginUser(userName, password);
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
