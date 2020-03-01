using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectContext.Migrations
{
    public partial class ModifyModel_Account_TransferMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferMoney_Accounts_AccountId",
                table: "TransferMoney");

            migrationBuilder.DropIndex(
                name: "IX_TransferMoney_AccountId",
                table: "TransferMoney");

            migrationBuilder.AlterColumn<string>(
                name: "SendAccountNumber",
                table: "TransferMoney",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferMoneyId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TransferMoneyId",
                table: "Accounts",
                column: "TransferMoneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_TransferMoney_TransferMoneyId",
                table: "Accounts",
                column: "TransferMoneyId",
                principalTable: "TransferMoney",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_TransferMoney_TransferMoneyId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_TransferMoneyId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TransferMoneyId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "SendAccountNumber",
                table: "TransferMoney",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_TransferMoney_AccountId",
                table: "TransferMoney",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferMoney_Accounts_AccountId",
                table: "TransferMoney",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
