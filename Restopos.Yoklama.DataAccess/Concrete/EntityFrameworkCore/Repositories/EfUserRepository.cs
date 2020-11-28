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
        private readonly YoklamaDbContext db;
        private readonly ICrudableDAL<User> crudableDAL;
        public EfUserRepository(ICrudableDAL<User> crudableDAL, YoklamaDbContext db)
        {
            this.crudableDAL = crudableDAL;
            this.db = db;
        }
        public void Add(User user)
        {
            crudableDAL.Add(user);
        }

        public List<User> GetAll()
        {
            return db.Set<User>().Include(x => x.Department).ToList();
        }

        public User GetById(int id)
        {
            return crudableDAL.GetById(id);
        }

        public User GetByIdWithDetails(int id)
        {
            User user = db.Set<User>().
                Include(x => x.UserRoles).ThenInclude(x => x.Role).
                Include(x => x.AbsenceStatuses).ThenInclude(x => x.AbsenceType).
                Include(X => X.Department).FirstOrDefault(x => x.Id == id);

            return user;
        }

        public User GetByUsername(string username)
        {
            var user = db.Users.Include(x => x.Department).Include(x => x.UserRoles)
                .FirstOrDefault(x => x.Username == username);
            return user;
        }

        public bool LoginUser(string userName, string password)
        {
            var user = db.Set<User>().FirstOrDefault(x => x.Username == userName && x.Password == password);

            return user != null;
        }

        public void Remove(User user)
        {
            crudableDAL.Remove(user);
        }

        public void ChangePassword(User user)
        {
            db.Set<User>().Attach(user);
            db.Entry(user).Property(x => x.Password).IsModified = true;
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Set<User>().Attach(user);
            db.Entry(user).State = EntityState.Modified;
            db.Entry(user).Property(x => x.Password).IsModified = false;
            db.SaveChanges();
        }

        public List<User> GetByRoleName(string roleName)
        {
            List<User> users = db.Users.Where(x => x.UserRoles.Any(r => r.Role.Name == roleName)).ToList();

            return users;
        }

        public List<Role> GetRoles(int userId)
        {
            List<Role> roles = db.Roles.Where(x => x.UserRoles.Any(ur => ur.UserId == userId)).ToList();
            return roles;
        }

        public bool IsUsernameUnique(string username)
        {
            User user = db.Users.FirstOrDefault(x => x.Username == username);
            return user == null;
        }
    }
}
