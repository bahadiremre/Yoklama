using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Display(Name="Rol Adı")]
        public string Name { get; set; }
    }
}
