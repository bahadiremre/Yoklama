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
        public bool LoginUser(string userName, string password)
        {
            using var context = new SqlDbContext();
            var user = context.Set<User>().FirstOrDefault(x => x.Username == userName && x.Password == password);

            return user != null;
        }
    }
}
