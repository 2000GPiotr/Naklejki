using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Password_PasswordId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Password",
                table: "Password");

            migrationBuilder.RenameTable(
                name: "Password",
                newName: "Passwords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passwords",
                table: "Passwords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users",
                column: "PasswordId",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passwords",
                table: "Passwords");

            migrationBuilder.RenameTable(
                name: "Passwords",
                newName: "Password");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Password",
                table: "Password",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Password_PasswordId",
                table: "Users",
                column: "PasswordId",
                principalTable: "Password",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
