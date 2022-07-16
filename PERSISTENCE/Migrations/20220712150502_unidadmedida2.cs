using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSISTENCE.Migrations
{
    public partial class unidadmedida2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesDeMedida");

            migrationBuilder.DropIndex(
                name: "IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida",
                table: "UnidadesDeMedida");

            migrationBuilder.DropColumn(
                name: "IdUnidadDeMedida",
                table: "UnidadesDeMedida");

            migrationBuilder.AddColumn<int>(
                name: "IdUnidadMedida",
                table: "UnidadesDeMedida",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesDeMedida",
                column: "IdUnidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida",
                table: "UnidadesDeMedida",
                columns: new[] { "IdUnidadMedida", "UnidadDeMedida" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesDeMedida");

            migrationBuilder.DropIndex(
                name: "IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida",
                table: "UnidadesDeMedida");

            migrationBuilder.DropColumn(
                name: "IdUnidadMedida",
                table: "UnidadesDeMedida");

            migrationBuilder.AddColumn<int>(
                name: "IdUnidadDeMedida",
                table: "UnidadesDeMedida",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadesMedida",
                table: "UnidadesDeMedida",
                column: "IdUnidadDeMedida");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida",
                table: "UnidadesDeMedida",
                columns: new[] { "IdUnidadDeMedida", "UnidadDeMedida" });
        }
    }
}
