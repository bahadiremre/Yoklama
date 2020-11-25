using Microsoft.EntityFrameworkCore;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUserRepository : IUserDAL
    {
        private readonly ICrudableDAL<User> crudableDAL;
        public EfUserRepository(ICrudableDAL<User> crudableDAL)
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

        public User GetByUsername(string username)
        {
            using var context = new SqlDbContext();
            var user = context.Users.Include(x => x.Department).FirstOrDefault(x => x.Username == username);
            return user;
        }

        public bool LoginUser(string userName, string password)
        {
            using var context = new SqlDbContext();
            var user = context.Set<User>().FirstOrDefault(x => x.Username == userName && x.Password == password);

            return user != null;
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
