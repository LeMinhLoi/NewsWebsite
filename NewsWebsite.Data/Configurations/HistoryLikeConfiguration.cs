using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{

    public class HistoryLikeConfiguration : IEntityTypeConfiguration<HistoryLike>
    {
        public void Configure(EntityTypeBuilder<HistoryLike> builder)
        {
            builder.ToTable("HistoryLikes");
            builder.Property(x => x.DateLike).IsRequired();
            builder.Property(x => x.IsLike).IsRequired();
            builder.HasKey(t => new { t.IdNews, t.IdUser });
            builder.HasOne(n => n.News).WithMany(hlc => hlc.HistoryLikes)
                .HasForeignKey(hlc => hlc.IdNews);
            builder.HasOne(n => n.UserInfo).WithMany(hlc => hlc.HistoryLikes)
                .HasForeignKey(hlc => hlc.IdUser);
        }
    }
}
