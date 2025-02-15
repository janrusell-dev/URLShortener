using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shortCode",
                table: "Urls",
                newName: "shortenUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "shortenUrl",
                table: "Urls",
                newName: "shortCode");
        }
    }
}
