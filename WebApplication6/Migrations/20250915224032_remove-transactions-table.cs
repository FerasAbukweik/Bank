using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class removetransactionstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_fromBankTransaction_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_toBankTransaction_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_users_bankRoles_BankRole_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "bankTransactions");

            migrationBuilder.DropTable(
                name: "bankTransactionInfo");

            migrationBuilder.DropTable(
                name: "bankTransactionStatuses");

            migrationBuilder.DeleteData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "toBankTransaction_id",
                table: "transfers",
                newName: "toAccount_id");

            migrationBuilder.RenameColumn(
                name: "fromBankTransaction_id",
                table: "transfers",
                newName: "fromAccount_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_toBankTransaction_id",
                table: "transfers",
                newName: "IX_transfers_toAccount_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_fromBankTransaction_id",
                table: "transfers",
                newName: "IX_transfers_fromAccount_id");

            migrationBuilder.AlterColumn<long>(
                name: "BankRole_id",
                table: "users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "amount",
                table: "transfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "transactionStatus",
                table: "transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 1L,
                column: "role",
                value: 447);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_accounts_fromAccount_id",
                table: "transfers",
                column: "fromAccount_id",
                principalTable: "accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_accounts_toAccount_id",
                table: "transfers",
                column: "toAccount_id",
                principalTable: "accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_bankRoles_BankRole_id",
                table: "users",
                column: "BankRole_id",
                principalTable: "bankRoles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfers_accounts_fromAccount_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_accounts_toAccount_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_users_bankRoles_BankRole_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "transactionStatus",
                table: "transfers");

            migrationBuilder.RenameColumn(
                name: "toAccount_id",
                table: "transfers",
                newName: "toBankTransaction_id");

            migrationBuilder.RenameColumn(
                name: "fromAccount_id",
                table: "transfers",
                newName: "fromBankTransaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_toAccount_id",
                table: "transfers",
                newName: "IX_transfers_toBankTransaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_fromAccount_id",
                table: "transfers",
                newName: "IX_transfers_fromBankTransaction_id");

            migrationBuilder.AlterColumn<long>(
                name: "BankRole_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "bankTransactions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<long>(type: "bigint", nullable: true),
                    bankTransactionStatus_id = table.Column<long>(type: "bigint", nullable: true),
                    bankTransactionType_id = table.Column<long>(type: "bigint", nullable: true),
                    amount = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankTransactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_bankTransactions_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_bankTransactions_bankTransactionInfo_bankTransactionType_id",
                        column: x => x.bankTransactionType_id,
                        principalTable: "bankTransactionInfo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_bankTransactions_bankTransactionStatuses_bankTransactionStatus_id",
                        column: x => x.bankTransactionStatus_id,
                        principalTable: "bankTransactionStatuses",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 1L,
                column: "role",
                value: 1791);

            migrationBuilder.InsertData(
                table: "bankRoles",
                columns: new[] { "id", "role", "roleName" },
                values: new object[] { 2L, 1966, "Manager" });

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

            migrationBuilder.CreateIndex(
                name: "IX_bankTransactions_account_id",
                table: "bankTransactions",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_bankTransactions_bankTransactionStatus_id",
                table: "bankTransactions",
                column: "bankTransactionStatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_bankTransactions_bankTransactionType_id",
                table: "bankTransactions",
                column: "bankTransactionType_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_bankTransactions_fromBankTransaction_id",
                table: "transfers",
                column: "fromBankTransaction_id",
                principalTable: "bankTransactions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_bankTransactions_toBankTransaction_id",
                table: "transfers",
                column: "toBankTransaction_id",
                principalTable: "bankTransactions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_bankRoles_BankRole_id",
                table: "users",
                column: "BankRole_id",
                principalTable: "bankRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
