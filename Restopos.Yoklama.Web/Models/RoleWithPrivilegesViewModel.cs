using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class RoleWithPrivilegesViewModel : RoleViewModel
    {
        public List<PrivilegeSelectionViewModel> PrivilegesWithSelection { get; set; }
    }
}
