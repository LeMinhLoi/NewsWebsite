using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebsite.Data.Migrations
{
    public partial class MyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    IdCatalog = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.IdCatalog);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFunc = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageNewss",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageNewss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageUsers",
                columns: table => new
                {
                    IdImage = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUsers", x => x.IdImage);
                });

            migrationBuilder.CreateTable(
                name: "Newss",
                columns: table => new
                {
                    IdNews = table.Column<Guid>(nullable: false),
                    Tittle = table.Column<string>(nullable: false),
                    SrcCoverImage = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    IdAuthor = table.Column<Guid>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newss", x => x.IdNews);
                });

            migrationBuilder.CreateTable(
                name: "WebRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageInNewss",
                columns: table => new
                {
                    IdImageNews = table.Column<Guid>(nullable: false),
                    IdNews = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageInNewss", x => new { x.IdNews, x.IdImageNews });
                    table.ForeignKey(
                        name: "FK_ImageInNewss_ImageNewss_IdImageNews",
                        column: x => x.IdImageNews,
                        principalTable: "ImageNewss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageInNewss_Newss_IdNews",
                        column: x => x.IdNews,
                        principalTable: "Newss",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsInCatalogs",
                columns: table => new
                {
                    IdCatalog = table.Column<int>(nullable: false),
                    IdNews = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsInCatalogs", x => new { x.IdCatalog, x.IdNews });
                    table.ForeignKey(
                        name: "FK_NewsInCatalogs_Catalogs_IdCatalog",
                        column: x => x.IdCatalog,
                        principalTable: "Catalogs",
                        principalColumn: "IdCatalog",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsInCatalogs_Newss_IdNews",
                        column: x => x.IdNews,
                        principalTable: "Newss",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_WebRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "WebRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleFuncs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFunc = table.Column<int>(nullable: false),
                    IdRole = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFuncs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleFuncs_Functions_IdFunc",
                        column: x => x.IdFunc,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFuncs_WebRoles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "WebRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementInUsers",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    IdAnnouncement = table.Column<Guid>(nullable: false),
                    IsViewed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementInUsers", x => new { x.IdAnnouncement, x.IdUser });
                    table.ForeignKey(
                        name: "FK_AnnouncementInUsers_Announcements_IdAnnouncement",
                        column: x => x.IdAnnouncement,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogInUsers",
                columns: table => new
                {
                    IdCatalog = table.Column<int>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogInUsers", x => new { x.IdCatalog, x.IdUser });
                    table.ForeignKey(
                        name: "FK_CatalogInUsers_Catalogs_IdCatalog",
                        column: x => x.IdCatalog,
                        principalTable: "Catalogs",
                        principalColumn: "IdCatalog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    NickName = table.Column<string>(maxLength: 200, nullable: false),
                    DoB = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    IdImageAvatar = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    CommentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfos_ImageUsers_IdImageAvatar",
                        column: x => x.IdImageAvatar,
                        principalTable: "ImageUsers",
                        principalColumn: "IdImage",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_WebRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "WebRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdNews = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    DateComment = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Newss_IdNews",
                        column: x => x.IdNews,
                        principalTable: "Newss",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_UserInfos_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryLikes",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    IdNews = table.Column<Guid>(nullable: false),
                    DateLike = table.Column<DateTime>(nullable: false),
                    IsLike = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryLikes", x => new { x.IdNews, x.IdUser });
                    table.ForeignKey(
                        name: "FK_HistoryLikes_Newss_IdNews",
                        column: x => x.IdNews,
                        principalTable: "Newss",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryLikes_UserInfos_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryViews",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    IdNews = table.Column<Guid>(nullable: false),
                    DateView = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryViews", x => new { x.IdNews, x.IdUser });
                    table.ForeignKey(
                        name: "FK_HistoryViews_Newss_IdNews",
                        column: x => x.IdNews,
                        principalTable: "Newss",
                        principalColumn: "IdNews",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryViews_UserInfos_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    IdRoleFunc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => new { x.IdRoleFunc, x.IdUser });
                    table.ForeignKey(
                        name: "FK_Permissions_RoleFuncs_IdRoleFunc",
                        column: x => x.IdRoleFunc,
                        principalTable: "RoleFuncs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_UserInfos_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportComments",
                columns: table => new
                {
                    IDReportComment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComment = table.Column<int>(nullable: false),
                    ContentReport = table.Column<string>(nullable: false),
                    DateReport = table.Column<DateTime>(nullable: false),
                    IdReporter = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportComments", x => x.IDReportComment);
                    table.ForeignKey(
                        name: "FK_ReportComments_UserInfos_IdReporter",
                        column: x => x.IdReporter,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "Content", "DateTime" },
                values: new object[,]
                {
                    { new Guid("0c794979-ac1a-45f2-92e7-a6f0e0ef2604"), "Bạn cần kiểm duyệt bài viết bây giờ", new DateTime(2022, 10, 15, 4, 3, 4, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b38ab59-ac01-4a2a-8aae-772d258d6fba"), "Bài viết của bạn không được chấp nhận.", new DateTime(2022, 10, 15, 4, 3, 4, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "IdCatalog", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Đây là mục thể thao", "Thể thao" },
                    { 2, "Đây là mục chính trị", "Chính trị" },
                    { 3, "Đây là mục trong nước", "Trong nước" },
                    { 4, "Đây là mục quân sự", "Quân sự" },
                    { 5, "Đây là mục thế giới", "Thế giới" },
                    { 6, "Đây là mục kinh tế", "Kinh tế" },
                    { 7, "Đây là mục môi trường", "Môi trường" },
                    { 8, "Đây là mục văn hóa", "Văn hóa" },
                    { 9, "Đây là mục pháp luật", "Pháp luật" }
                });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "Description", "NameFunc" },
                values: new object[,]
                {
                    { 4, "Đây là chức năng xem", "Xem" },
                    { 3, "Đây là chức năng xóa", "Xóa" },
                    { 1, "Đây là chức năng thêm", "Thêm" },
                    { 2, "Đây là chức năng sửa", "Sửa" }
                });

            migrationBuilder.InsertData(
                table: "ImageNewss",
                columns: new[] { "Id", "Description", "IsDefault", "Path" },
                values: new object[,]
                {
                    { new Guid("522f6338-202b-4409-b3b5-bac401a94b02"), "Description is Description!", true, "themes/images/images_news/leminhloi.png" },
                    { new Guid("23bc1330-bbc6-4e22-b3da-b0b3ace9e2fd"), "Description is Description!", false, "themes/images/images_news/leminhloi1.png" }
                });

            migrationBuilder.InsertData(
                table: "ImageUsers",
                columns: new[] { "IdImage", "Path" },
                values: new object[] { new Guid("0619e3c9-a3ba-46ca-ba72-1136c388d003"), "/themes/images/images_user/leminhloi.png" });

            migrationBuilder.InsertData(
                table: "Newss",
                columns: new[] { "IdNews", "Content", "DateCreate", "IdAuthor", "IsAccept", "SrcCoverImage", "Tittle", "ViewCount" },
                values: new object[] { new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"), "<p>Erik ten Hag đ&atilde; sớm phải nhận những &aacute;p lực, v&agrave; người h&acirc;m mộ Quỷ đỏ c&oacute; l&yacute; do để b&agrave;y tỏ sự kh&ocirc;ng h&agrave;i l&ograve;ng.</p>", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("135cc273-c797-480f-ac39-cabfde885094"), false, "https://i.ibb.co/XjTB50K/chohaha.jpg", "Câu chuyện của MU", 0 });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "AccessFailedCount", "CommentId", "ConcurrencyStamp", "DateCreate", "DoB", "Email", "EmailConfirmed", "FirstName", "Gender", "IdImageAvatar", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("135cc273-c797-480f-ac39-cabfde885094"), 0, null, "e5d520be-029c-4a3e-b029-71bd98f253e4", new DateTime(2022, 8, 24, 14, 49, 54, 545, DateTimeKind.Local).AddTicks(7891), new DateTime(2001, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "huynhnhat@gmail.com", true, "Nhật", true, null, true, "Huỳnh", false, null, "naruto", null, "nhathuynh", "AQAAAAEAACcQAAAAEJ7GQKUmFW/iHcAV8VjIAgMlijGRVmu9hE9IvLlkxELpA8E046AUHF1hcUxMIllWRg==", "1000000002", false, "", false, "nhathuynh" },
                    { new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"), 0, null, "3ec8c1c5-0e11-4eb1-b562-08f809a475c5", new DateTime(2022, 8, 24, 14, 49, 54, 558, DateTimeKind.Local).AddTicks(4212), new DateTime(2001, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "daiphuoc@gmail.com", true, "Đại Phước", true, null, true, "Dương", false, null, "sasuke", null, "phuochuynh", "AQAAAAEAACcQAAAAEN+nVV18PP9fx8kdvm1kRqfBDqvLCqMhJMQm/enElPrJLMr84KIHQ6IJYFwko23ElQ==", "1000000003", false, "", false, "phuochuynh" }
                });

            migrationBuilder.InsertData(
                table: "WebRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("e2189174-217b-4540-9563-49f24a901712"), "a618f348-e715-4ffb-a683-98542de7eb17", "Đây là Viewer", "Viewer", "Viewer" },
                    { new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7"), "9fd291b3-aca9-47ce-9cd2-6d353c85f852", "Đây là manger", "Manager", "Manager" },
                    { new Guid("3f2be8b9-769d-49f5-8387-f34413daa629"), "f790f4e6-9102-48d5-b733-d6ae5e852693", "Đây là Blogger", "Blogger", "Blogger" }
                });

            migrationBuilder.InsertData(
                table: "AnnouncementInUsers",
                columns: new[] { "IdAnnouncement", "IdUser", "IsViewed" },
                values: new object[] { new Guid("2b38ab59-ac01-4a2a-8aae-772d258d6fba"), new Guid("135cc273-c797-480f-ac39-cabfde885094"), false });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("135cc273-c797-480f-ac39-cabfde885094"), new Guid("3f2be8b9-769d-49f5-8387-f34413daa629") },
                    { new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"), new Guid("e2189174-217b-4540-9563-49f24a901712") }
                });

            migrationBuilder.InsertData(
                table: "CatalogInUsers",
                columns: new[] { "IdCatalog", "IdUser" },
                values: new object[] { 1, new Guid("135cc273-c797-480f-ac39-cabfde885094") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DateComment", "IdNews", "IdUser", "ParentId" },
                values: new object[] { 1, "Chị bảy mãi đỉnh", new DateTime(2022, 10, 15, 5, 3, 4, 0, DateTimeKind.Unspecified), new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"), new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"), null });

            migrationBuilder.InsertData(
                table: "HistoryLikes",
                columns: new[] { "IdNews", "IdUser", "DateLike", "IsLike" },
                values: new object[] { new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"), new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"), new DateTime(2022, 10, 15, 7, 3, 4, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "HistoryViews",
                columns: new[] { "IdNews", "IdUser", "DateView" },
                values: new object[] { new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"), new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"), new DateTime(2022, 10, 15, 4, 3, 4, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ImageInNewss",
                columns: new[] { "IdNews", "IdImageNews", "Order" },
                values: new object[,]
                {
                    { new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"), new Guid("522f6338-202b-4409-b3b5-bac401a94b02"), 0 },
                    { new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"), new Guid("23bc1330-bbc6-4e22-b3da-b0b3ace9e2fd"), 0 }
                });

            migrationBuilder.InsertData(
                table: "NewsInCatalogs",
                columns: new[] { "IdCatalog", "IdNews" },
                values: new object[] { 1, new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e") });

            migrationBuilder.InsertData(
                table: "ReportComments",
                columns: new[] { "IDReportComment", "ContentReport", "DateReport", "IdComment", "IdReporter" },
                values: new object[] { 1, "Comment gay war, xoa no di!", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("135cc273-c797-480f-ac39-cabfde885094") });

            migrationBuilder.InsertData(
                table: "RoleFuncs",
                columns: new[] { "Id", "Description", "IdFunc", "IdRole" },
                values: new object[,]
                {
                    { 3, null, 3, new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7") },
                    { 5, null, 4, new Guid("3f2be8b9-769d-49f5-8387-f34413daa629") },
                    { 1, null, 1, new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7") },
                    { 6, null, 4, new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7") },
                    { 4, null, 1, new Guid("3f2be8b9-769d-49f5-8387-f34413daa629") },
                    { 2, null, 2, new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7") }
                });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "AccessFailedCount", "CommentId", "ConcurrencyStamp", "DateCreate", "DoB", "Email", "EmailConfirmed", "FirstName", "Gender", "IdImageAvatar", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"), 0, null, "2ef4cd6f-989f-4ba0-ac9e-254185b060aa", new DateTime(2022, 8, 24, 14, 49, 54, 532, DateTimeKind.Local).AddTicks(5712), new DateTime(2001, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "loileminh@gmail.com", true, "Lợi", true, new Guid("0619e3c9-a3ba-46ca-ba72-1136c388d003"), true, "Lê Minh", false, null, "leminhloi", null, "leminhloi", "AQAAAAEAACcQAAAAEOVtRLqYvRugk+3EqmdxewZxZd16nRBnTEgQFIP1Z7YQjlq4IfTjysWEsSs3vU3d0w==", "0674123453", false, "", false, "leminhloi" });

            migrationBuilder.InsertData(
                table: "AnnouncementInUsers",
                columns: new[] { "IdAnnouncement", "IdUser", "IsViewed" },
                values: new object[] { new Guid("0c794979-ac1a-45f2-92e7-a6f0e0ef2604"), new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"), false });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"), new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7") });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "IdRoleFunc", "IdUser" },
                values: new object[,]
                {
                    { 1, new Guid("135cc273-c797-480f-ac39-cabfde885094") },
                    { 1, new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0") },
                    { 2, new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0") },
                    { 3, new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0") },
                    { 4, new Guid("135cc273-c797-480f-ac39-cabfde885094") },
                    { 4, new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementInUsers_IdUser",
                table: "AnnouncementInUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogInUsers_IdUser",
                table: "CatalogInUsers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdNews",
                table: "Comments",
                column: "IdNews");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdUser",
                table: "Comments",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryLikes_IdUser",
                table: "HistoryLikes",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryViews_IdUser",
                table: "HistoryViews",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ImageInNewss_IdImageNews",
                table: "ImageInNewss",
                column: "IdImageNews");

            migrationBuilder.CreateIndex(
                name: "IX_NewsInCatalogs_IdNews",
                table: "NewsInCatalogs",
                column: "IdNews");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_IdUser",
                table: "Permissions",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ReportComments_IdReporter",
                table: "ReportComments",
                column: "IdReporter");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFuncs_IdFunc",
                table: "RoleFuncs",
                column: "IdFunc");

            migrationBuilder.CreateIndex(
                name: "IX_RoleFuncs_IdRole",
                table: "RoleFuncs",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_CommentId",
                table: "UserInfos",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_IdImageAvatar",
                table: "UserInfos",
                column: "IdImageAvatar",
                unique: true,
                filter: "[IdImageAvatar] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "UserInfos",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "UserInfos",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "WebRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnouncementInUsers_UserInfos_IdUser",
                table: "AnnouncementInUsers",
                column: "IdUser",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogInUsers_UserInfos_IdUser",
                table: "CatalogInUsers",
                column: "IdUser",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_Comments_CommentId",
                table: "UserInfos",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserInfos_IdUser",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "AnnouncementInUsers");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "CatalogInUsers");

            migrationBuilder.DropTable(
                name: "HistoryLikes");

            migrationBuilder.DropTable(
                name: "HistoryViews");

            migrationBuilder.DropTable(
                name: "ImageInNewss");

            migrationBuilder.DropTable(
                name: "NewsInCatalogs");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "ReportComments");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "ImageNewss");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "RoleFuncs");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "WebRoles");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ImageUsers");

            migrationBuilder.DropTable(
                name: "Newss");
        }
    }
}
