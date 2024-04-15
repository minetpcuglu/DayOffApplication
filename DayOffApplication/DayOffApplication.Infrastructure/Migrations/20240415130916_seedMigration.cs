using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DayOffApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Active", "CreatedByEmail", "CreationTime", "DeletedByEmail", "DeletionTime", "Email", "FirstName", "LastName", "ManagerId", "ModificationByEmail", "ModificationTime", "UserType" },
                values: new object[,]
                {
                    { new Guid("30e4bc17-f1a0-4e30-b010-bd6ced26b0c6"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "osmantopcuoglu@gmail.com", "Osman", "Topcuoglu", null, null, null, (byte)10 },
                    { new Guid("b14d3996-682c-4ae1-b80f-feeccddbba3c"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "gönültopcuoglu@gmail.com", "Gönül", "Topcuoglu", null, null, null, (byte)20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("30e4bc17-f1a0-4e30-b010-bd6ced26b0c6"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("b14d3996-682c-4ae1-b80f-feeccddbba3c"));

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
    }
}
