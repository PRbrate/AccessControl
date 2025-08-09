using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEventAvaliable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Events",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Events");
        }
    }
}
