using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class RoleDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage ="Rol adının girilmesi zorunludur.")]
        public string Name { get; set; }

        [Display(Name = "Role Ait Yetkiler")]
        public List<RolePrivilege> RolePrivileges { get; set; }

        [Display(Name = "Role Sahip Kullanıcılar")]
        public List<UserRole> UserRoles { get; set; }
    }
}
