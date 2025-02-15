using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.Migrations
{
    /// <inheritdoc />
    public partial class RenameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "Urls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.RenameTable(
                name: "Urls",
                newName: "Entities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");
        }
    }
}
