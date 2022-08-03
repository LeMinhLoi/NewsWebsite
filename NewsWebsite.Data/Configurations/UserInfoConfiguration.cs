using NewsWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("UserInfos");
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.NickName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DoB).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IdImageAvatar).IsRequired(false);
        }
    }
}
