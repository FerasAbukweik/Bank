using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "FK_transactions_accounts_account_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionInfo_transactionInfo_id__status",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionInfo_transactionInfo_id__type",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_transactions_from_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_transactions_to_id",
                table: "transfers");

            migrationBuilder.DropTable(
                name: "transactionInfo");

            migrationBuilder.DropTable(
                name: "transactionStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

            migrationBuilder.RenameTable(
                name: "transactions",
                newName: "bankTransactions");

            migrationBuilder.RenameColumn(
                name: "accountTypes_id",
                table: "accounts",
                newName: "accountType_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_accountTypes_id",
                table: "accounts",
                newName: "IX_accounts_accountType_id");

            migrationBuilder.RenameColumn(
                name: "transactionInfo_id__type",
                table: "bankTransactions",
                newName: "bankTransactionType_id");

            migrationBuilder.RenameColumn(
                name: "transactionInfo_id__status",
                table: "bankTransactions",
                newName: "bankTransactionStatus_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_transactionInfo_id__type",
                table: "bankTransactions",
                newName: "IX_bankTransactions_bankTransactionType_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_transactionInfo_id__status",
                table: "bankTransactions",
                newName: "IX_bankTransactions_bankTransactionStatus_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactions_account_id",
                table: "bankTransactions",
                newName: "IX_bankTransactions_account_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bankTransactions",
                table: "bankTransactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "bankTransactionInfo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankTransactionInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bankTransactionStatuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankTransactionStatuses", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "bankTransactionInfo",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1L, "Deposit" },
                    { 2L, "Withdrawal" },
                    { 3L, "Send" },
                    { 4L, "Receive" }
                });

            migrationBuilder.InsertData(
                table: "bankTransactionStatuses",
                columns: new[] { "id", "status" },
                values: new object[,]
                {
                    { 1L, "Pending" },
                    { 2L, "Completed" },
                    { 3L, "Failed" },
                    { 4L, "Canceled" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountType_id",
                table: "accounts",
                column: "accountType_id",
                principalTable: "accountInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bankTransactions_accounts_account_id",
                table: "bankTransactions",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bankTransactions_bankTransactionInfo_bankTransactionType_id",
                table: "bankTransactions",
                column: "bankTransactionType_id",
                principalTable: "bankTransactionInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bankTransactions_bankTransactionStatuses_bankTransactionStatus_id",
                table: "bankTransactions",
                column: "bankTransactionStatus_id",
                principalTable: "bankTransactionStatuses",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_bankTransactions_from_id",
                table: "transfers",
                column: "from_id",
                principalTable: "bankTransactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_bankTransactions_to_id",
                table: "transfers",
                column: "to_id",
                principalTable: "bankTransactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountType_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_bankTransactions_accounts_account_id",
                table: "bankTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_bankTransactions_bankTransactionInfo_bankTransactionType_id",
                table: "bankTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_bankTransactions_bankTransactionStatuses_bankTransactionStatus_id",
                table: "bankTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_from_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_to_id",
                table: "transfers");

            migrationBuilder.DropTable(
                name: "bankTransactionInfo");

            migrationBuilder.DropTable(
                name: "bankTransactionStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bankTransactions",
                table: "bankTransactions");

            migrationBuilder.RenameTable(
                name: "bankTransactions",
                newName: "transactions");

            migrationBuilder.RenameColumn(
                name: "accountType_id",
                table: "accounts",
                newName: "accountTypes_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_accountType_id",
                table: "accounts",
                newName: "IX_accounts_accountTypes_id");

            migrationBuilder.RenameColumn(
                name: "bankTransactionType_id",
                table: "transactions",
                newName: "transactionInfo_id__type");

            migrationBuilder.RenameColumn(
                name: "bankTransactionStatus_id",
                table: "transactions",
                newName: "transactionInfo_id__status");

            migrationBuilder.RenameIndex(
                name: "IX_bankTransactions_bankTransactionType_id",
                table: "transactions",
                newName: "IX_transactions_transactionInfo_id__type");

            migrationBuilder.RenameIndex(
                name: "IX_bankTransactions_bankTransactionStatus_id",
                table: "transactions",
                newName: "IX_transactions_transactionInfo_id__status");

            migrationBuilder.RenameIndex(
                name: "IX_bankTransactions_account_id",
                table: "transactions",
                newName: "IX_transactions_account_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "transactionInfo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactionStatuses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionStatuses", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "transactionInfo",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1L, "Deposit" },
                    { 2L, "Withdrawal" },
                    { 3L, "Send" },
                    { 4L, "Receive" }
                });

            migrationBuilder.InsertData(
                table: "transactionStatuses",
                columns: new[] { "id", "status" },
                values: new object[,]
                {
                    { 1L, "Pending" },
                    { 2L, "Completed" },
                    { 3L, "Failed" },
                    { 4L, "Canceled" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountTypes_id",
                table: "accounts",
                column: "accountTypes_id",
                principalTable: "accountInfo",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_account_id",
                table: "transactions",
                column: "account_id",
                principalTable: "accounts",
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

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_transactions_from_id",
                table: "transfers",
                column: "from_id",
                principalTable: "transactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_transactions_to_id",
                table: "transfers",
                column: "to_id",
                principalTable: "transactions",
                principalColumn: "Id");
        }
    }
}
