using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomePlannerDB.Migrations
{
    public partial class salarydetailstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinancialYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChapterVIAOtherSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FinancialYear = table.Column<int>(nullable: false),
                    TaxRegimeType = table.Column<int>(nullable: false),
                    NationalPensionScheme = table.Column<double>(nullable: false),
                    Mediclaim = table.Column<double>(nullable: false),
                    DisabledDependent = table.Column<double>(nullable: false),
                    MedicalExpenses = table.Column<double>(nullable: false),
                    EducationLoanInterest = table.Column<double>(nullable: false),
                    HousingLoanInterest = table.Column<double>(nullable: false),
                    Donations = table.Column<double>(nullable: false),
                    DepositInterest = table.Column<double>(nullable: false),
                    TotalInvestments = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterVIAOtherSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterVIAOtherSections_FinancialYears_FinancialYear",
                        column: x => x.FinancialYear,
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterVIAOtherSections_TaxRegimes_TaxRegimeType",
                        column: x => x.TaxRegimeType,
                        principalTable: "TaxRegimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChapterVIASection80CC",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FinancialYear = table.Column<int>(nullable: false),
                    TaxRegimeType = table.Column<int>(nullable: false),
                    EmployeesProvidentFund = table.Column<double>(nullable: false),
                    PublicProvidentFund = table.Column<double>(nullable: false),
                    NationalSavingsCertificate = table.Column<double>(nullable: false),
                    LifeInsurancePremium = table.Column<double>(nullable: false),
                    MutualFunds = table.Column<double>(nullable: false),
                    TutionFee = table.Column<double>(nullable: false),
                    HomeLoanRepay = table.Column<double>(nullable: false),
                    Others = table.Column<double>(nullable: false),
                    TotalInvestments = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterVIASection80CC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterVIASection80CC_FinancialYears_FinancialYear",
                        column: x => x.FinancialYear,
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterVIASection80CC_TaxRegimes_TaxRegimeType",
                        column: x => x.TaxRegimeType,
                        principalTable: "TaxRegimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHouseRentExcemptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FinancialYear = table.Column<int>(nullable: false),
                    TaxRegimeType = table.Column<int>(nullable: false),
                    TotalRentPaidPerAnnum = table.Column<double>(nullable: false),
                    DearnessAllowance = table.Column<double>(nullable: false),
                    IsMetroCity = table.Column<bool>(nullable: false),
                    ExemptedAmount = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHouseRentExcemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHouseRentExcemptions_FinancialYears_FinancialYear",
                        column: x => x.FinancialYear,
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHouseRentExcemptions_TaxRegimes_TaxRegimeType",
                        column: x => x.TaxRegimeType,
                        principalTable: "TaxRegimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSalarys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FinancialYear = table.Column<int>(nullable: false),
                    TaxRegimeType = table.Column<int>(nullable: false),
                    BasicPay = table.Column<double>(nullable: false),
                    HousingRentAllowance = table.Column<double>(nullable: false),
                    LeaveTravelAllowance = table.Column<double>(nullable: false),
                    OtherAllowance = table.Column<double>(nullable: false),
                    Gratuity = table.Column<double>(nullable: false),
                    EmployerProvidentFund = table.Column<double>(nullable: false),
                    BonusPay = table.Column<double>(nullable: false),
                    VariablePay = table.Column<double>(nullable: false),
                    TotalIncome = table.Column<double>(nullable: false),
                    TaxableIncome = table.Column<double>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSalarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSalarys_FinancialYears_FinancialYear",
                        column: x => x.FinancialYear,
                        principalTable: "FinancialYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSalarys_TaxRegimes_TaxRegimeType",
                        column: x => x.TaxRegimeType,
                        principalTable: "TaxRegimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FinancialYears",
                columns: new[] { "Id", "IsDefault", "Year" },
                values: new object[,]
                {
                    { 1, false, "2018-2019" },
                    { 2, false, "2019-2020" },
                    { 3, false, "2020-2021" },
                    { 4, false, "2021-2022" },
                    { 5, false, "2022-2023" },
                    { 6, true, "2023-2024" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterVIAOtherSections_FinancialYear",
                table: "ChapterVIAOtherSections",
                column: "FinancialYear");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterVIAOtherSections_TaxRegimeType",
                table: "ChapterVIAOtherSections",
                column: "TaxRegimeType");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterVIASection80CC_FinancialYear",
                table: "ChapterVIASection80CC",
                column: "FinancialYear");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterVIASection80CC_TaxRegimeType",
                table: "ChapterVIASection80CC",
                column: "TaxRegimeType");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouseRentExcemptions_FinancialYear",
                table: "UserHouseRentExcemptions",
                column: "FinancialYear");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouseRentExcemptions_TaxRegimeType",
                table: "UserHouseRentExcemptions",
                column: "TaxRegimeType");

            migrationBuilder.CreateIndex(
                name: "IX_UserSalarys_FinancialYear",
                table: "UserSalarys",
                column: "FinancialYear");

            migrationBuilder.CreateIndex(
                name: "IX_UserSalarys_TaxRegimeType",
                table: "UserSalarys",
                column: "TaxRegimeType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChapterVIAOtherSections");

            migrationBuilder.DropTable(
                name: "ChapterVIASection80CC");

            migrationBuilder.DropTable(
                name: "UserHouseRentExcemptions");

            migrationBuilder.DropTable(
                name: "UserSalarys");

            migrationBuilder.DropTable(
                name: "FinancialYears");
        }
    }
}
