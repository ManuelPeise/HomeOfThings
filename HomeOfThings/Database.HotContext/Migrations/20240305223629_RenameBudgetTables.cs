using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.HotContext.Migrations
{
    /// <inheritdoc />
    public partial class RenameBudgetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceAccountDepartment");

            migrationBuilder.DropTable(
                name: "FinanceAccountTable");

            migrationBuilder.DropTable(
                name: "FinanceDepartmentTable");

            migrationBuilder.CreateTable(
                name: "BudgetAccountTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAccountTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BudgetDepartmentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDepartmentTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BudgetDepartmentAccountTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsPayment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDepartmentAccountTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetDepartmentAccountTable_BudgetAccountTable_AccountId",
                        column: x => x.AccountId,
                        principalTable: "BudgetAccountTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetDepartmentAccountTable_BudgetDepartmentTable_Departmen~",
                        column: x => x.DepartmentId,
                        principalTable: "BudgetDepartmentTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDepartmentAccountTable_AccountId",
                table: "BudgetDepartmentAccountTable",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDepartmentAccountTable_DepartmentId",
                table: "BudgetDepartmentAccountTable",
                column: "DepartmentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetDepartmentAccountTable");

            migrationBuilder.DropTable(
                name: "BudgetAccountTable");

            migrationBuilder.DropTable(
                name: "BudgetDepartmentTable");

            migrationBuilder.CreateTable(
                name: "FinanceAccountTable",
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
                    table.PrimaryKey("PK_FinanceAccountTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinanceDepartmentTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    Key = table.Column<string>(type: "longtext", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    IsPayment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
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
    }
}
