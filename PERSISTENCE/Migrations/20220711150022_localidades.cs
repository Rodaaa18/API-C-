using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSISTENCE.Migrations
{
    public partial class localidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idLocalidadHasta",
                table: "Trazas",
                newName: "IdLocalidadHasta");

            migrationBuilder.RenameColumn(
                name: "idLocalidadDesde",
                table: "Trazas",
                newName: "IdLocalidadDesde");

            migrationBuilder.RenameIndex(
                name: "IX_Trazas_idLocalidadHasta",
                table: "Trazas",
                newName: "IX_Trazas_IdLocalidadHasta");

            migrationBuilder.RenameIndex(
                name: "IX_Trazas_idLocalidadDesde",
                table: "Trazas",
                newName: "IX_Trazas_IdLocalidadDesde");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLocalidadHasta",
                table: "Trazas",
                newName: "idLocalidadHasta");

            migrationBuilder.RenameColumn(
                name: "IdLocalidadDesde",
                table: "Trazas",
                newName: "idLocalidadDesde");

            migrationBuilder.RenameIndex(
                name: "IX_Trazas_IdLocalidadHasta",
                table: "Trazas",
                newName: "IX_Trazas_idLocalidadHasta");

            migrationBuilder.RenameIndex(
                name: "IX_Trazas_IdLocalidadDesde",
                table: "Trazas",
                newName: "IX_Trazas_idLocalidadDesde");
        }
    }
}
