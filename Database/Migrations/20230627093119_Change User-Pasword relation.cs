using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserPaswordrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PasswordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Passwords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_UserId",
                table: "Passwords",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Users_UserId",
                table: "Passwords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Users_UserId",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Passwords_UserId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Passwords");

            migrationBuilder.AddColumn<int>(
                name: "PasswordId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PasswordId",
                table: "Users",
                column: "PasswordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users",
                column: "PasswordId",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
