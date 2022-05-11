using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHeroAPI.Migrations
{
    public partial class UpdateSuperHeroColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "SuperHeros");

            migrationBuilder.AddColumn<string>(
                name: "JurisdictionCity",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JurisdictionState",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalFirstName",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalLastName",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SuperHeroName",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JurisdictionCity",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "JurisdictionState",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "LegalFirstName",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "LegalLastName",
                table: "SuperHeros");

            migrationBuilder.DropColumn(
                name: "SuperHeroName",
                table: "SuperHeros");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "SuperHeros",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
