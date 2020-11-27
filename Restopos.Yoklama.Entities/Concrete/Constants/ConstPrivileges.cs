using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.Entities.Concrete.Constants
{
    public static class ConstPrivileges
    {
        public const string LIST_USERS = "list_users";        
        public const string UPDATE_USER = "update_user";
        public const string DELETE_USER = "delete_user";
        public const string LIST_USERS_ABSENCES = "list_users_absences";
        public const string ADD_USERS_ABSENCE = "add_users_absence";
        public const string UPDATE_USERS_ABSENCE = "update_users_absence";
        public const string DELETE_USERS_ABSENCE = "delete_users_absence";
        public const string LIST_ROLES = "list_roles";
        public const string ADD_ROLE = "add_role";
        public const string UPDATE_ROLE = "update_role";
        public const string DELETE_ROLE = "delete_role";
        public const string LIST_PRIVILEGES = "list_privileges";
        public const string UPDATE_PRIVILEGES_DESC = "update_privileges_description";
        public const string LIST_DEPARTMENTS = "list_departments";
        public const string ADD_DEPARTMENT = "add_department";
        public const string UPDATE_DEPARTMENT = "update_department";
        public const string DELETE_DEPARTMENT = "delete_department";
        public const string LIST_ABSENCETYPES = "list_absencetypes";
        public const string ADD_ABSENCETYPE = "add_absencetype";
        public const string UPDATE_ABSENCETYPE = "update_absencetype";
        public const string DELETE_ABSENCETYPE = "delete_absencetype";

        public static Privilege P_LIST_USERS { get; } = new Privilege { Name = LIST_USERS };
        public static Privilege P_UPDATE_USER { get; } = new Privilege { Name = UPDATE_USER };
        public static Privilege P_DELETE_USER { get; } = new Privilege { Name = DELETE_USER };
        public static Privilege P_LIST_USERS_ABSENCES { get; } = new Privilege { Name = LIST_USERS_ABSENCES };
        public static Privilege P_ADD_USERS_ABSENCE { get; } = new Privilege { Name = ADD_USERS_ABSENCE };
        public static Privilege P_UPDATE_USERS_ABSENCE { get; } = new Privilege { Name = UPDATE_USERS_ABSENCE };
        public static Privilege P_DELETE_USERS_ABSENCE { get; } = new Privilege { Name = DELETE_USERS_ABSENCE };
        public static Privilege P_LIST_ROLES { get; } = new Privilege { Name = LIST_ROLES };
        public static Privilege P_ADD_ROLE { get; } = new Privilege { Name = ADD_ROLE };
        public static Privilege P_UPDATE_ROLE { get; } = new Privilege { Name = UPDATE_ROLE };
        public static Privilege P_DELETE_ROLE { get; } = new Privilege { Name = DELETE_ROLE };
        public static Privilege P_LIST_PRIVILEGES { get; } = new Privilege { Name = LIST_PRIVILEGES };
        public static Privilege P_UPDATE_PRIVILEGES_DESC { get; } = new Privilege { Name = UPDATE_PRIVILEGES_DESC };
        public static Privilege P_LIST_DEPARTMENTS { get; } = new Privilege { Name = LIST_DEPARTMENTS };
        public static Privilege P_ADD_DEPARTMENT { get; } = new Privilege { Name = ADD_DEPARTMENT };
        public static Privilege P_UPDATE_DEPARTMENT { get; } = new Privilege { Name = UPDATE_DEPARTMENT };
        public static Privilege P_DELETE_DEPARTMENT { get; } = new Privilege { Name = DELETE_DEPARTMENT };
        public static Privilege P_LIST_ABSENCETYPES { get; } = new Privilege { Name = LIST_ABSENCETYPES };
        public static Privilege P_ADD_ABSENCETYPE { get; } = new Privilege { Name = ADD_ABSENCETYPE };
        public static Privilege P_UPDATE_ABSENCETYPE { get; } = new Privilege { Name = UPDATE_ABSENCETYPE };
        public static Privilege P_DELETE_ABSENCETYPE { get; } = new Privilege { Name = DELETE_ABSENCETYPE };
    }
}
