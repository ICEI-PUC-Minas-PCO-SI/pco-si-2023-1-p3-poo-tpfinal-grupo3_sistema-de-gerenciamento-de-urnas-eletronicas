using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class MapeamentoBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eleicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ano = table.Column<short>(type: "INTEGER", nullable: false),
                    Mes = table.Column<short>(type: "INTEGER", nullable: false),
                    TipoEleicao = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusEleicao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partido",
                columns: table => new
                {
                    Id = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Idade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PartidoId = table.Column<short>(type: "INTEGER", nullable: false),
                    Cargo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidato_Partido_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EleicaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CandidatoId = table.Column<short>(type: "INTEGER", nullable: true),
                    Branco = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voto_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voto_Eleicao_EleicaoId",
                        column: x => x.EleicaoId,
                        principalTable: "Eleicao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_PartidoId",
                table: "Candidato",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_CandidatoId",
                table: "Voto",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_EleicaoId",
                table: "Voto",
                column: "EleicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voto");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Eleicao");

            migrationBuilder.DropTable(
                name: "Partido");
        }
    }
}
