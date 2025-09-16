using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class addfromUserIdtoUserIdtotransfertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "fromUserId",
                table: "transfers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "toUserId",
                table: "transfers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transfers_fromUserId",
                table: "transfers",
                column: "fromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_toUserId",
                table: "transfers",
                column: "toUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_users_fromUserId",
                table: "transfers",
                column: "fromUserId",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_users_toUserId",
                table: "transfers",
                column: "toUserId",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfers_users_fromUserId",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_users_toUserId",
                table: "transfers");

            migrationBuilder.DropIndex(
                name: "IX_transfers_fromUserId",
                table: "transfers");

            migrationBuilder.DropIndex(
                name: "IX_transfers_toUserId",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "fromUserId",
                table: "transfers");

            migrationBuilder.DropColumn(
                name: "toUserId",
                table: "transfers");
        }
    }
}
