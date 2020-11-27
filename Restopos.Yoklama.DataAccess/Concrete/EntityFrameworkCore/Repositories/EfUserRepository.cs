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
            using var context = new SqlDbContext();
            return context.Set<User>().Include(x => x.Department).ToList();
        }

        public User GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public User GetByIdWithDetails(int id)
        {
            using var context = new SqlDbContext();
            User user = context.Set<User>().
                Include(x => x.UserRoles).ThenInclude(x => x.Role).
                Include(x => x.AbsenceStatuses).ThenInclude(x => x.AbsenceType).
                Include(X => X.Department).FirstOrDefault(x => x.Id == id);

            return user;
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

        public void ChangePassword(User user)
        {
            using var context = new SqlDbContext();
            context.Set<User>().Attach(user);
            context.Entry(user).Property(x => x.Password).IsModified = true;
            context.SaveChanges();
        }

        public void Update(User user)
        {
            using var context = new SqlDbContext();
            context.Set<User>().Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.Entry(user).Property(x => x.Password).IsModified = false;
            context.SaveChanges();
        }

        public List<User> GetByRoleName(string roleName)
        {
            using var context = new SqlDbContext();
            List<User> users = context.Users.Where(x => x.UserRoles.Any(r => r.Role.Name == roleName)).ToList();

            return users;
        }
    }
}
