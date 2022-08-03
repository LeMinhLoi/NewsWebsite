using NewsWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    class WebRoleConfiguration : IEntityTypeConfiguration<WebRole>
    {
        public void Configure(EntityTypeBuilder<WebRole> builder)
        {
            builder.ToTable("WebRoles");
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
        }
    }
}
