using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Web.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class UserWithRoleSelectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Username]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }

        [Display(Name = "Departman")]
        public Department Department { get; set; }

        [Display(Name = "Kullanıcı Rolleri")]
        public List<RoleSelectionViewModel> RoleSelections { get; set; }
    }
}
