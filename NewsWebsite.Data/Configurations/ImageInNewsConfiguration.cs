using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    class ImageInNewsConfiguration : IEntityTypeConfiguration<ImageInNews>
    {
        public void Configure(EntityTypeBuilder<ImageInNews> builder)
        {
            builder.ToTable("ImageInNewss");
            builder.HasKey(x => new {x.IdNews, x.IdImageNews });
            builder.HasOne(x => x.ImageNews).WithMany(x => x.ImageInNewss).HasForeignKey(x => x.IdImageNews);
            builder.HasOne(x => x.News).WithMany(x => x.ImageInNews).HasForeignKey(x => x.IdNews);
            builder.Property(x => x.Order).IsRequired();

        }
    }
}
