using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DayOffApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _1504seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("590c1b36-f5f6-4c38-995c-da43c194c511"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("5f5e5f53-dc99-4fdb-9602-604475d8fdcd"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("aca3b3cd-9376-47ea-b8c7-0b26815ba707"));

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Active", "CreatedByEmail", "CreationTime", "DeletedByEmail", "DeletionTime", "Email", "FirstName", "LastName", "ManagerId", "ModificationByEmail", "ModificationTime", "UserType" },
                values: new object[,]
                {
                    { new Guid("2d70cd56-99a7-4d57-86e8-072e1d650741"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "minetopcuoglu6@gmail.com", "Mine", "Topcuoglu", new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), null, null, (byte)30 },
                    { new Guid("989aee98-4d10-448f-83cf-ecfd588a912d"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "eliftopcuoglu@gmail.com", "Elif", "Topcuoglu", null, null, null, (byte)10 },
                    { new Guid("e8b07e0a-3e8c-4996-89e9-8b358093332c"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "emretopcuoglu@gmail.com", "Emre", "Topcuoglu", null, null, null, (byte)20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("2d70cd56-99a7-4d57-86e8-072e1d650741"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("989aee98-4d10-448f-83cf-ecfd588a912d"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("e8b07e0a-3e8c-4996-89e9-8b358093332c"));

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Active", "CreatedByEmail", "CreationTime", "DeletedByEmail", "DeletionTime", "Email", "FirstName", "LastName", "ManagerId", "ModificationByEmail", "ModificationTime", "UserType" },
                values: new object[,]
                {
                    { new Guid("590c1b36-f5f6-4c38-995c-da43c194c511"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "minetopcuoglu6@gmail.com", "Mine", "Topcuoglu", null, null, null, (byte)30 },
                    { new Guid("5f5e5f53-dc99-4fdb-9602-604475d8fdcd"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "emretopcuoglu@gmail.com", "Emre", "Topcuoglu", null, null, null, (byte)20 },
                    { new Guid("aca3b3cd-9376-47ea-b8c7-0b26815ba707"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "eliftopcuoglu@gmail.com", "Elif", "Topcuoglu", null, null, null, (byte)10 }
                });
        }
    }
}
