using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebsite.Data.Migrations
{
    public partial class CreateNewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "ImageUsers");

            migrationBuilder.UpdateData(
                table: "ImageUsers",
                keyColumn: "IdImage",
                keyValue: new Guid("0619e3c9-a3ba-46ca-ba72-1136c388d003"),
                column: "Path",
                value: "/themes/images/images_user/leminhloi.png");

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("135cc273-c797-480f-ac39-cabfde885094"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "632608a7-abe3-4480-8267-7001274d739e", "AQAAAAEAACcQAAAAENW6V8tBbYpwaagyCkjTUsG0Fj1iRSVBQqik/c8KglTxNsjbkpsPM56hl50Yygo//g==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "527e50c7-9f09-4d75-9a87-e07f34b955b4", "AQAAAAEAACcQAAAAEFXHYDQxpIcyg1R45g5ncGscfgwIwvZ4DIuYbRMkreEXdEb8szLa3NNCrGj6XleGzA==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4bbc029-0b38-4bb8-bbe3-7fe76cc2b69e", "AQAAAAEAACcQAAAAEH6shzjDWTqc7jQBKgJ4gA3jKxO0Bpr6mhJmBV8Dt4BnwYpXyzzTL3lgfKaCkRbbwQ==" });

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2be8b9-769d-49f5-8387-f34413daa629"),
                column: "ConcurrencyStamp",
                value: "8c39b333-f707-41d1-9866-371faf3ad745");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7"),
                column: "ConcurrencyStamp",
                value: "ba3973d4-25e5-410e-b610-bdacc14ae2c0");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2189174-217b-4540-9563-49f24a901712"),
                column: "ConcurrencyStamp",
                value: "b34dbfa9-712b-46db-b8a1-56f214a8607c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "ImageUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ImageUsers",
                keyColumn: "IdImage",
                keyValue: new Guid("0619e3c9-a3ba-46ca-ba72-1136c388d003"),
                columns: new[] { "Path", "Tittle" },
                values: new object[] { "themes/images/images_user/leminhloi.png", "This is tittle" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("135cc273-c797-480f-ac39-cabfde885094"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d18a1e51-9ec7-44c6-8b3e-a4fc2e452fd0", "AQAAAAEAACcQAAAAEM4B6zfXsjgKfGGGhN7E6Q/qUWqA/DsbzjWLJVy+fpyj6tnsARSttuwl/ORuOpV+CA==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("4008d551-f305-4bc5-b143-6caa9e7e6acb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ad23ec1-709a-4e51-b608-cbf869c5c77a", "AQAAAAEAACcQAAAAEPb9XVN8zzdscGpbnCMabcXruZHf9sX2WQ4x3kHjlej02quam5H6y3gfRlV1IhOcMw==" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: new Guid("f2c7b584-2bec-4a0c-896b-0aae5084afe0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "90c50d74-09ac-49d2-ae17-74a146dae822", "AQAAAAEAACcQAAAAEPRRQO+IYUFgNb8EzC64htr+5oM23V+ar/auE+07fSJMApfo/2lrbsfK7TLPCRqtZw==" });

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2be8b9-769d-49f5-8387-f34413daa629"),
                column: "ConcurrencyStamp",
                value: "b00f7353-824d-4207-9584-acc9caa28cd9");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("68f98061-01ba-4263-ab94-65a0cb908ab7"),
                column: "ConcurrencyStamp",
                value: "74ecaa85-2348-42a9-8e5b-096db5de6c8d");

            migrationBuilder.UpdateData(
                table: "WebRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2189174-217b-4540-9563-49f24a901712"),
                column: "ConcurrencyStamp",
                value: "05f7e688-aec2-465c-957d-ca21501d7111");
        }
    }
}
