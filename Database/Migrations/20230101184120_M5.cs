using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class M5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passwords_PasswordId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Users_PasswordId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordId",
                table: "Users",
                newName: "Round");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Round",
                table: "Users",
                newName: "PasswordId");

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    Round = table.Column<int>(type: "integer", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.Id);
                });

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
