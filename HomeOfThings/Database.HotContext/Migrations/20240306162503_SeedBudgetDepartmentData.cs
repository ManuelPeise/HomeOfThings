using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedBudgetDepartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5080), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5085), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5086) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5088), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5088) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5089), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5091), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5092) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5095), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5095) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5097), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5097) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5098), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5100), new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5101) });

            migrationBuilder.InsertData(
                table: "BudgetDepartmentTable",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Key", "ParentAccountId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5311), "System", "labelFamilyActivities", 1, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5312), "System" },
                    { 2, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5315), "System", "labelWorkShop", 2, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5316), "System" },
                    { 3, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5317), "System", "labelRefuel", 2, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5318), "System" },
                    { 4, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5319), "System", "labelTransfer", 3, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5320), "System" },
                    { 5, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5321), "System", "labelTeleCommunication", 4, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5322), "System" },
                    { 6, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5324), "System", "labelRestaurantVisit", 5, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5325), "System" },
                    { 7, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5326), "System", "labelSalary", 6, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5327), "System" },
                    { 8, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5328), "System", "labelOtherIncome", 6, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5329), "System" },
                    { 9, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5330), "System", "labelReside", 7, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5331), "System" },
                    { 10, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5333), "System", "labelEnergy", 7, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5334), "System" },
                    { 11, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5335), "System", "labelGroceries", 8, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5336), "System" },
                    { 12, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5337), "System", "labelTobacco", 8, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5338), "System" },
                    { 13, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5339), "System", "labelAccommodation", 9, new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(5339), "System" },
                    { 14, null, null, "labelTouristTax", 9, null, null }
                });

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(4143));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 25, 3, 439, DateTimeKind.Utc).AddTicks(4560), "UEBzc3dvcmQyMTEwYzU3ZC00NTk3LTQ4OTktODdiZS1lZTdmNGFmMjM2ZjY=", "2110c57d-4597-4899-87be-ee7f4af236f6", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-06T16:25:03.4394563Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BudgetDepartmentTable",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2862), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2864) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2869), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2870) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2872), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2873) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2875), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2876) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2878), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2885), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2889), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2892), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2893) });

            migrationBuilder.UpdateData(
                table: "BudgetAccountTable",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2895), new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 6, 16, 23, 51, 516, DateTimeKind.Utc).AddTicks(2010), "UEBzc3dvcmQ5NzI4YzE0MS0wZWQ5LTQ2MWYtOWM0My1hNDJmMGNjZDQ4ZjU=", "9728c141-0ed9-461f-9c43-a42f0ccd48f5", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-06T16:23:51.5162013Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
