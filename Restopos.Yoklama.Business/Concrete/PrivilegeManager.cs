using Restopos.Yoklama.Business.Interfaces;
using Restopos.Yoklama.DataAccess.Interfaces;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Business.Concrete
{
    public class PrivilegeManager : IPrivilegeService
    {
        private readonly IPrivilegeDAL privilegeDAL;
        public PrivilegeManager(IPrivilegeDAL privilegeDAL)
        {
            this.privilegeDAL = privilegeDAL;
        }

        public void Add(Privilege privilege)
        {
            privilegeDAL.Add(privilege);
        }

        public List<Privilege> GetAll()
        {
            return privilegeDAL.GetAll();
        }

        public List<Privilege> GetAllConstPrivileges()
        {
            List<Privilege> privileges = new List<Privilege>();

            ConstPrivileges constPrivileges = new ConstPrivileges();

            privileges.Add(constPrivileges.P_ADD_DEPARTMENT);
            privileges.Add(constPrivileges.P_ADD_ROLE);
            privileges.Add(constPrivileges.P_ADD_USER);
            privileges.Add(constPrivileges.P_ADD_USERS_ABSENCE);
            privileges.Add(constPrivileges.P_DELETE_DEPARTMENT);
            privileges.Add(constPrivileges.P_DELETE_ROLE);
            privileges.Add(constPrivileges.P_DELETE_USER);
            privileges.Add(constPrivileges.P_LIST_DEPARTMENTS);
            privileges.Add(constPrivileges.P_LIST_PRIVILEGES);
            privileges.Add(constPrivileges.P_LIST_ROLES);
            privileges.Add(constPrivileges.P_LIST_USERS);
            privileges.Add(constPrivileges.P_LIST_USERS_ABSENCES);
            privileges.Add(constPrivileges.P_UPDATE_DEPARTMENT);
            privileges.Add(constPrivileges.P_UPDATE_PRIVILEGES_DESC);
            privileges.Add(constPrivileges.P_UPDATE_ROLE);
            privileges.Add(constPrivileges.P_UPDATE_USER);
            privileges.Add(constPrivileges.P_UPDATE_USERS_ABSENCE);

            return privileges;
        }

        public Privilege GetById(int id)
        {
            return privilegeDAL.GetById(id);
        }

        public Privilege GetByName(string privilegeName)
        {
            return privilegeDAL.GetByName(privilegeName);
        }

        public void Update(Privilege privilege)
        {
            privilegeDAL.Update(privilege);
        }
    }
}
