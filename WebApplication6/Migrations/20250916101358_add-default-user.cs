using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class adddefaultuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.InsertData(
                table: "bankRoles",
                columns: new[] { "id", "role", "roleName" },
                values: new object[] { 2L, -1, "Admin" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "BankRole_id", "createdAt", "email", "hashedPassword", "phone", "userName" },
                values: new object[] { 1L, 2L, new DateTime(2025, 9, 16, 13, 12, 39, 713, DateTimeKind.Local).AddTicks(6689), "admin@gmail.com", "$2a$11$g3QSh3R50Hq2d6uzp1GoAeBtQeCXDNWJlKDbqv0kYj7IZ1zEIBF3q", "", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.InsertData(
                table: "bankRoles",
                columns: new[] { "id", "role", "roleName" },
                values: new object[] { 3L, -1, "Admin" });
        }
    }
}
