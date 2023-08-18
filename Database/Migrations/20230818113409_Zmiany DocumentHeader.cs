using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ZmianyDocumentHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentHeaders_Users_UserId",
                table: "DocumentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_LabelTypes_LabelTypeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumberPrefix_LabelNumber_La~",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "LabelTypeId",
                table: "Items",
                newName: "LabelTypeSymbol");

            migrationBuilder.RenameIndex(
                name: "IX_Items_LabelTypeId_LabelNumberPrefix_LabelNumber_LabelNumber~",
                table: "Items",
                newName: "IX_Items_LabelTypeSymbol_LabelNumberPrefix_LabelNumber_LabelNu~");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DocumentHeaders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentHeaders_Users_UserId",
                table: "DocumentHeaders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LabelTypes_LabelTypeSymbol",
                table: "Items",
                column: "LabelTypeSymbol",
                principalTable: "LabelTypes",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Registry_LabelTypeSymbol_LabelNumberPrefix_LabelNumbe~",
                table: "Items",
                columns: new[] { "LabelTypeSymbol", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" },
                principalTable: "Registry",
                principalColumns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentHeaders_Users_UserId",
                table: "DocumentHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_LabelTypes_LabelTypeSymbol",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Registry_LabelTypeSymbol_LabelNumberPrefix_LabelNumbe~",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "LabelTypeSymbol",
                table: "Items",
                newName: "LabelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_LabelTypeSymbol_LabelNumberPrefix_LabelNumber_LabelNu~",
                table: "Items",
                newName: "IX_Items_LabelTypeId_LabelNumberPrefix_LabelNumber_LabelNumber~");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DocumentHeaders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentHeaders_Users_UserId",
                table: "DocumentHeaders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_LabelTypes_LabelTypeId",
                table: "Items",
                column: "LabelTypeId",
                principalTable: "LabelTypes",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumberPrefix_LabelNumber_La~",
                table: "Items",
                columns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" },
                principalTable: "Registry",
                principalColumns: new[] { "LabelTypeId", "LabelNumberPrefix", "LabelNumber", "LabelNumberSufix" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
