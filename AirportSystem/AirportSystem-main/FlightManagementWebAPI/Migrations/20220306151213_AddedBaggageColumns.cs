using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagementWebAPI.Migrations
{
    public partial class AddedBaggageColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaggageItems",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "BaggageWeight",
                table: "Passengers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaggageItems",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "BaggageWeight",
                table: "Passengers");
        }
    }
}
