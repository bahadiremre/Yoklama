using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Departman Adı:")]
        [Required(ErrorMessage = "Departman adı boş geçilemez")]
        public string Name { get; set; }

    }
}
