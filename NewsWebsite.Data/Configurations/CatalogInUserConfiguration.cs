using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    public class CatalogInUserConfiguration : IEntityTypeConfiguration<CatalogInUser>
    {
        public void Configure(EntityTypeBuilder<CatalogInUser> builder)
        {
            builder.ToTable("CatalogInUsers");
            builder.HasKey(t => new { t.IdCatalog, t.IdUser });

            builder.HasOne(c => c.Catalog).WithMany( ciu => ciu.CatalogInUsers)
                .HasForeignKey(ciu => ciu.IdCatalog);

            builder.HasOne(ui => ui.UserInfo).WithMany(ciu => ciu.CatalogInUsers)
                .HasForeignKey(ciu => ciu.IdUser);
        }
    }
}
