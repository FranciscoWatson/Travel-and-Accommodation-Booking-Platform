using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TABP.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddThumbnailImageToCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "Cities",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "Cities");
        }
    }
}
