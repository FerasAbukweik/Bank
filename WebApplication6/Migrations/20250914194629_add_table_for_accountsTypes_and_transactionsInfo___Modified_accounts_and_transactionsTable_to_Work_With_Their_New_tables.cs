using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class add_table_for_accountsTypes_and_transactionsInfo___Modified_accounts_and_transactionsTable_to_Work_With_Their_New_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_amount",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_amount",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "status",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "type",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "account_type",
                table: "accounts");

            migrationBuilder.AddColumn<long>(
                name: "transactionInfo_id__status",
                table: "transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "transactionInfo_id__type",
                table: "transactions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "balance",
                table: "accounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "accountInfo_id__type",
                table: "accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "accountInfo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    majorCode = table.Column<int>(type: "int", nullable: false),
                    minorCode = table.Column<int>(type: "int", nullable: false),
                    info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountInfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactionInfo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    majorCode = table.Column<int>(type: "int", nullable: false),
                    minorCode = table.Column<int>(type: "int", nullable: false),
                    info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionInfo", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "accountInfo",
                columns: new[] { "id", "info", "majorCode", "minorCode" },
                values: new object[,]
                {
                    { 1L, "Savings", 1, 1 },
                    { 2L, "Current_Checking", 1, 2 },
                    { 3L, "Fixed_Deposit", 1, 3 },
                    { 4L, "Recurring_Deposit", 1, 4 },
                    { 5L, "NRI_Accounts", 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "transactionInfo",
                columns: new[] { "id", "info", "majorCode", "minorCode" },
                values: new object[,]
                {
                    { 1L, "Pending", 1, 1 },
                    { 2L, "Completed", 1, 2 },
                    { 3L, "Failed", 1, 3 },
                    { 4L, "Canceled", 1, 4 },
                    { 5L, "Deposit", 2, 1 },
                    { 6L, "Withdrawal", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_account_id",
                table: "transactions",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_transactionInfo_id__status",
                table: "transactions",
                column: "transactionInfo_id__status");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_transactionInfo_id__type",
                table: "transactions",
                column: "transactionInfo_id__type");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_accountInfo_id__type",
                table: "accounts",
                column: "accountInfo_id__type");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountInfo_id__type",
                table: "accounts",
                column: "accountInfo_id__type",
                principalTable: "accountInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountInfo_id__type",
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

            migrationBuilder.DropTable(
                name: "accountInfo");

            migrationBuilder.DropTable(
                name: "transactionInfo");

            migrationBuilder.DropIndex(
                name: "IX_transactions_account_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_transactionInfo_id__status",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_transactionInfo_id__type",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_accounts_accountInfo_id__type",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "transactionInfo_id__status",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "transactionInfo_id__type",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "accountInfo_id__type",
                table: "accounts");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "balance",
                table: "accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "account_type",
                table: "accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_amount",
                table: "transactions",
                column: "amount");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_amount",
                table: "transactions",
                column: "amount",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
