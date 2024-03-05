using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class AddFinanceAccountDepartmentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinanceAccountTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    AccountGuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceAccountTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinanceDepartmentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceDepartmentTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinanceAccountDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceAccountDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceAccountDepartment_FinanceAccountTable_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FinanceAccountTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanceAccountDepartment_FinanceDepartmentTable_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "FinanceDepartmentTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_FinanceAccountDepartment_AccountId",
                table: "FinanceAccountDepartment",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinanceAccountDepartment_DepartmentId",
                table: "FinanceAccountDepartment",
                column: "DepartmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceAccountDepartment");

            migrationBuilder.DropTable(
                name: "FinanceAccountTable");

            migrationBuilder.DropTable(
                name: "FinanceDepartmentTable");

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
                columns: new[] { "CreatedAt", "Password", "Salt", "UserRolesJson" },
                values: new object[] { new DateTime(2024, 3, 2, 15, 28, 34, 208, DateTimeKind.Utc).AddTicks(5702), "UEBzc3dvcmRkY2FjMmYyMi0wMGViLTQ4ZGMtOGRiOS1kMWY3MTQwNGQ3YjQ=", "dcac2f22-00eb-48dc-8db9-d1f71404d7b4", "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-02T15:28:34.2085704Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}" });
        }
    }
}
