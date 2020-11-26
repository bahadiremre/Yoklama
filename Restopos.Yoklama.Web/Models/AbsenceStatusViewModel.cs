using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restopos.Yoklama.Web.Models
{
    public class AbsenceStatusViewModel
    {
        public int Id { get; set; }

        public AbsenceType AbsenceType { get; set; }

        public User User { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
