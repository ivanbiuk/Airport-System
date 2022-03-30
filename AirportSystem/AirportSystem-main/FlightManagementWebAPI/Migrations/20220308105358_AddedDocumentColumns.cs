using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightManagementWebAPI.Migrations
{
    public partial class AddedDocumentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentExpirationDate",
                table: "Passengers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameInDocument",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SurnameInDocument",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentExpirationDate",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "NameInDocument",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "SurnameInDocument",
                table: "Passengers");
        }
    }
}
