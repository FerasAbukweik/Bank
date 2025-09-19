using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountTypes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountTypes", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankRole_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_bankRoles_BankRole_id",
                        column: x => x.BankRole_id,
                        principalTable: "bankRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    balance = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    accountType_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_accounts_accountTypes_accountType_id",
                        column: x => x.accountType_id,
                        principalTable: "accountTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transfers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    fromAccount_id = table.Column<long>(type: "bigint", nullable: true),
                    toAccount_id = table.Column<long>(type: "bigint", nullable: true),
                    fromUserId = table.Column<long>(type: "bigint", nullable: true),
                    toUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfers", x => x.id);
                    table.ForeignKey(
                        name: "FK_transfers_accounts_fromAccount_id",
                        column: x => x.fromAccount_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transfers_accounts_toAccount_id",
                        column: x => x.toAccount_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transfers_users_fromUserId",
                        column: x => x.fromUserId,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transfers_users_toUserId",
                        column: x => x.toUserId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "accountTypes",
                columns: new[] { "id", "type" },
                values: new object[,]
                {
                    { 1L, "Savings" },
                    { 2L, "Current/Checking" },
                    { 3L, "Fixed/Deposit" },
                    { 4L, "Recurring/Deposit" },
                    { 5L, "NRI/Accounts" }
                });

            migrationBuilder.InsertData(
                table: "bankRoles",
                columns: new[] { "id", "role", "roleName" },
                values: new object[,]
                {
                    { 1L, 447, "Client" },
                    { 2L, -1, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "BankRole_id", "createdAt", "email", "hashedPassword", "phone", "userName" },
                values: new object[] { 1L, 2L, new DateTime(2025, 9, 16, 13, 12, 39, 713, DateTimeKind.Local).AddTicks(6689), "admin@gmail.com", "$2a$11$g3QSh3R50Hq2d6uzp1GoAeBtQeCXDNWJlKDbqv0kYj7IZ1zEIBF3q", "", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_accountType_id",
                table: "accounts",
                column: "accountType_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_fromAccount_id",
                table: "transfers",
                column: "fromAccount_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_fromUserId",
                table: "transfers",
                column: "fromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_toAccount_id",
                table: "transfers",
                column: "toAccount_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfers_toUserId",
                table: "transfers",
                column: "toUserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_BankRole_id",
                table: "users",
                column: "BankRole_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfers");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "accountTypes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "bankRoles");
        }
    }
}
