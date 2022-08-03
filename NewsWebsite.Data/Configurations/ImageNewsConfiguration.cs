using NewsWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace NewsWebsite.Data.Configurations
{
    public class ImageNewsConfiguration : IEntityTypeConfiguration<ImageNews>
    {
        public void Configure(EntityTypeBuilder<ImageNews> builder)
        {
            builder.ToTable("ImageNewss");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.IsDefault).IsRequired();
        }
    }
}
