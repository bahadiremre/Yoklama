using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class AbsenceTypeViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Devamsızlık Adı:")]
        [Required(ErrorMessage = "Devamsızlık adı boş geçilemez")]
        public string Name { get; set; }

        [Display(Name = "Saatlik mi?")]
        public bool IsHourly { get; set; }
    }
}
