using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class PrivilegeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Yetki Adı")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Açıklama 200 karakterden fazla olamaz")]
        public string Description { get; set; }

    }
}
