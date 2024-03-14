using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class ExtendUserRoleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserRolesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "RoleId" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3529), 0 });

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
                columns: new[] { "CreatedAt", "Name", "RoleId" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3540), "SystemAdmin", 0 });

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 14, 20, 44, 23, 43, DateTimeKind.Utc).AddTicks(3941), "UEBzc3dvcmQ3NzQ1MjI1Yy02Mzg2LTQ0NzYtYWE5OC1hOGU3M2NiNjdiMWY=", "7745225c-6386-4476-aa98-a8e73cb67b1f", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"RoleId\":0,\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-14T20:44:23.0433943Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserRolesTable");

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
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2024, 3, 13, 14, 8, 37, 918, DateTimeKind.Utc).AddTicks(2916), "System Admin" });

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 13, 14, 8, 37, 918, DateTimeKind.Utc).AddTicks(3440), "UEBzc3dvcmRkNmNiYWFhOC0yOWY0LTQ5YWYtOTUwYS1iNWYzYTRiYTEyNDE=", "d6cbaaa8-29f4-49af-950a-b5f3a4ba1241", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-13T14:08:37.9183442Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
