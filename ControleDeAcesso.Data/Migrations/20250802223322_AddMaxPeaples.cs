using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMaxPeaples : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxPeaples",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPeaples",
                table: "Events");
        }
    }
}
