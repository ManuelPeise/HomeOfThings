using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class ExtendFinanceManagementTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "FinanceDepartmentTable");

            migrationBuilder.DropColumn(
                name: "AccountGuid",
                table: "FinanceAccountTable");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "FinanceDepartmentTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "FinanceAccountDepartment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPayment",
                table: "FinanceAccountDepartment",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "FinanceAccountDepartment",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 27, 39, 615, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 27, 39, 615, DateTimeKind.Utc).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 27, 39, 615, DateTimeKind.Utc).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 5, 22, 27, 39, 615, DateTimeKind.Utc).AddTicks(777), "UEBzc3dvcmQ2N2ViZjA0Yi0yZWZjLTQ4YzEtYWNmMS1iMmM3NjE2YmMyMmI=", "67ebf04b-2efc-48c1-acf1-b2c7616bc22b", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-05T22:27:39.6150778Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "FinanceAccountDepartment");

            migrationBuilder.DropColumn(
                name: "IsPayment",
                table: "FinanceAccountDepartment");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "FinanceAccountDepartment");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "FinanceDepartmentTable",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "FinanceDepartmentTable",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AccountGuid",
                table: "FinanceAccountTable",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 18, 43, 405, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 18, 43, 405, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.UpdateData(
                table: "UserRolesTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 5, 22, 18, 43, 405, DateTimeKind.Utc).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "UserTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 5, 22, 18, 43, 405, DateTimeKind.Utc).AddTicks(8574), "UEBzc3dvcmQxMDA2MDBmYi1iMWQzLTQ1MmEtYjk5Ny04MTU1NGMyN2U4MmI=", "100600fb-b1d3-452a-b997-81554c27e82b", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-05T22:18:43.4058576Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
