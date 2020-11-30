using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    class RolePrivilegeMap : IEntityTypeConfiguration<RolePrivilege>
    {
        public void Configure(EntityTypeBuilder<RolePrivilege> builder)
        {
            builder.HasKey(x => new {x.RoleId,x.PrivilegeId });

            builder.HasOne(x => x.Role).WithMany(x => x.RolePrivileges).HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Privilege).WithMany(x => x.RolePrivileges).HasForeignKey(x => x.PrivilegeId);
        }
    }
}
