using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("Newss");
            builder.HasKey(x => x.IdNews);
            builder.Property(x => x.Tittle).IsRequired().IsUnicode();
            builder.Property(x => x.DateCreate).IsRequired();
            builder.Property(x => x.SrcCoverImage).IsRequired(false);
            builder.Property(x => x.ViewCount);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.IsAccept).IsRequired();
            builder.Property(x => x.IdAuthor).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            //builder.HasOne(x => x.UserInfo)
            //    .WithMany(x => x.Newss).HasForeignKey(x => x.IdAuthor);
        }

    }
}
