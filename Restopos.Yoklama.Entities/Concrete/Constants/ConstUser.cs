using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete.Constants
{
    public class ConstUser
    {
        public const string NAME = "Yönetici";
        public const string SURNAME = "Yönetici";
        public const string USERNAME = "admin";
        public const string PASSWORD = "admin123";

        public User AdminUser { get; } = new User { Name = NAME, Surname = SURNAME, Password = PASSWORD, Username = USERNAME };
    }
}
