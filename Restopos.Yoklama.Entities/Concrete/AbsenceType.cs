using Restopos.Yoklama.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class AbsenceType : ICrudable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsHourly { get; set; }
        public List<AbsenceStatus> AbsenceStatuses { get; set; }
    }
}
