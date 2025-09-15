using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class randomstuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BankRole_id",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "bankRoles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<int>(type: "int", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankRoles", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 2L,
                column: "type",
                value: "Current/Checking");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 3L,
                column: "type",
                value: "Fixed/Deposit");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 4L,
                column: "type",
                value: "Recurring/Deposit");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 5L,
                column: "type",
                value: "NRI/Accounts");

            migrationBuilder.InsertData(
                table: "bankRoles",
                columns: new[] { "id", "role", "roleName" },
                values: new object[,]
                {
                    { 1L, 1791, "Client" },
                    { 2L, 1966, "Manager" },
                    { 3L, -1, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_BankRole_id",
                table: "users",
                column: "BankRole_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_bankRoles_BankRole_id",
                table: "users",
                column: "BankRole_id",
                principalTable: "bankRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_bankRoles_BankRole_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "bankRoles");

            migrationBuilder.DropIndex(
                name: "IX_users_BankRole_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "BankRole_id",
                table: "users");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 2L,
                column: "type",
                value: "Current_Checking");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 3L,
                column: "type",
                value: "Fixed_Deposit");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 4L,
                column: "type",
                value: "Recurring_Deposit");

            migrationBuilder.UpdateData(
                table: "accountInfo",
                keyColumn: "id",
                keyValue: 5L,
                column: "type",
                value: "NRI_Accounts");
        }
    }
}
