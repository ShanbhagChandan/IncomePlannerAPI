using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomePlannerDB.Migrations
{
    public partial class expensetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpensesTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    FinancialYear = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesTables_FinancialYears_FinancialYear",
                        column: x => x.FinancialYear,
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    BaseCost = table.Column<double>(nullable: false),
                    AdditionalCost = table.Column<double>(nullable: false),
                    TotalCost = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensesItems_ExpensesTables_TableId",
                        column: x => x.TableId,
                        principalTable: "ExpensesTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesItems_TableId",
                table: "ExpensesItems",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesTables_FinancialYear",
                table: "ExpensesTables",
                column: "FinancialYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensesItems");

            migrationBuilder.DropTable(
                name: "ExpensesTables");
        }
    }
}
