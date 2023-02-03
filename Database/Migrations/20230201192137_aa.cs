using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LabelStatus",
                table: "Registry");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "DocumentHeaders");

            migrationBuilder.AddColumn<string>(
                name: "LabelStatusId",
                table: "Registry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentTypeId",
                table: "DocumentHeaders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "LabelStatus",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelStatus", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Key = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nazwa = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "RolesUser",
                columns: table => new
                {
                    RolesKey = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUser", x => new { x.RolesKey, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RolesUser_Roles_RolesKey",
                        column: x => x.RolesKey,
                        principalTable: "Roles",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registry_LabelStatusId",
                table: "Registry",
                column: "LabelStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentHeaders_DocumentTypeId",
                table: "DocumentHeaders",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUser_UsersId",
                table: "RolesUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentHeaders_DocumentTypes_DocumentTypeId",
                table: "DocumentHeaders",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registry_LabelStatus_LabelStatusId",
                table: "Registry",
                column: "LabelStatusId",
                principalTable: "LabelStatus",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentHeaders_DocumentTypes_DocumentTypeId",
                table: "DocumentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Registry_LabelStatus_LabelStatusId",
                table: "Registry");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "LabelStatus");

            migrationBuilder.DropTable(
                name: "RolesUser");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Registry_LabelStatusId",
                table: "Registry");

            migrationBuilder.DropIndex(
                name: "IX_DocumentHeaders_DocumentTypeId",
                table: "DocumentHeaders");

            migrationBuilder.DropColumn(
                name: "LabelStatusId",
                table: "Registry");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "DocumentHeaders");

            migrationBuilder.AddColumn<int[]>(
                name: "Roles",
                table: "Users",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<int>(
                name: "LabelStatus",
                table: "Registry",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "DocumentHeaders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
