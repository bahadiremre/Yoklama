using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class UserListViewModel
    {
        [Display(Name = "Ad:")]
        public string Name { get; set; }

        [Display(Name = "Soyad:")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı:")]
        public string Username { get; set; }

        [Display(Name = "Departman")]
        public Department Department { get; set; }
    }
}
