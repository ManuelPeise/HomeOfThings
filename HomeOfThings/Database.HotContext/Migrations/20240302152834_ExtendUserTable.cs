using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class ExtendUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "UserTable",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 15, 28, 34, 208, DateTimeKind.Utc).AddTicks(5311));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 15, 28, 34, 208, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 15, 28, 34, 208, DateTimeKind.Utc).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmailConfirmed", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 2, 15, 28, 34, 208, DateTimeKind.Utc).AddTicks(5702), false, "UEBzc3dvcmRkY2FjMmYyMi0wMGViLTQ4ZGMtOGRiOS1kMWY3MTQwNGQ3YjQ=", "dcac2f22-00eb-48dc-8db9-d1f71404d7b4", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-02T15:28:34.2085704Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "UserTable");

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(1115), "UEBzc3dvcmRjZTY5YzExNy0zNzk5LTQ4MjMtOTU5Ny01MDYxMGU3ZDViNjU=", "ce69c117-3799-4823-9597-50610e7d5b65", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-02T09:52:41.3111117Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
