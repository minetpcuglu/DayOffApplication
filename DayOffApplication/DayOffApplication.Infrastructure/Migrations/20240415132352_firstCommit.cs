using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DayOffApplication.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByEmail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModificationByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeletedByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserType = table.Column<byte>(type: "tinyint", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByEmail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModificationByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeletedByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CumulativeLeaveRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveType = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Years = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByEmail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModificationByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeletedByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CumulativeLeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CumulativeLeaveRequest_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RequestNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LeaveType = table.Column<byte>(type: "tinyint", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkflowStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByEmail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModificationByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeletedByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_Employee_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CumulativeLeaveRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByEmail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ModificationByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeletedByEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_CumulativeLeaveRequest_CumulativeLeaveRequestId",
                        column: x => x.CumulativeLeaveRequestId,
                        principalTable: "CumulativeLeaveRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Notification_Employee_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

      

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Active", "CreatedByEmail", "CreationTime", "DeletedByEmail", "DeletionTime", "Description", "ModificationByEmail", "ModificationTime", "Name" },
                values: new object[] { new Guid("9f176152-1b24-4fd5-be02-389b5d5929c9"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "IT", null, null, "IT" });

            migrationBuilder.InsertData(
          table: "Employee",
          columns: new[] { "Id", "Active", "CreatedByEmail", "CreationTime", "DeletedByEmail", "DeletionTime", "Email", "FirstName", "LastName", "ManagerId", "ModificationByEmail", "ModificationTime", "UserType" },
          values: new object[,]
          {
                    { new Guid("4c26c912-1364-4d48-b028-fff51c32da28"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "gönültopcuoglu@gmail.com", "Emre", "Topcuoglu", null, null, null, (byte)20 },
                    { new Guid("52985816-c3d5-4b21-bbbe-d6e5c7434c4c"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "osmantopcuoglu@gmail.com", "Elif", "Topcuoglu", null, null, null, (byte)10 },
                    { new Guid("ecad7d11-a405-4956-942b-eafcf2cb379a"), true, "system@gmail.com", new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478), null, null, "minetopcuoglu6@gmail.com", "Mine", "Topcuoglu", new Guid("9f176152-1b24-4fd5-be02-389b5d5929c9"), null, null, (byte)30 }
          });
            migrationBuilder.CreateIndex(
                name: "IX_CumulativeLeaveRequest_UserId",
                table: "CumulativeLeaveRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_AssignedUserId",
                table: "LeaveRequest",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CumulativeLeaveRequestId",
                table: "Notification",
                column: "CumulativeLeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "CumulativeLeaveRequest");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Manager");
        }
    }
}
