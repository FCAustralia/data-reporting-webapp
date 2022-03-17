using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Form.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Organisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsentOne = table.Column<bool>(type: "bit", nullable: false),
                    CsOneQuestionOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsOneQuestionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsOneQuestionThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsOneQuestionFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsOneQuestionFive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsOneQuestionSix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsentTwo = table.Column<bool>(type: "bit", nullable: false),
                    CsTwoQuestionOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsTwoQuestionTwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsTwoQuestionThree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsTwoQuestionFour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsTwoQuestionFive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CsTwoQuestionSix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers");
        }
    }
}
