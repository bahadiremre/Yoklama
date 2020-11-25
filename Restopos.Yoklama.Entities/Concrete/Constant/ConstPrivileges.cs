using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete
{
    public class ConstPrivileges
    {
        private const string LIST_USERS = "list_users";
        private const string ADD_USER = "add_user";
        private const string UPDATE_USER = "update_user";
        private const string DELETE_USER = "delete_user";
        private const string LIST_USERS_ABSENCES = "list_users_absences";
        private const string ADD_USERS_ABSENCE = "add_users_absence";
        private const string UPDATE_USERS_ABSENCE = "update_users_absence";
        private const string LIST_ROLES = "list_roles";
        private const string ADD_ROLE = "add_role";
        private const string UPDATE_ROLE = "update_role";
        private const string DELETE_ROLE = "delete_role";
        private const string LIST_PRIVILEGES = "list_privileges";
        private const string UPDATE_PRIVILEGES_DESC = "update_privileges_description";
        private const string LIST_DEPARTMENTS = "list_departments";
        private const string ADD_DEPARTMENT = "add_department";
        private const string UPDATE_DEPARTMENT = "update_department";
        private const string DELETE_DEPARTMENT = "delete_department";

        public Privilege P_LIST_USERS { get; } = new Privilege { Name = LIST_USERS };
        public Privilege P_ADD_USER { get; } = new Privilege { Name = ADD_USER };
        public Privilege P_UPDATE_USER { get; } = new Privilege { Name = UPDATE_USER };
        public Privilege P_DELETE_USER { get; } = new Privilege { Name = DELETE_USER };
        public Privilege P_LIST_USERS_ABSENCES { get; } = new Privilege { Name = LIST_USERS_ABSENCES };
        public Privilege P_ADD_USERS_ABSENCE { get; } = new Privilege { Name = ADD_USERS_ABSENCE };
        public Privilege P_UPDATE_USERS_ABSENCE { get; } = new Privilege { Name = UPDATE_USERS_ABSENCE };
        public Privilege P_LIST_ROLES { get; } = new Privilege { Name = LIST_ROLES };
        public Privilege P_ADD_ROLE { get; } = new Privilege { Name = ADD_ROLE };
        public Privilege P_UPDATE_ROLE { get; } = new Privilege { Name = UPDATE_ROLE };
        public Privilege P_DELETE_ROLE { get; } = new Privilege { Name = DELETE_ROLE };
        public Privilege P_LIST_PRIVILEGES { get; } = new Privilege { Name = LIST_PRIVILEGES };
        public Privilege P_UPDATE_PRIVILEGES_DESC { get; } = new Privilege { Name = UPDATE_PRIVILEGES_DESC };
        public Privilege P_LIST_DEPARTMENTS { get; } = new Privilege { Name = LIST_DEPARTMENTS };
        public Privilege P_ADD_DEPARTMENT { get; } = new Privilege { Name = ADD_DEPARTMENT };
        public Privilege P_UPDATE_DEPARTMENT { get; } = new Privilege { Name = UPDATE_DEPARTMENT };
        public Privilege P_DELETE_DEPARTMENT { get; } = new Privilege { Name = DELETE_DEPARTMENT };
    }
}
