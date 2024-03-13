using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetAccountTable");

            migrationBuilder.DropTable(
                name: "BudgetDepartmentAccountTable");

            migrationBuilder.DropTable(
                name: "BudgetDepartmentTable");

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyGuid",
                table: "UserTable",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FamilyTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    FamilyGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 8, 37, 918, DateTimeKind.Utc).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 8, 37, 918, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 13, 14, 8, 37, 918, DateTimeKind.Utc).AddTicks(2916));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "FamilyGuid", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 13, 14, 8, 37, 918, DateTimeKind.Utc).AddTicks(3440), "systemAdmin@hot.com", null, "UEBzc3dvcmRkNmNiYWFhOC0yOWY0LTQ5YWYtOTUwYS1iNWYzYTRiYTEyNDE=", "d6cbaaa8-29f4-49af-950a-b5f3a4ba1241", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-13T14:08:37.9183442Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyTable");

            migrationBuilder.DropColumn(
                name: "FamilyGuid",
                table: "UserTable");

            migrationBuilder.CreateTable(
                name: "BudgetAccountTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAccountTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BudgetDepartmentAccountTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetAccountId = table.Column<int>(type: "int", nullable: false),
                    BudgetDepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    IsPayment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDepartmentAccountTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BudgetDepartmentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    ParentAccountId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDepartmentTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 19, 51, 21, 205, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 19, 51, 21, 205, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 19, 51, 21, 205, DateTimeKind.Utc).AddTicks(9221));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 6, 19, 51, 21, 205, DateTimeKind.Utc).AddTicks(9599), "exampleuser@gmx.com", "UEBzc3dvcmRkMTJlNjc1Ny0wYmM0LTRjOTEtODAwYy1iZWMyMmJjZGNjYjA=", "d12e6757-0bc4-4c91-800c-bec22bcdccb0", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-06T19:51:21.20596Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
