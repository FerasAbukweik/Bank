using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class converted_from_minorMahor_to_database_for_each_info___Add_amount_to_transactionModel___Add_send_Receive_to_transactionTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountInfo_id__type",
                table: "accounts");

            migrationBuilder.DropIndex(
                name: "IX_accounts_accountInfo_id__type",
                table: "accounts");

            migrationBuilder.DeleteData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DropColumn(
                name: "majorCode",
                table: "transactionInfo");

            migrationBuilder.DropColumn(
                name: "minorCode",
                table: "transactionInfo");

            migrationBuilder.DropColumn(
                name: "accountInfo_id__type",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "majorCode",
                table: "accountInfo");

            migrationBuilder.DropColumn(
                name: "minorCode",
                table: "accountInfo");

            migrationBuilder.RenameColumn(
                name: "info",
                table: "transactionInfo",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "info",
                table: "accountInfo",
                newName: "type");

            migrationBuilder.AddColumn<long>(
                name: "amount",
                table: "transfers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "accountTypes_id",
                table: "accounts",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 1L,
                column: "type",
                value: "Deposit");

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 2L,
                column: "type",
                value: "Withdrawal");

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 3L,
                column: "type",
                value: "Send");

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 4L,
                column: "type",
                value: "Receive");

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

            migrationBuilder.CreateIndex(
                name: "IX_accounts_accountTypes_id",
                table: "accounts",
                column: "accountTypes_id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountTypes_id",
                table: "accounts",
                column: "accountTypes_id",
                principalTable: "accountInfo",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountTypes_id",
                table: "accounts");

            migrationBuilder.DropTable(
                name: "transactionStatuses");

            migrationBuilder.DropIndex(
                name: "IX_accounts_accountTypes_id",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "accountTypes_id",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "transactionInfo",
                newName: "info");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "accountInfo",
                newName: "info");

            migrationBuilder.AddColumn<int>(
                name: "majorCode",
                table: "transactionInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "minorCode",
                table: "transactionInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "accountInfo_id__type",
                table: "accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "majorCode",
                table: "accountInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "minorCode",
                table: "accountInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "majorCode", "minorCode" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "majorCode", "minorCode" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "majorCode", "minorCode" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "majorCode", "minorCode" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 5L,
                columns: new[] { "majorCode", "minorCode" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "info", "majorCode", "minorCode" },
                values: new object[] { "Pending", 1, 1 });

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "info", "majorCode", "minorCode" },
                values: new object[] { "Completed", 1, 2 });

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "info", "majorCode", "minorCode" },
                values: new object[] { "Failed", 1, 3 });

            migrationBuilder.UpdateData(
                table: "transactionInfo",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "info", "majorCode", "minorCode" },
                values: new object[] { "Canceled", 1, 4 });

            migrationBuilder.InsertData(
                table: "transactionInfo",
                columns: new[] { "id", "info", "majorCode", "minorCode" },
                values: new object[,]
                {
                    { 5L, "Deposit", 2, 1 },
                    { 6L, "Withdrawal", 2, 2 }
                });

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
        }
    }
}
