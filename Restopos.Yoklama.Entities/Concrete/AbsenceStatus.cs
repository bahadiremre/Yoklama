using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class AbsenceStatus
    {
        public int Id { get; set; }

        public int AbsenceTypeId { get; set; }
        public AbsenceType AbsenceType { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
