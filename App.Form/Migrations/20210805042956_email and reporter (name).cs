using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Form.Migrations
{
    public partial class emailandreportername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reporter",
                table: "Dossiers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Reporter",
                table: "Dossiers");
        }
    }
}
