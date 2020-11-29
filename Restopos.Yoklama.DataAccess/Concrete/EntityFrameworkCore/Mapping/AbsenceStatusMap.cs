using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AbsenceStatusMap : IEntityTypeConfiguration<AbsenceStatus>
    {
        public void Configure(EntityTypeBuilder<AbsenceStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.AbsenceType).WithMany(x => x.AbsenceStatuses).HasForeignKey(x => x.AbsenceTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(x => x.AbsenceStatuses).HasForeignKey(x => x.UserId);

            builder.Property(x => x.StartDate).HasColumnType("datetime2");
            builder.Property(x => x.EndDate).HasColumnType("datetime2");
        }
    }
}
