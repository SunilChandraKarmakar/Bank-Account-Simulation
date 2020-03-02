using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectContext.Migrations
{
    public partial class ModifyModel_Account_WithdrawMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WithdrawMoney_Accounts_AccountId",
                table: "WithdrawMoney");

            migrationBuilder.DropIndex(
                name: "IX_WithdrawMoney_AccountId",
                table: "WithdrawMoney");

            migrationBuilder.AlterColumn<string>(
                name: "WithdrawNumber",
                table: "WithdrawMoney",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WithdrawMoneyId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_WithdrawMoneyId",
                table: "Accounts",
                column: "WithdrawMoneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_WithdrawMoney_WithdrawMoneyId",
                table: "Accounts",
                column: "WithdrawMoneyId",
                principalTable: "WithdrawMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_WithdrawMoney_WithdrawMoneyId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_WithdrawMoneyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "WithdrawMoneyId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "WithdrawNumber",
                table: "WithdrawMoney",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawMoney_AccountId",
                table: "WithdrawMoney",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_WithdrawMoney_Accounts_AccountId",
                table: "WithdrawMoney",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
