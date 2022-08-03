using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    public class RoleFuncConfiguration : IEntityTypeConfiguration<RoleFunc>
    {
        public void Configure(EntityTypeBuilder<RoleFunc> builder)
        {
            builder.ToTable("RoleFuncs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.IdFunc).IsRequired();
            builder.Property(x => x.IdRole).IsRequired();
            builder.HasOne(x => x.Role).WithMany(x => x.RoleFuncs).HasForeignKey(x => x.IdRole);
            builder.HasOne(x => x.Function).WithMany(x => x.RoleFuncs).HasForeignKey(x => x.IdFunc);
        }
    }
}
