using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class fixesforthenaming___removeamountfromtransfermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_from_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_to_id",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "bankTransactions");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "hashed_password",
                table: "users",
                newName: "hashedPassword");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "to_id",
                table: "transfers",
                newName: "toBankTransaction_id");

            migrationBuilder.RenameColumn(
                name: "from_id",
                table: "transfers",
                newName: "fromBankTransaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_to_id",
                table: "transfers",
                newName: "IX_transfers_toBankTransaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_from_id",
                table: "transfers",
                newName: "IX_transfers_fromBankTransaction_id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "accounts",
                newName: "createdAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "bankTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_fromBankTransaction_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_bankTransactions_toBankTransaction_id",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "bankTransactions");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "hashedPassword",
                table: "users",
                newName: "hashed_password");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "toBankTransaction_id",
                table: "transfers",
                newName: "to_id");

            migrationBuilder.RenameColumn(
                name: "fromBankTransaction_id",
                table: "transfers",
                newName: "from_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_toBankTransaction_id",
                table: "transfers",
                newName: "IX_transfers_to_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_fromBankTransaction_id",
                table: "transfers",
                newName: "IX_transfers_from_id");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "accounts",
                newName: "created_at");

            migrationBuilder.AddColumn<long>(
                name: "amount",
                table: "transfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "bankTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_bankTransactions_from_id",
                table: "transfers",
                column: "from_id",
                principalTable: "bankTransactions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_bankTransactions_to_id",
                table: "transfers",
                column: "to_id",
                principalTable: "bankTransactions",
                principalColumn: "id");
        }
    }
}
