using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class AbsenceType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AbsenceStatus> AbsenceStatuses { get; set; }
    }
}
