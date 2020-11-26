﻿using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDAL userDAL;

        public UserManager(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public void Add(User user)
        {
            userDAL.Add(user);
        }

        public List<User> GetAll()
        {
            return userDAL.GetAll();
        }

        public User GetById(int id)
        {
            return userDAL.GetById(id);
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
            userDAL.Remove(user);
        }

        public void Update(User user)
        {
            userDAL.Update(user);
        }
    }
}