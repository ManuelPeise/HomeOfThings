using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 20, 46, 35, 975, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RoleId" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 46, 35, 975, DateTimeKind.Utc).AddTicks(5958), 1 });

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "RoleId" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 46, 35, 975, DateTimeKind.Utc).AddTicks(5959), 2 });

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 46, 35, 975, DateTimeKind.Utc).AddTicks(6344), "UEBzc3dvcmQ0ZGVmNmI1My1iZTk5LTQ2MjItYmYzYi0yZWJmNzM1ZDY0MzI=", "4def6b53-be99-4622-bf3b-2ebf735d6432", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"RoleId\":0,\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-14T20:46:35.9756346Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RoleId" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3539), 0 });

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "RoleId" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3540), 0 });

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3941), "UEBzc3dvcmQ3NzQ1MjI1Yy02Mzg2LTQ0NzYtYWE5OC1hOGU3M2NiNjdiMWY=", "7745225c-6386-4476-aa98-a8e73cb67b1f", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"RoleId\":0,\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-14T20:44:23.0433943Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
