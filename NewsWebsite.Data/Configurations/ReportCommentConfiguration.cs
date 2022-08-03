using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    public class ReportCommentConfiguration : IEntityTypeConfiguration<ReportComment>
    {
        public void Configure(EntityTypeBuilder<ReportComment> builder)
        {
            builder.ToTable("ReportComments");
            builder.HasKey(x => x.IDReportComment);
            builder.Property(x => x.IDReportComment).UseIdentityColumn();
            builder.Property(x => x.ContentReport).IsRequired();
            builder.Property(x => x.IdComment).IsRequired();
            builder.Property(x => x.IdReporter).IsRequired();
            builder.Property(x => x.DateReport).IsRequired();
            //builder.HasOne(x => x.Comment)
            //    .WithMany(x => x.ReportComments).HasForeignKey(x => x.IdComment);
            builder.HasOne(x => x.Reporter)
                .WithMany(x => x.ReportComments).HasForeignKey(x => x.IdReporter);
        }
    }
}
