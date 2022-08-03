using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{

    public class HistoryViewConfiguration : IEntityTypeConfiguration<HistoryView>
    {
        public void Configure(EntityTypeBuilder<HistoryView> builder)
        {
            builder.ToTable("HistoryViews");
            builder.Property(x => x.DateView).IsRequired();
            builder.HasKey(t => new { t.IdNews, t.IdUser });
            builder.HasOne(n => n.News).WithMany(hlc => hlc.HistoryViews)
                .HasForeignKey(hlc => hlc.IdNews);
            builder.HasOne(n => n.UserInfo).WithMany(hlc => hlc.HistoryViews)
                .HasForeignKey(hlc => hlc.IdUser);
        }
    }
}
