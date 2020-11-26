using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad :")]
        public string Name { get; set; }

        [Display(Name = "Soyad :")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı :")]
        public string Username { get; set; }

        [Display(Name = "Departman :")]
        public Department Department { get; set; }

        [Display(Name = "Rolleri :")]
        public List<Role> Roles { get; set; }

        [Display(Name = "Devamsızlıklar :")]
        public List<AbsenceStatus> AbsenceStatuses { get; set; }
    }
}
