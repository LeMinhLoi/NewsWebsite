using NewsWebsite.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace NewsWebsite.Data.Configurations
{
    class ImageUserConfiguration : IEntityTypeConfiguration<ImageUser>
    {
        public void Configure(EntityTypeBuilder<ImageUser> builder)
        {
            builder.ToTable("ImageUsers");
            builder.HasKey(x => x.IdImage);
            builder.Property(x => x.Path).IsRequired();
            builder.HasOne(x => x.UserInfo).WithOne(x => x.ImageUser)
                .HasForeignKey<UserInfo>(x => x.IdImageAvatar);
        }
    }
}
