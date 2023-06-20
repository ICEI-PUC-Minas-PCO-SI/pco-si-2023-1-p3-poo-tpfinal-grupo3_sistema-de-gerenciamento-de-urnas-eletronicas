using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class VagasNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Vagas",
                table: "Eleicao",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Vagas",
                table: "Eleicao",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
