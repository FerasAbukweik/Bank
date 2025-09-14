using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class starteverythingstartswithtransactionwithbankbacauseaspnetalreadyusestransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountTypes_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionInfo_transactionInfo_id__status",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionInfo_transactionInfo_id__type",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "transactionInfo_id__type",
                table: "transactions",
                newName: "bankTransactionType_id");

            migrationBuilder.RenameColumn(
                name: "transactionInfo_id__status",
                table: "transactions",
                newName: "bankTransactionStatus_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_transactionInfo_id__type",
                table: "transactions",
                newName: "IX_transactions_bankTransactionType_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_transactionInfo_id__status",
                table: "transactions",
                newName: "IX_transactions_bankTransactionStatus_id");

            migrationBuilder.RenameColumn(
                name: "accountTypes_id",
                table: "accounts",
                newName: "accountType_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_accountTypes_id",
                table: "accounts",
                newName: "IX_accounts_accountType_id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountType_id",
                table: "accounts",
                column: "accountType_id",
                principalTable: "accountInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactionInfo_bankTransactionType_id",
                table: "transactions",
                column: "bankTransactionType_id",
                principalTable: "transactionInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactionStatuses_bankTransactionStatus_id",
                table: "transactions",
                column: "bankTransactionStatus_id",
                principalTable: "transactionStatuses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountType_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionInfo_bankTransactionType_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionStatuses_bankTransactionStatus_id",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "bankTransactionType_id",
                table: "transactions",
                newName: "transactionInfo_id__type");

            migrationBuilder.RenameColumn(
                name: "bankTransactionStatus_id",
                table: "transactions",
                newName: "transactionInfo_id__status");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_bankTransactionType_id",
                table: "transactions",
                newName: "IX_transactions_transactionInfo_id__type");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_bankTransactionStatus_id",
                table: "transactions",
                newName: "IX_transactions_transactionInfo_id__status");

            migrationBuilder.RenameColumn(
                name: "accountType_id",
                table: "accounts",
                newName: "accountTypes_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_accountType_id",
                table: "accounts",
                newName: "IX_accounts_accountTypes_id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountTypes_id",
                table: "accounts",
                column: "accountTypes_id",
                principalTable: "accountInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactionInfo_transactionInfo_id__status",
                table: "transactions",
                column: "transactionInfo_id__status",
                principalTable: "transactionInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactionInfo_transactionInfo_id__type",
                table: "transactions",
                column: "transactionInfo_id__type",
                principalTable: "transactionInfo",
                principalColumn: "id");
        }
    }
}
