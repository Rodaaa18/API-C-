using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PERSISTENCE.Migrations
{
    public partial class prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgrupacionesSindicales",
                columns: table => new
                {
                    IdAgrupacionSindical = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Obs = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgrupacionesSindicales", x => x.IdAgrupacionSindical);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    IdConvenio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.IdConvenio);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "EstadosUnidades",
                columns: table => new
                {
                    idEstadoUnidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Obs = table.Column<int>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosUnidades", x => x.idEstadoUnidad);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    IdFuncion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.IdFuncion);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Obs = table.Column<string>(unicode: false, nullable: true),
                    RutaImagen = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.IdGrupo);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    idMarca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.idMarca);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    idProvincia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provincia = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.idProvincia);
                });

            migrationBuilder.CreateTable(
                name: "SituacionesUnidades",
                columns: table => new
                {
                    idSituacionUnidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionesUnidades", x => x.idSituacionUnidad);
                });

            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    IdTitulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.IdTitulo);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesDeMedidas",
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

            migrationBuilder.CreateTable(
                name: "VariablesUnidades",
                columns: table => new
                {
                    IdVariableUnidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariablesUnidades", x => x.IdVariableUnidad);
                });

            migrationBuilder.CreateTable(
                name: "CentrodeCostos",
                columns: table => new
                {
                    idCentrodeCosto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentrodeCosto = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true),
                    Tipo = table.Column<int>(nullable: false),
                    idEstadoUnidad = table.Column<int>(nullable: false),
                    codigobas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCosto", x => x.idCentrodeCosto);
                    table.ForeignKey(
                        name: "FK_CentrodeCosto_EstadosUnidades",
                        column: x => x.idEstadoUnidad,
                        principalTable: "EstadosUnidades",
                        principalColumn: "idEstadoUnidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    idModelo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Obs = table.Column<string>(unicode: false, nullable: true),
                    idMarca = table.Column<int>(nullable: false),
                    idGrupo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.idModelo);
                    table.ForeignKey(
                        name: "FK_Modelos_Grupos",
                        column: x => x.idGrupo,
                        principalTable: "Grupos",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas",
                        column: x => x.idMarca,
                        principalTable: "Marcas",
                        principalColumn: "idMarca",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    idLocalidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localidad = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    CodigoPostal = table.Column<string>(unicode: false, nullable: true),
                    idProvincia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.idLocalidad);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias",
                        column: x => x.idProvincia,
                        principalTable: "Provincias",
                        principalColumn: "idProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choferes",
                columns: table => new
                {
                    idChofer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApellidoyNombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Legajo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    CarnetVence = table.Column<DateTime>(type: "datetime", nullable: false),
                    Obs = table.Column<string>(unicode: false, nullable: true),
                    Foto = table.Column<string>(unicode: false, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    NroDocumento = table.Column<string>(unicode: false, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Empresa = table.Column<string>(unicode: false, nullable: true),
                    idEmpresa = table.Column<int>(nullable: false),
                    AgrupacionSindical = table.Column<string>(unicode: false, nullable: true),
                    idAgrupacionSindical = table.Column<int>(nullable: false),
                    Convenio = table.Column<string>(unicode: false, nullable: true),
                    idConvenio = table.Column<int>(nullable: false),
                    Funcion = table.Column<string>(unicode: false, nullable: true),
                    idFuncion = table.Column<int>(nullable: false),
                    Especialidad = table.Column<string>(maxLength: 50, nullable: true),
                    idEspecialidad = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 50, nullable: true),
                    idTitulo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choferes", x => x.idChofer);
                    table.ForeignKey(
                        name: "FK_Choferes_AgrupacionesSindicales",
                        column: x => x.idAgrupacionSindical,
                        principalTable: "AgrupacionesSindicales",
                        principalColumn: "IdAgrupacionSindical",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choferes_Convenios",
                        column: x => x.idConvenio,
                        principalTable: "Convenios",
                        principalColumn: "IdConvenio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choferes_Empresas",
                        column: x => x.idEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choferes_Especialidades",
                        column: x => x.idEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choferes_Funciones",
                        column: x => x.idFuncion,
                        principalTable: "Funciones",
                        principalColumn: "IdFuncion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Choferes_Titulos",
                        column: x => x.idTitulo,
                        principalTable: "Titulos",
                        principalColumn: "IdTitulo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    idUnidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroUnidad = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Dominio = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    IntExt = table.Column<bool>(nullable: true),
                    KmAceptadosDesfazados = table.Column<double>(nullable: false),
                    HsAceptadasDesfazadas = table.Column<double>(nullable: false),
                    Motor = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Chasis = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AñoModelo = table.Column<long>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Foto = table.Column<string>(unicode: false, nullable: true),
                    PromedioConsumo = table.Column<double>(nullable: false),
                    UnidadMedida = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IdTipoCombustible = table.Column<int>(nullable: false),
                    UnidadMedTrabajo = table.Column<int>(nullable: false, comment: "1) Km - 2) Hs"),
                    Capacidad = table.Column<double>(nullable: false),
                    IdUnidadDeMedida = table.Column<long>(nullable: false),
                    Obs = table.Column<string>(unicode: false, nullable: true),
                    Tacografo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Radicacion = table.Column<string>(unicode: false, nullable: true),
                    Titular = table.Column<string>(unicode: false, nullable: true),
                    AcreedorPrendario = table.Column<string>(unicode: false, nullable: true),
                    MarcaTacografo = table.Column<string>(unicode: false, nullable: true),
                    CodigoRadio = table.Column<string>(unicode: false, nullable: true),
                    CodigoLlave = table.Column<string>(unicode: false, nullable: true),
                    IdModeloChasis = table.Column<int>(nullable: false),
                    IdTraza = table.Column<int>(nullable: false),
                    IdEsquema = table.Column<int>(nullable: false),
                    TieneConceptosSinRealizar = table.Column<bool>(nullable: false),
                    IdTipoLlanta = table.Column<int>(nullable: false),
                    Potencia = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    HsKmsDiaTrabajo = table.Column<double>(nullable: false),
                    LtsDiaTrabajo = table.Column<double>(nullable: false),
                    LitrosxTraza = table.Column<int>(nullable: false),
                    idNombreEquipamiento = table.Column<int>(nullable: false),
                    HabilitaOtraUnidadMedida = table.Column<bool>(nullable: false),
                    idModelo = table.Column<int>(nullable: false),
                    idEstadoUnidad = table.Column<int>(nullable: false),
                    idSituacionUnidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.idUnidad);
                    table.ForeignKey(
                        name: "FK_Unidades_EstadosUnidads",
                        column: x => x.idEstadoUnidad,
                        principalTable: "EstadosUnidades",
                        principalColumn: "idEstadoUnidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidades_Modelos",
                        column: x => x.idModelo,
                        principalTable: "Modelos",
                        principalColumn: "idModelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unidades_SituacionesUnidades",
                        column: x => x.idSituacionUnidad,
                        principalTable: "SituacionesUnidades",
                        principalColumn: "idSituacionUnidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trazas",
                columns: table => new
                {
                    IdTraza = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Obs = table.Column<string>(unicode: false, nullable: true),
                    DistanciaKM = table.Column<int>(nullable: false),
                    Litros = table.Column<int>(nullable: false),
                    idLocalidadDesde = table.Column<int>(nullable: false),
                    idLocalidadHasta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trazas", x => x.IdTraza);
                    table.ForeignKey(
                        name: "FK_TrazaDesde_Localidades",
                        column: x => x.idLocalidadDesde,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrazaHasta_Localidades",
                        column: x => x.idLocalidadHasta,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "det_descripcionAgrupacionSindicalUnica",
                table: "AgrupacionesSindicales",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_centrodecostounico",
                table: "CentrodeCostos",
                column: "CentrodeCosto",
                unique: true,
                filter: "[CentrodeCosto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CentrodeCostos_idEstadoUnidad",
                table: "CentrodeCostos",
                column: "idEstadoUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_idAgrupacionSindical",
                table: "Choferes",
                column: "idAgrupacionSindical");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_idConvenio",
                table: "Choferes",
                column: "idConvenio");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_idEmpresa",
                table: "Choferes",
                column: "idEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_idEspecialidad",
                table: "Choferes",
                column: "idEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_idFuncion",
                table: "Choferes",
                column: "idFuncion");

            migrationBuilder.CreateIndex(
                name: "IX_Choferes_idTitulo",
                table: "Choferes",
                column: "idTitulo");

            migrationBuilder.CreateIndex(
                name: "det_descripcionConvenioUnico",
                table: "Convenios",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_descripcionEmpresaUnica",
                table: "Empresas",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_descripcionEspecialidadUnica",
                table: "Especialidades",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_estadounico",
                table: "EstadosUnidades",
                column: "Estado",
                unique: true,
                filter: "[Estado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_descripcionFuncionUnica",
                table: "Funciones",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_descripciongrupounico",
                table: "Grupos",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "det_localidadaunica",
                table: "Localidades",
                column: "Localidad",
                unique: true,
                filter: "[Localidad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_idProvincia",
                table: "Localidades",
                column: "idProvincia");

            migrationBuilder.CreateIndex(
                name: "det_marcaunica",
                table: "Marcas",
                column: "Marca",
                unique: true,
                filter: "[Marca] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_idGrupo",
                table: "Modelos",
                column: "idGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_idMarca",
                table: "Modelos",
                column: "idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_IdModeloIdMarca",
                table: "Modelos",
                columns: new[] { "idModelo", "idMarca" });

            migrationBuilder.CreateIndex(
                name: "det_modelounico",
                table: "Modelos",
                columns: new[] { "Modelo", "idMarca" },
                unique: true,
                filter: "[Modelo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_provinciaunica",
                table: "Provincias",
                column: "Provincia",
                unique: true,
                filter: "[Provincia] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "det_descripcionTituloUnico",
                table: "Titulos",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trazas_idLocalidadDesde",
                table: "Trazas",
                column: "idLocalidadDesde");

            migrationBuilder.CreateIndex(
                name: "IX_Trazas_idLocalidadHasta",
                table: "Trazas",
                column: "idLocalidadHasta");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_idEstadoUnidad",
                table: "Unidades",
                column: "idEstadoUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_idModelo",
                table: "Unidades",
                column: "idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_Unidades_idSituacionUnidad",
                table: "Unidades",
                column: "idSituacionUnidad");

            migrationBuilder.CreateIndex(
                name: "Unidades_IdUnidadNroUnidad",
                table: "Unidades",
                columns: new[] { "idUnidad", "NroUnidad" });

            migrationBuilder.CreateIndex(
                name: "Unidades_IdUnidadUnidadMedTrabajo",
                table: "Unidades",
                columns: new[] { "idUnidad", "UnidadMedTrabajo" });

            migrationBuilder.CreateIndex(
                name: "Unidades_IdUnidadNroUnidadUnidadMedTrabajo",
                table: "Unidades",
                columns: new[] { "idUnidad", "NroUnidad", "UnidadMedTrabajo" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentrodeCostos");

            migrationBuilder.DropTable(
                name: "Choferes");

            migrationBuilder.DropTable(
                name: "Trazas");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "UnidadesDeMedidas");

            migrationBuilder.DropTable(
                name: "VariablesUnidades");

            migrationBuilder.DropTable(
                name: "AgrupacionesSindicales");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Titulos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "EstadosUnidades");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "SituacionesUnidades");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
