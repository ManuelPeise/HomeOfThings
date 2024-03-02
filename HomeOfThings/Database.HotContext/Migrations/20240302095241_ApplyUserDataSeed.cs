using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class ApplyUserDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRolesTable",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(609), "System", "Default User", "User", null, null },
                    { 2, new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(619), "System", "Admin User", "Admin", null, null },
                    { 3, new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(621), "System", "System Admin User", "System Admin", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FirstName", "IsActive", "LastName", "Password", "Salt", "UpdatedAt", "UpdatedBy", "UserRolesJson" },
                values: new object[] { 1, new DateTime(2024, 3, 2, 9, 52, 41, 311, DateTimeKind.Utc).AddTicks(1115), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "exampleuser@gmx.com", "", true, "", "UEBzc3dvcmRjZTY5YzExNy0zNzk5LTQ4MjMtOTU5Ny01MDYxMGU3ZDViNjU=", "ce69c117-3799-4823-9597-50610e7d5b65", null, null, "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-02T09:52:41.3111117Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
