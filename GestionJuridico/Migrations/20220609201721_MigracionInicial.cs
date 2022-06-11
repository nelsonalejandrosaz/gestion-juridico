using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionJuridico.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargosPersonaRepresentante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosPersonaRepresentante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dui = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    AccionInicialId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposActo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposActo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEmisor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEmisor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEntidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEntidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesInstitucion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesInstitucion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiasPlazo = table.Column<int>(type: "int", nullable: true),
                    ProcesoId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TipoEntidadId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrados_TiposDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TiposDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administrados_TiposEntidad_TipoEntidadId",
                        column: x => x.TipoEntidadId,
                        principalTable: "TiposEntidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Acciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    EstadoActualId = table.Column<int>(type: "int", nullable: false),
                    EstadoSiguienteId = table.Column<int>(type: "int", nullable: false),
                    TipoAccionId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acciones_Estados_EstadoActualId",
                        column: x => x.EstadoActualId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acciones_Estados_EstadoSiguienteId",
                        column: x => x.EstadoSiguienteId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acciones_TiposAccion_TipoAccionId",
                        column: x => x.TipoAccionId,
                        principalTable: "TiposAccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdministradoPersona",
                columns: table => new
                {
                    AdministradoId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    CargoPersonaRepresentanteId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradoPersona", x => new { x.AdministradoId, x.PersonaId });
                    table.ForeignKey(
                        name: "FK_AdministradoPersona_Administrados_AdministradoId",
                        column: x => x.AdministradoId,
                        principalTable: "Administrados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdministradoPersona_CargosPersonaRepresentante_CargoPersonaRepresentanteId",
                        column: x => x.CargoPersonaRepresentanteId,
                        principalTable: "CargosPersonaRepresentante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdministradoPersona_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadSolicitanteId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoAsignadoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoAsignadoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casos_Administrados_EntidadSolicitanteId",
                        column: x => x.EntidadSolicitanteId,
                        principalTable: "Administrados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEstadosCaso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasoId = table.Column<int>(type: "int", nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEstadosCaso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoEstadosCaso_Acciones_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Acciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoEstadosCaso_Casos_CasoId",
                        column: x => x.CasoId,
                        principalTable: "Casos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoEstadosCaso_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnidadSolicitanteId = table.Column<int>(type: "int", nullable: false),
                    PersonaSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArchivoVinculado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEmisorId = table.Column<int>(type: "int", nullable: true),
                    TipoActoId = table.Column<int>(type: "int", nullable: true),
                    DocumentoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoAsignadoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoAsignadoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasoId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Casos_CasoId",
                        column: x => x.CasoId,
                        principalTable: "Casos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solicitudes_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_TiposActo_TipoActoId",
                        column: x => x.TipoActoId,
                        principalTable: "TiposActo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solicitudes_TiposEmisor_TipoEmisorId",
                        column: x => x.TipoEmisorId,
                        principalTable: "TiposEmisor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Solicitudes_UnidadesInstitucion_UnidadSolicitanteId",
                        column: x => x.UnidadSolicitanteId,
                        principalTable: "UnidadesInstitucion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoEstadosSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudId = table.Column<int>(type: "int", nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEstadosSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoEstadosSolicitud_Acciones_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Acciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoEstadosSolicitud_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoEstadosSolicitud_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_EstadoActualId",
                table: "Acciones",
                column: "EstadoActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_EstadoSiguienteId",
                table: "Acciones",
                column: "EstadoSiguienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Acciones_TipoAccionId",
                table: "Acciones",
                column: "TipoAccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministradoPersona_CargoPersonaRepresentanteId",
                table: "AdministradoPersona",
                column: "CargoPersonaRepresentanteId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministradoPersona_PersonaId",
                table: "AdministradoPersona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrados_TipoDocumentoId",
                table: "Administrados",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrados_TipoEntidadId",
                table: "Administrados",
                column: "TipoEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_EntidadSolicitanteId",
                table: "Casos",
                column: "EntidadSolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_EstadoId",
                table: "Casos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_ProcesoId",
                table: "Estados",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstadosCaso_AccionId",
                table: "HistoricoEstadosCaso",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstadosCaso_CasoId",
                table: "HistoricoEstadosCaso",
                column: "CasoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstadosCaso_EstadoId",
                table: "HistoricoEstadosCaso",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstadosSolicitud_AccionId",
                table: "HistoricoEstadosSolicitud",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstadosSolicitud_EstadoId",
                table: "HistoricoEstadosSolicitud",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstadosSolicitud_SolicitudId",
                table: "HistoricoEstadosSolicitud",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_CasoId",
                table: "Solicitudes",
                column: "CasoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_EstadoId",
                table: "Solicitudes",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TipoActoId",
                table: "Solicitudes",
                column: "TipoActoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TipoEmisorId",
                table: "Solicitudes",
                column: "TipoEmisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_UnidadSolicitanteId",
                table: "Solicitudes",
                column: "UnidadSolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministradoPersona");

            migrationBuilder.DropTable(
                name: "HistoricoEstadosCaso");

            migrationBuilder.DropTable(
                name: "HistoricoEstadosSolicitud");

            migrationBuilder.DropTable(
                name: "TiposEstado");

            migrationBuilder.DropTable(
                name: "CargosPersonaRepresentante");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Acciones");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "TiposAccion");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "TiposActo");

            migrationBuilder.DropTable(
                name: "TiposEmisor");

            migrationBuilder.DropTable(
                name: "UnidadesInstitucion");

            migrationBuilder.DropTable(
                name: "Administrados");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "TiposDocumento");

            migrationBuilder.DropTable(
                name: "TiposEntidad");

            migrationBuilder.DropTable(
                name: "Procesos");
        }
    }
}
