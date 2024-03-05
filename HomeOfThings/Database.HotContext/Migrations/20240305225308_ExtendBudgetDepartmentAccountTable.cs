using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class ExtendBudgetDepartmentAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BudgetDepartmentAccountTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1567));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1960), "UEBzc3dvcmRiZmZjYjEzMy02ZTM0LTRmYzUtOGU5My1kNGM3OGE4YWE5NmE=", "bffcb133-6e34-4fc5-8e93-d4c78a8aa96a", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-05T22:53:08.4321962Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BudgetDepartmentAccountTable");

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 36, 29, 744, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 36, 29, 744, DateTimeKind.Utc).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 36, 29, 744, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 5, 22, 36, 29, 744, DateTimeKind.Utc).AddTicks(7858), "UEBzc3dvcmQyOWE1NGFiNS1hNTY0LTQyMmMtYmEzZS01ZmIxMTQ5OWU1ZTE=", "29a54ab5-a564-422c-ba3e-5fb11499e5e1", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-05T22:36:29.744786Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
