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

            privileges.Add(ConstPrivileges.P_ADD_DEPARTMENT);
            privileges.Add(ConstPrivileges.P_ADD_ROLE);
            privileges.Add(ConstPrivileges.P_ADD_USER);
            privileges.Add(ConstPrivileges.P_ADD_USERS_ABSENCE);
            privileges.Add(ConstPrivileges.P_ADD_ABSENCETYPE);
            privileges.Add(ConstPrivileges.P_DELETE_DEPARTMENT);
            privileges.Add(ConstPrivileges.P_DELETE_ROLE);
            privileges.Add(ConstPrivileges.P_DELETE_USER);
            privileges.Add(ConstPrivileges.P_DELETE_ABSENCETYPE);
            privileges.Add(ConstPrivileges.P_LIST_DEPARTMENTS);
            privileges.Add(ConstPrivileges.P_LIST_PRIVILEGES);
            privileges.Add(ConstPrivileges.P_LIST_ROLES);
            privileges.Add(ConstPrivileges.P_LIST_USERS);
            privileges.Add(ConstPrivileges.P_LIST_USERS_ABSENCES);
            privileges.Add(ConstPrivileges.P_LIST_ABSENCETYPES);
            privileges.Add(ConstPrivileges.P_UPDATE_DEPARTMENT);
            privileges.Add(ConstPrivileges.P_UPDATE_PRIVILEGES_DESC);
            privileges.Add(ConstPrivileges.P_UPDATE_ROLE);
            privileges.Add(ConstPrivileges.P_UPDATE_USER);
            privileges.Add(ConstPrivileges.P_UPDATE_USERS_ABSENCE);
            privileges.Add(ConstPrivileges.P_UPDATE_ABSENCETYPE);

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
