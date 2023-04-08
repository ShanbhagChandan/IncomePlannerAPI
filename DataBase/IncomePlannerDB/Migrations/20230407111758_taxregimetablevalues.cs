using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomePlannerDB.Migrations
{
    public partial class taxregimetablevalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TaxRegimes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "TaxRegimes",
                columns: new[] { "Id", "IsDefault", "RegimeType" },
                values: new object[] { 1, false, "Old Tax Regime" });

            migrationBuilder.InsertData(
                table: "TaxRegimes",
                columns: new[] { "Id", "IsDefault", "RegimeType" },
                values: new object[] { 2, true, "New Tax Regime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxRegimes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxRegimes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TaxRegimes");
        }
    }
}
