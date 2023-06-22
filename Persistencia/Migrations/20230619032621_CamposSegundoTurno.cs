using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class CamposSegundoTurno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "CandidatoId",
                table: "Voto",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinalizacao",
                table: "Eleicao",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPrimeiroTurno",
                table: "Eleicao",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CandidatosSegundoTurno",
                columns: table => new
                {
                    CandidadoId = table.Column<short>(type: "INTEGER", nullable: false),
                    EleicaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatosSegundoTurno", x => new { x.CandidadoId, x.EleicaoId });
                    table.ForeignKey(
                        name: "FK_CandidatosSegundoTurno_Candidato_CandidadoId",
                        column: x => x.CandidadoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatosSegundoTurno_Eleicao_EleicaoId",
                        column: x => x.EleicaoId,
                        principalTable: "Eleicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatosSegundoTurno_EleicaoId",
                table: "CandidatosSegundoTurno",
                column: "EleicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatosSegundoTurno");

            migrationBuilder.DropColumn(
                name: "DataFinalizacao",
                table: "Eleicao");

            migrationBuilder.DropColumn(
                name: "IdPrimeiroTurno",
                table: "Eleicao");

            migrationBuilder.AlterColumn<short>(
                name: "CandidatoId",
                table: "Voto",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "INTEGER");
        }
    }
}
