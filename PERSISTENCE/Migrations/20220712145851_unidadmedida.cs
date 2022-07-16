using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSISTENCE.Migrations
{
    public partial class unidadmedida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesDeMedidas");

            migrationBuilder.CreateTable(
                name: "UnidadesDeMedida",
                columns: table => new
                {
                    IdUnidadDeMedida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadDeMedida = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.IdUnidadDeMedida);
                });

            migrationBuilder.CreateIndex(
                name: "det_unidaddemedidaunica",
                table: "UnidadesDeMedida",
                column: "UnidadDeMedida",
                unique: true,
                filter: "[UnidadDeMedida] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida",
                table: "UnidadesDeMedida",
                columns: new[] { "IdUnidadDeMedida", "UnidadDeMedida" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnidadesDeMedida");

            migrationBuilder.CreateTable(
                name: "UnidadesDeMedidas",
                columns: table => new
                {
                    IdUnidadDeMedida = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadDeMedida = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.IdUnidadDeMedida);
                });

            migrationBuilder.CreateIndex(
                name: "det_unidaddemedidaunica",
                table: "UnidadesDeMedidas",
                column: "UnidadDeMedida",
                unique: true,
                filter: "[UnidadDeMedida] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesDeMedida_IdUnidadDeMedidaUnidadDeMedida",
                table: "UnidadesDeMedidas",
                columns: new[] { "IdUnidadDeMedida", "UnidadDeMedida" });
        }
    }
}
