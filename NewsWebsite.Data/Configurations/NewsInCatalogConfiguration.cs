    using NewsWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    class NewsInCatalogConfiguration : IEntityTypeConfiguration<NewsInCatalog>
    {
        public void Configure(EntityTypeBuilder<NewsInCatalog> builder)
        {
            builder.ToTable("NewsInCatalogs");

            builder.HasKey(x => new { x.IdCatalog, x.IdNews});

            builder.HasOne(x => x.Catalog).WithMany(x => x.NewsInCatalogs)
                .HasForeignKey(x => x.IdCatalog);

            builder.HasOne(x => x.News).WithMany(x => x.NewsInCatalogs)
                .HasForeignKey(x => x.IdNews);
        }
    }
}