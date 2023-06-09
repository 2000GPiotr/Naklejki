using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class PasswordByteaType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Passwords");

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Passwords",
                type: "bytea",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Hash",
                table: "Passwords",
                type: "bytea",
                nullable: false);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
