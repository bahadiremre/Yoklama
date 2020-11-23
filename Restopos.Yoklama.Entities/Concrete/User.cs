using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<AbsenceStatus> AbsenceStatuses { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
