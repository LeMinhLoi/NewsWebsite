using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebsite.Data.Migrations
{
    public partial class Add_ImageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tittle",
                table: "Newss",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Newss",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SrcCoverImage",
                table: "Newss",
                unicode: false,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Newss",
                keyColumn: "IdNews",
                keyValue: new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"),
                columns: new[] { "Content", "DateCreate", "SrcCoverImage", "Tittle" },
                values: new object[] { "<p>Erik ten Hag đ&atilde; sớm phải nhận những &aacute;p lực, v&agrave; người h&acirc;m mộ Quỷ đỏ c&oacute; l&yacute; do để b&agrave;y tỏ sự kh&ocirc;ng h&agrave;i l&ograve;ng.</p>", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i.ibb.co/XjTB50K/chohaha.jpg", "Câu chuyện của MU" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("135cc273-c797-480f-ac39-cabfde885094"),
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "f298e460-5fda-4267-93d5-237c499cf1f0", new DateTime(2022, 8, 17, 9, 59, 14, 714, DateTimeKind.Local).AddTicks(6575), "AQAAAAEAACcQAAAAEIopCujmejQquWx+3yZK5RuKDlXktKtiqzniMzRj+cm0NHgaoNgi6QzK5EmIw4JBgA==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"),
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "183d9c6b-cb9d-4cfa-9ea7-0d65ca772ea5", new DateTime(2022, 8, 17, 9, 59, 14, 726, DateTimeKind.Local).AddTicks(6926), "AQAAAAEAACcQAAAAEHLHkCU0afokbci7h6VxNVDCIwCCqm8jHrPaJ2aeD0o/2OExTVvGTVUtLYZBqBd1NQ==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"),
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "0f7bbaf5-cc57-40d2-baff-60bbc7b4a31b", new DateTime(2022, 8, 17, 9, 59, 14, 693, DateTimeKind.Local).AddTicks(6439), "AQAAAAEAACcQAAAAEH5DUBb5IqlKiquFXUfdb3RzvtWPpa3Aojfj4PG2/0qrtA4Flnf/penTLHGwDxMR4w==" });

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2be8b9-769d-49f5-8387-f34413daa629"),
                column: "ConcurrencyStamp",
                value: "627a1cce-e259-4e5d-9d66-94dbc5b63425");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7"),
                column: "ConcurrencyStamp",
                value: "5a26f202-ec2e-4560-9522-480b211fa5a1");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2189174-217b-4540-9563-49f24a901712"),
                column: "ConcurrencyStamp",
                value: "4cc87390-91c9-48e1-b09d-0b098e6137ad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrcCoverImage",
                table: "Newss");

            migrationBuilder.AlterColumn<string>(
                name: "Tittle",
                table: "Newss",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Newss",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false);

            migrationBuilder.UpdateData(
                table: "Newss",
                keyColumn: "IdNews",
                keyValue: new Guid("6d26e9ea-3b32-44be-ac21-090c06bbf14e"),
                columns: new[] { "Content", "DateCreate", "Tittle" },
                values: new object[] { "<p><b>Hi! Đây là một bài báo viết về thể thao.</b></p><p><u>Chị bảy đang chuồn khỏi MU</u></p>", new DateTime(2022, 10, 10, 2, 3, 4, 0, DateTimeKind.Unspecified), "SƯ TRỐN CHẠY" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("135cc273-c797-480f-ac39-cabfde885094"),
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "fe7a8faa-aaba-4b4c-918f-425363245f48", new DateTime(2022, 8, 5, 11, 20, 34, 610, DateTimeKind.Local).AddTicks(1118), "AQAAAAEAACcQAAAAEH2Se6DTagNuRq3tKlxkNl/pjB4cvAP7Fy0gAXbAkQf6m1WczWMTHFFL6zXcPOrkbw==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"),
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "5867a7b5-1d74-4670-9246-c90ac92f71f2", new DateTime(2022, 8, 5, 11, 20, 34, 628, DateTimeKind.Local).AddTicks(6816), "AQAAAAEAACcQAAAAEDYddsMiCMUIaeXRKKuNeaCECjz6ElYMsCP+G0ke6oUxk0M212Lx1dZfRA9HN0pVqA==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"),
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "f4e0aa69-5754-4efc-81f9-6d20178f73bd", new DateTime(2022, 8, 5, 11, 20, 34, 590, DateTimeKind.Local).AddTicks(4704), "AQAAAAEAACcQAAAAENeX6KkJ1KAiZujbDpwL8uI84Jtw6T96BgltznyxKga5hc/fVawmNFGVlWmU1EcpQg==" });

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2be8b9-769d-49f5-8387-f34413daa629"),
                column: "ConcurrencyStamp",
                value: "80be8c81-cfaf-414a-859f-84371895475e");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7"),
                column: "ConcurrencyStamp",
                value: "2ee9c410-0836-480d-b3f8-4d3db5dcb0b7");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2189174-217b-4540-9563-49f24a901712"),
                column: "ConcurrencyStamp",
                value: "e9bdc416-c878-4132-bed6-053e8475afae");
        }
    }
}
