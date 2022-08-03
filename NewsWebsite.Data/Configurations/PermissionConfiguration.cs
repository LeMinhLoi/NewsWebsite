using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(x => new { x.IdRoleFunc, x.IdUser});
            builder.HasOne(x => x.UserInfo)
                .WithMany(x => x.Permissions).HasForeignKey(x => x.IdUser);
            builder.HasOne(x => x.RoleFunc)
                .WithMany(x => x.Permissions).HasForeignKey(x => x.IdRoleFunc);
        }
    }
}
