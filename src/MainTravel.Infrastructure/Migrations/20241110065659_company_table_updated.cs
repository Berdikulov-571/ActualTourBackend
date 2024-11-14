using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainTravel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class company_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HappyCustomers",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TourPackages",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "YearExperience",
                table: "Companies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HappyCustomers",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TourPackages",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearExperience",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
