using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebsite.Data.Migrations
{
    public partial class AddDateCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "UserInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "UserInfos");

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
    }
}
