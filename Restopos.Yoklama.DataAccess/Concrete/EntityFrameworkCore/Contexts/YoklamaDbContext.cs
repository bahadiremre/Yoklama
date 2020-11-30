using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class YoklamaDbContext : DbContext
    {
        public YoklamaDbContext(DbContextOptions<YoklamaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AbsenceStatusMap());
            modelBuilder.ApplyConfiguration(new AbsenceTypeMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new PrivilegeMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new RolePrivilegeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AbsenceStatus> AbsenceStatuses { get; set; }
        public DbSet<AbsenceType> AbsenceTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
