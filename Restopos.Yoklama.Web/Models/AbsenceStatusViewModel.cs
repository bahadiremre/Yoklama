using Restopos.Yoklama.Entities.Concrete;
using Restopos.Yoklama.Web.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class AbsenceStatusViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Devamsızlık Türü")]
        [Required(ErrorMessage = "Devamsızlık türü boş geçilemez.")]
        public AbsenceType AbsenceType { get; set; }

        [Display(Name ="Kullanıcı")]
        [Required(ErrorMessage ="Kullanıcı seçimi boş geçilemez.")]
        public User User { get; set; }

        [DateTimeLessThan("EndDate")]
        [Display(Name ="Başlangıç Zamanı")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Zamanı")]
        public DateTime EndDate { get; set; }
    }
}
