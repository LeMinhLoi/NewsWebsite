using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Configurations
{
    public class AnnouncementInUserConfiguration : IEntityTypeConfiguration<AnnouncementInUser>
    {
        public void Configure(EntityTypeBuilder<AnnouncementInUser> builder)
        {
            builder.ToTable("AnnouncementInUsers");
            builder.HasKey(x => new { x.IdAnnouncement, x.IdUser });
            builder.Property(x => x.IsViewed).IsRequired();
            builder.HasOne(a => a.Announcement).WithMany(aiu => aiu.AnnouncementInUsers).HasForeignKey(aiu => aiu.IdAnnouncement);
            builder.HasOne(ui => ui.UserInfo).WithMany(aiu => aiu.AnnouncementInUsers).HasForeignKey(aiu => aiu.IdUser);
        }
    }
}
