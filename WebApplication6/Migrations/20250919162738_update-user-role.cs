using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    /// <inheritdoc />
    public partial class updateuserrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 1L,
                column: "role",
                value: 32703);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "bankRoles",
                keyColumn: "id",
                keyValue: 1L,
                column: "role",
                value: 447);
        }
    }
}
