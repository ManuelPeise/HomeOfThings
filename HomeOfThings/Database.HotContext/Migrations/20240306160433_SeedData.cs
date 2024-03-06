using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BudgetAccountTable",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Key", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2215), "System", "labelActivities", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2216), "System" },
                    { 2, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2220), "System", "labelCar", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2221), "System" },
                    { 3, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2222), "System", "labelCarryOfLastMonth", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2223), "System" },
                    { 4, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2224), "System", "labelCommunication", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2225), "System" },
                    { 5, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2226), "System", "labelGastronomy", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2227), "System" },
                    { 6, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2230), "System", "labelIncome", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2230), "System" },
                    { 7, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2232), "System", "labelReside", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2232), "System" },
                    { 8, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2233), "System", "labelShopping", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2234), "System" },
                    { 9, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2235), "System", "labelTobacco", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2236), "System" },
                    { 10, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2238), "System", "labelVacation", new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(2239), "System" }
                });

            migrationBuilder.InsertData(
                table: "UserRolesTable",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(1132), "System", "Default User", "User", null, null },
                    { 2, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(1139), "System", "Admin User", "Admin", null, null },
                    { 3, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(1140), "System", "System Admin User", "System Admin", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "IsActive", "LastName", "Password", "Salt", "UpdatedAt", "UpdatedBy", "UserRolesJson" },
                values: new object[] { 1, new DateTime(2024, 3, 6, 16, 4, 33, 46, DateTimeKind.Utc).AddTicks(1629), "System", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "exampleuser@gmx.com", false, "", true, "", "UEBzc3dvcmRlNGI4NzJlNC00ZmNjLTRhNmMtODEzNi1iZTM3YzliYmJhOGI=", "e4b872e4-4fcc-4a6c-8136-be37c9bbba8b", null, null, "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-06T16:04:33.0461631Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 10);

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
