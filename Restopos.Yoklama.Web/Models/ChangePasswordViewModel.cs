using Restopos.Yoklama.Web.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }

        [Display(Name ="Eski Şifre")]
        [Required(ErrorMessage ="Eski şifre boş geçilemez")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Yeni Şifre")]
        [PasswordValidator]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Yeni Şifre(Tekrar)")]
        [Required(ErrorMessage = "Yeni Şifre doğrulama alanı boş geçilemez")]
        [Compare("NewPassword", ErrorMessage = "Şifreleriniz uyuşmuyor")]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }
    }
}
