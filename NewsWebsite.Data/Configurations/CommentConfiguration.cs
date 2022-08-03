using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.IdNews).IsRequired();
            builder.Property(x => x.IdUser).IsRequired();
            builder.Property(x => x.DateComment).IsRequired();
            builder.HasOne(n => n.News).WithMany(c => c.Comments).HasForeignKey(c => c.IdNews);
            builder.HasOne(n => n.UserInfo).WithMany(c => c.Comments).HasForeignKey(c => c.IdUser);
            builder.Property(x => x.ParentId).IsRequired(false);
        }
    }
}
