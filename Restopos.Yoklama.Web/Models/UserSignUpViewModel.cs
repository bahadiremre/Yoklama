using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad:")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Soyad:")]
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı:")]
        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Tekrar Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        [Compare("Password",ErrorMessage ="Şifreleriniz uyuşmuyor")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name="Departman")]
        public int? DepartmentId { get; set; }
    }
}
