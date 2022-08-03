using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Configurations;
using NewsWebsite.Data.Entities;
using NewsWebsite.Data.Extension;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.EF
{
    public class WebsiteDBContext : IdentityDbContext<UserInfo, WebRole, Guid>
    {
        public WebsiteDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Configure using Fluent API
            builder.ApplyConfiguration(new ImageUserConfiguration());
            builder.ApplyConfiguration(new UserInfoConfiguration());
            builder.ApplyConfiguration(new WebRoleConfiguration());
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new CatalogConfiguration());
            builder.ApplyConfiguration(new ImageUserConfiguration());
            builder.ApplyConfiguration(new ImageNewsConfiguration());
            builder.ApplyConfiguration(new ImageInNewsConfiguration());
            builder.ApplyConfiguration(new HistoryLikeConfiguration());
            builder.ApplyConfiguration(new HistoryViewConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new AnnouncementConfiguration());
            builder.ApplyConfiguration(new AnnouncementInUserConfiguration());
            builder.ApplyConfiguration(new CatalogInUserConfiguration());
            builder.ApplyConfiguration(new NewsInCatalogConfiguration());
            builder.ApplyConfiguration(new PermissionConfiguration());
            builder.ApplyConfiguration(new ReportCommentConfiguration());
            builder.ApplyConfiguration(new FunctionConfiguration());
            builder.ApplyConfiguration(new RoleFuncConfiguration());
            builder.ApplyConfiguration(new RoleFuncConfiguration());


            //configure identity table
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            //seed data
            builder.Seed();

            
        }

        public DbSet<HistoryLike> HistoryLikes { get; set; }
        public DbSet<HistoryView> HistoryViews{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Announcement> Announcements{ get; set; }
        public DbSet<AnnouncementInUser> AnnouncementInUsers{ get; set; }
        public DbSet<Catalog> Catalogs{ get; set; }
        public DbSet<CatalogInUser> CatalogInUsers { get; set; }
        public DbSet<ImageInNews> ImageInNewss{ get; set; }
        public DbSet<ImageNews> ImageNewss{ get; set; }
        public DbSet<ImageUser> ImageUsers{ get; set; }
        public DbSet<News> Newss{ get; set; }
        public DbSet<NewsInCatalog> NewsInCatalogs { get; set; }
        public DbSet<WebRole> WebRoles { get; set; }
        public DbSet<UserInfo> UserInfos{ get; set; }
        public DbSet<Permission> Permissions{ get; set; }
        public DbSet<Function> Functions{ get; set; }
        public DbSet<RoleFunc> RoleFuncs{ get; set; }
        public DbSet<ReportComment> ReportComments{ get; set; }

        public Task FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
