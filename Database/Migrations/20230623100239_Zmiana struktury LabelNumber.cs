using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ZmianastrukturyLabelNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumber",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registry",
                table: "Registry");

            migrationBuilder.DropIndex(
                name: "IX_Items_LabelTypeId_LabelNumber",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Nazwa",
                table: "Roles",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "LabelNumberPrefix",
                table: "Registry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LabelNumberSufix",
                table: "Registry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LabelNumberPrefix",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LabelNumberSufix",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registry",
                table: "Registry",
                columns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_LabelTypeId_LabelNumberPrefix_LabelNumber_LabelNumber~",
                table: "Items",
                columns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumberPrefix_LabelNumber_La~",
                table: "Items",
                columns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" },
                principalTable: "Registry",
                principalColumns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumberPrefix_LabelNumber_La~",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registry",
                table: "Registry");

            migrationBuilder.DropIndex(
                name: "IX_Items_LabelTypeId_LabelNumberPrefix_LabelNumber_LabelNumber~",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LabelNumberPrefix",
                table: "Registry");

            migrationBuilder.DropColumn(
                name: "LabelNumberSufix",
                table: "Registry");

            migrationBuilder.DropColumn(
                name: "LabelNumberPrefix",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LabelNumberSufix",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Roles",
                newName: "Nazwa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registry",
                table: "Registry",
                columns: new[] { "LabelTypeId", "LabelNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_LabelTypeId_LabelNumber",
                table: "Items",
                columns: new[] { "LabelTypeId", "LabelNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumber",
                table: "Items",
                columns: new[] { "LabelTypeId", "LabelNumber" },
                principalTable: "Registry",
                principalColumns: new[] { "LabelTypeId", "LabelNumber" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
