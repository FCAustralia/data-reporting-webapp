using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Form.Migrations
{
    public partial class changeprimarykeydatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                ALTER TABLE dbo.dossiers
                    DROP CONSTRAINT PK_Dossiers
                GO

                ALTER TABLE [dbo].dossiers
                    DROP COLUMN id
                GO

                ALTER TABLE [dbo].dossiers
                    ADD Id UNIQUEIDENTIFIER NULL 
                GO

                UPDATE dbo.Dossiers SET id = NEWID();

                ALTER TABLE dbo.dossiers
                    ALTER COLUMN id UNIQUEIDENTIFIER not null;
                GO

                ALTER TABLE dbo.Dossiers
                    ADD CONSTRAINT PK_Dossiers
                PRIMARY KEY (Id)");
            /*migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Dossiers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE dbo.dossiers
                    DROP CONSTRAINT PK_Dossiers
                GO

                ALTER TABLE [dbo].dossiers
                    DROP COLUMN id
                GO

                ALTER TABLE [dbo].dossiers
                    ADD Id INT NULL 
                GO

                /**UPDATE dbo.Dossiers SET id = NEWID();**/

               DECLARE @startId INT = 0;
 
                UPDATE Dossiers SET Id = down.id
                FROM Dossiers 
                JOIN (
                    SELECT (ROW_NUMBER() OVER(ORDER BY Organisation)) + @startId 
                    AS id, Organisation FROM DBO.Dossiers) 
                AS down 
                ON dossiers.Organisation = down.Organisation;

                ALTER TABLE dbo.dossiers
                    ALTER COLUMN id int not null;
                GO

                ALTER TABLE dbo.Dossiers
                    ADD CONSTRAINT PK_Dossiers
                PRIMARY KEY (Id)");
            /*migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Dossiers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");*/
        }
    }
}
