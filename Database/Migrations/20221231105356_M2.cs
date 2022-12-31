using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Items_LabelTypeId",
                table: "Items");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Registry_LabelTypeId_LabelNumber",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_LabelTypeId_LabelNumber",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LabelTypeId",
                table: "Items",
                column: "LabelTypeId");
        }
    }
}
