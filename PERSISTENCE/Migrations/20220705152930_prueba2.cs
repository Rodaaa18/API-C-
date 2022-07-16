using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSISTENCE.Migrations
{
    public partial class prueba2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idGrupo",
                table: "Modelos",
                newName: "IdGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_idGrupo",
                table: "Modelos",
                newName: "IX_Modelos_IdGrupo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGrupo",
                table: "Modelos",
                newName: "idGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_IdGrupo",
                table: "Modelos",
                newName: "IX_Modelos_idGrupo");
        }
    }
}
