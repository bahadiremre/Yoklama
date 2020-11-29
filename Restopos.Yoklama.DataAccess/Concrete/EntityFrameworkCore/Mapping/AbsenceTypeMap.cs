using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restopos.Yoklama.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AbsenceTypeMap : IEntityTypeConfiguration<AbsenceType>
    {
        public void Configure(EntityTypeBuilder<AbsenceType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            //builder.HasMany(x => x.AbsenceStatuses).WithOne(x => x.AbsenceType).HasForeignKey(x => x.AbsenceTypeId);
        }
    }
}
