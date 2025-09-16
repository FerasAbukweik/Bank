using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class minormodifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountInfo_accountType_id",
                table: "accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountInfo",
                table: "accountInfo");

            migrationBuilder.RenameTable(
                name: "accountInfo",
                newName: "accountTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountTypes",
                table: "accountTypes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountTypes_accountType_id",
                table: "accounts",
                column: "accountType_id",
                principalTable: "accountTypes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_accountTypes_accountType_id",
                table: "accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accountTypes",
                table: "accountTypes");

            migrationBuilder.RenameTable(
                name: "accountTypes",
                newName: "accountInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accountInfo",
                table: "accountInfo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_accountInfo_accountType_id",
                table: "accounts",
                column: "accountType_id",
                principalTable: "accountInfo",
                principalColumn: "id");
        }
    }
}
