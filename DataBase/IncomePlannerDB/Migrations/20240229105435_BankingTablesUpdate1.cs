using Microsoft.EntityFrameworkCore.Migrations;

namespace IncomePlannerDB.Migrations
{
    public partial class BankingTablesUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedDeposit_BankAccounts_AccountId",
                table: "FixedDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_MutualFund_BankAccounts_AccountId",
                table: "MutualFund");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringDeposit_BankAccounts_AccountId",
                table: "RecurringDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_Saving_BankAccounts_AccountId",
                table: "Saving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saving",
                table: "Saving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringDeposit",
                table: "RecurringDeposit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MutualFund",
                table: "MutualFund");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FixedDeposit",
                table: "FixedDeposit");

            migrationBuilder.RenameTable(
                name: "Saving",
                newName: "Savings");

            migrationBuilder.RenameTable(
                name: "RecurringDeposit",
                newName: "RecurringDeposits");

            migrationBuilder.RenameTable(
                name: "MutualFund",
                newName: "MutualFunds");

            migrationBuilder.RenameTable(
                name: "FixedDeposit",
                newName: "FixedDeposits");

            migrationBuilder.RenameIndex(
                name: "IX_Saving_AccountId",
                table: "Savings",
                newName: "IX_Savings_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringDeposit_AccountId",
                table: "RecurringDeposits",
                newName: "IX_RecurringDeposits_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_MutualFund_AccountId",
                table: "MutualFunds",
                newName: "IX_MutualFunds_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_FixedDeposit_AccountId",
                table: "FixedDeposits",
                newName: "IX_FixedDeposits_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Savings",
                table: "Savings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringDeposits",
                table: "RecurringDeposits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MutualFunds",
                table: "MutualFunds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FixedDeposits",
                table: "FixedDeposits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedDeposits_BankAccounts_AccountId",
                table: "FixedDeposits",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MutualFunds_BankAccounts_AccountId",
                table: "MutualFunds",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringDeposits_BankAccounts_AccountId",
                table: "RecurringDeposits",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_BankAccounts_AccountId",
                table: "Savings",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedDeposits_BankAccounts_AccountId",
                table: "FixedDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_MutualFunds_BankAccounts_AccountId",
                table: "MutualFunds");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringDeposits_BankAccounts_AccountId",
                table: "RecurringDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_BankAccounts_AccountId",
                table: "Savings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Savings",
                table: "Savings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringDeposits",
                table: "RecurringDeposits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MutualFunds",
                table: "MutualFunds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FixedDeposits",
                table: "FixedDeposits");

            migrationBuilder.RenameTable(
                name: "Savings",
                newName: "Saving");

            migrationBuilder.RenameTable(
                name: "RecurringDeposits",
                newName: "RecurringDeposit");

            migrationBuilder.RenameTable(
                name: "MutualFunds",
                newName: "MutualFund");

            migrationBuilder.RenameTable(
                name: "FixedDeposits",
                newName: "FixedDeposit");

            migrationBuilder.RenameIndex(
                name: "IX_Savings_AccountId",
                table: "Saving",
                newName: "IX_Saving_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RecurringDeposits_AccountId",
                table: "RecurringDeposit",
                newName: "IX_RecurringDeposit_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_MutualFunds_AccountId",
                table: "MutualFund",
                newName: "IX_MutualFund_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_FixedDeposits_AccountId",
                table: "FixedDeposit",
                newName: "IX_FixedDeposit_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saving",
                table: "Saving",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringDeposit",
                table: "RecurringDeposit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MutualFund",
                table: "MutualFund",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FixedDeposit",
                table: "FixedDeposit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedDeposit_BankAccounts_AccountId",
                table: "FixedDeposit",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MutualFund_BankAccounts_AccountId",
                table: "MutualFund",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringDeposit_BankAccounts_AccountId",
                table: "RecurringDeposit",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saving_BankAccounts_AccountId",
                table: "Saving",
                column: "AccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
