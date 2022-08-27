using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NewsWebsite.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace NewsWebsite.Data.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().HasData(
               new Catalog() { IdCatalog = 1, Name = "Thể thao", Description = "Đây là mục thể thao" },
               new Catalog() { IdCatalog = 2, Name = "Chính trị", Description = "Đây là mục chính trị" },
               new Catalog() { IdCatalog = 3, Name = "Trong nước", Description = "Đây là mục trong nước" },
               new Catalog() { IdCatalog = 4, Name = "Quân sự", Description = "Đây là mục quân sự" },
               new Catalog() { IdCatalog = 5, Name = "Thế giới", Description = "Đây là mục thế giới" },
               new Catalog() { IdCatalog = 6, Name = "Kinh tế", Description = "Đây là mục kinh tế" },
               new Catalog() { IdCatalog = 7, Name = "Môi trường", Description = "Đây là mục môi trường" },
               new Catalog() { IdCatalog = 8, Name = "Văn hóa", Description = "Đây là mục văn hóa" },
               new Catalog() { IdCatalog = 9, Name = "Pháp luật", Description = "Đây là mục pháp luật" }
               );

            var managerId = new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7");
            var viewerId = new Guid("e2189174-217b-4540-9563-49f24a901712");
            var bloggerId = new Guid("3f2be8b9-769d-49f5-8387-f34413daa629");
            modelBuilder.Entity<WebRole>().HasData(
                new WebRole()
                {
                    Description = "Đây là manger",
                    Id = managerId,
                    Name = "Manager",
                    NormalizedName = "Manager"
                },
                new WebRole()
                {
                    Description = "Đây là Viewer",
                    Id = viewerId,
                    Name = "Viewer",
                    NormalizedName = "Viewer"
                },
                new WebRole()
                {
                    Description = "Đây là Blogger",
                    Id = bloggerId,
                    Name = "Blogger",
                    NormalizedName = "Blogger"
                }
                );


            var idAvaterLoi = new Guid("0619e3c9-a3ba-46ca-ba72-1136c388d003");
            modelBuilder.Entity<ImageUser>().HasData(
                new ImageUser()
                {
                    IdImage = idAvaterLoi,
                    Path = "/themes/images/images_user/leminhloi.png"
                }
                );
            var hasher = new PasswordHasher<UserInfo>();
            var idLoi = new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0");
            var idNhat = new Guid("135cc273-c797-480f-ac39-cabfde885094");
            var idPhuoc = new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb");
            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo()
                {
                    Id = idLoi,
                    UserName = "leminhloi",
                    NormalizedUserName = "leminhloi",
                    LastName = "Lê Minh",
                    FirstName = "Lợi",
                    NickName = "leminhloi",
                    Email = "loileminh@gmail.com",
                    NormalizedEmail = "loileminh@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Loi@1234"),
                    DoB = new DateTime(2001, 10, 4),
                    IsActive = true,
                    PhoneNumber = "0674123453",
                    Gender = true,
                    DateCreate = DateTime.Now,
                    SecurityStamp = string.Empty,
                    IdImageAvatar = idAvaterLoi,
                },
                new UserInfo()
                {
                    Id = idNhat,
                    UserName = "nhathuynh",
                    NormalizedUserName = "nhathuynh",
                    LastName = "Huỳnh",
                    FirstName = "Nhật",
                    NickName = "naruto",
                    Email = "huynhnhat@gmail.com",
                    NormalizedEmail = "huynhnhat@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Nhat@1234"),
                    DoB = new DateTime(2001, 11, 5),
                    IsActive = true,
                    PhoneNumber = "0984352123",
                    Gender = true,
                    SecurityStamp = string.Empty,
                    DateCreate = DateTime.Now,
                    IdImageAvatar = null
                },
                new UserInfo()
                {
                    Id = idPhuoc,
                    UserName = "phuochuynh",
                    NormalizedUserName = "phuochuynh",
                    LastName = "Dương",
                    FirstName = "Đại Phước",
                    NickName = "sasuke",
                    Email = "daiphuoc@gmail.com",
                    NormalizedEmail = "daiphuoc@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Phuoc@1234"),
                    DoB = new DateTime(2001, 11, 5),
                    IsActive = true,
                    PhoneNumber = "0567234145",
                    Gender = true,
                    SecurityStamp = string.Empty,
                    DateCreate = DateTime.Now,
                    IdImageAvatar = null
                }
               );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                   new IdentityUserRole<Guid>
                   {
                       RoleId = managerId,
                       UserId = idLoi
                   },
                   new IdentityUserRole<Guid>
                   {
                       RoleId = bloggerId,
                       UserId = idNhat
                   },
                   new IdentityUserRole<Guid>
                   {
                       RoleId = viewerId,
                       UserId = idPhuoc
                   }
                );
            modelBuilder.Entity<CatalogInUser>().HasData(
                new CatalogInUser()
                {
                    IdCatalog = 1,
                    IdUser = idNhat
                }
                );
            var idNews = new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e");
            modelBuilder.Entity<News>().HasData(
                new News()
                {
                    IdNews = idNews,
                    IdAuthor = idNhat,
                    DateCreate = new DateTime(2022, 10, 10),
                    Content = @"<p>Erik ten Hag đ&atilde; sớm phải nhận những &aacute;p lực, v&agrave; người h&acirc;m mộ Quỷ đỏ c&oacute; l&yacute; do để b&agrave;y tỏ sự kh&ocirc;ng h&agrave;i l&ograve;ng.</p>",
                    ViewCount = 0,
                    Tittle = "Câu chuyện của MU",
                    IsAccept = false,
                    SrcCoverImage = @"https://i.ibb.co/XjTB50K/chohaha.jpg"
                }
                ) ;
            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    Id = 1,
                    IdNews = idNews,
                    IdUser = idPhuoc,
                    DateComment = new DateTime(2022, 10, 15, 5, 3, 4),
                    Content = "Chị bảy mãi đỉnh",
                    ParentId = null
                }
                );
            modelBuilder.Entity<HistoryLike>().HasData(
                new HistoryLike()
                {
                    IdNews = idNews,
                    IdUser = idPhuoc,
                    DateLike = new DateTime(2022, 10, 15, 7, 3, 4),
                    IsLike = true
                }
                );
            modelBuilder.Entity<HistoryView>().HasData(
                new HistoryView()
                {
                    IdNews = idNews,
                    IdUser = idPhuoc,
                    DateView = new DateTime(2022, 10, 15, 4, 3, 4),
                }
                );
            modelBuilder.Entity<NewsInCatalog>().HasData(
                new NewsInCatalog()
                {
                    IdNews = idNews,
                    IdCatalog = 1
                }
                );
            var idAnn_1 = new Guid("0c794979-ac1a-45f2-92e7-a6f0e0ef2604");
            var idAnn_2 = new Guid("2b38ab59-ac01-4a2a-8aae-772d258d6fba");

            modelBuilder.Entity<Announcement>().HasData(
                new Announcement()
                {
                    Id = idAnn_1,
                    DateTime = new DateTime(2022, 10, 15, 4, 3, 4),
                    Content = "Bạn cần kiểm duyệt bài viết bây giờ"
                },
                new Announcement()
                {
                    Id = idAnn_2,
                    DateTime = new DateTime(2022, 10, 15, 4, 3, 4),
                    Content = "Bài viết của bạn không được chấp nhận."
                }
                );
            modelBuilder.Entity<AnnouncementInUser>().HasData(
                new AnnouncementInUser()
                {
                    IdAnnouncement = idAnn_1,
                    IdUser = idLoi,
                    IsViewed = false
                },
                new AnnouncementInUser()
                {
                    IdAnnouncement = idAnn_2,
                    IdUser = idNhat,
                    IsViewed = false
                }
                );
            var idImageNews1 = new Guid("522f6338-202b-4409-b3b5-bac401a94b02");
            var idImageNews2 = new Guid("23bc1330-bbc6-4e22-b3da-b0b3ace9e2fd");

            modelBuilder.Entity<ImageNews>().HasData(
                new ImageNews()
                {
                    Id = idImageNews1,
                    IsDefault = true,
                    Description = "Description is Description!",
                    Path = "themes/images/images_news/leminhloi.png"
                },
                new ImageNews()
                {
                    Id = idImageNews2,
                    IsDefault = false,
                    Description = "Description is Description!",
                    Path = "themes/images/images_news/leminhloi1.png"
                }
                );
            modelBuilder.Entity<ImageInNews>().HasData(
                new ImageInNews()
                {
                    IdImageNews = idImageNews1,
                    IdNews = idNews
                },
                new ImageInNews()
                {
                    IdImageNews = idImageNews2,
                    IdNews = idNews
                }
                );
            modelBuilder.Entity<Function>().HasData(
                new Function() 
                {
                    Id = 1,
                    NameFunc = "Thêm",
                    Description = "Đây là chức năng thêm"
                },
                new Function()
                {
                    Id = 2,
                    NameFunc = "Sửa",
                    Description = "Đây là chức năng sửa"
                }, 
                new Function()
                {
                    Id = 3,
                    NameFunc = "Xóa",
                    Description = "Đây là chức năng xóa"
                },
                new Function()
                {
                    Id = 4,
                    NameFunc = "Xem",
                    Description = "Đây là chức năng xem"
                }
                );
            modelBuilder.Entity<RoleFunc>().HasData(
                new RoleFunc()
                {
                    Id = 6,
                    IdFunc = 4,//xem
                    IdRole = managerId
                },
                new RoleFunc()
                { 
                    Id = 1,
                    IdFunc = 1,//theem
                    IdRole = managerId
                },
                new RoleFunc()
                {
                    Id = 2,
                    IdFunc = 2,//sua
                    IdRole = managerId
                },
                new RoleFunc()
                {
                    Id = 3,
                    IdFunc = 3,//xoa
                    IdRole = managerId
                },
                new RoleFunc()
                {
                    Id = 4,
                    IdFunc = 1,//them
                    IdRole = bloggerId
                },
                new RoleFunc()
                {
                    Id = 5,
                    IdFunc = 4,//xem
                    IdRole = bloggerId
                }
                );
            modelBuilder.Entity<Permission>().HasData(
                new Permission()
                { 
                    IdRoleFunc = 4,
                    IdUser = idNhat
                },
                new Permission()
                {
                    IdRoleFunc = 1,
                    IdUser = idNhat
                },
                new Permission()
                {
                    IdRoleFunc = 4,
                    IdUser = idLoi
                },
                new Permission()
                {
                    IdRoleFunc = 3,
                    IdUser = idLoi
                },
                new Permission()
                {
                    IdRoleFunc = 2,
                    IdUser = idLoi
                },
                new Permission()
                {
                    IdRoleFunc = 1,
                    IdUser = idLoi
                }
                );
            modelBuilder.Entity<ReportComment>().HasData(
                new ReportComment()
                {
                    IDReportComment = 1,
                    IdComment = 1,
                    IdReporter = idNhat,
                    ContentReport = "Comment gay war, xoa no di!",
                    DateReport = new DateTime(2022,1,1),
                }
                );
        }
    }
}
