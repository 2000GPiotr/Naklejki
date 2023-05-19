using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesUser_Roles_RolesKey",
                table: "RolesUser");

            migrationBuilder.RenameColumn(
                name: "RolesKey",
                table: "RolesUser",
                newName: "RolesId");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Roles",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolesUser_Roles_RolesId",
                table: "RolesUser",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolesUser_Roles_RolesId",
                table: "RolesUser");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "RolesUser",
                newName: "RolesKey");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "Key");

            migrationBuilder.AddForeignKey(
                name: "FK_RolesUser_Roles_RolesKey",
                table: "RolesUser",
                column: "RolesKey",
                principalTable: "Roles",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
