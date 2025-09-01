using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OperacaoFlorestal.Migrations
{
    /// <inheritdoc />
    public partial class ColetaDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoMaquinario",
                table: "Maquinarios");

            migrationBuilder.AddColumn<double>(
                name: "CapacidadeCarga",
                table: "Maquinarios",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "Maquinarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Maquinarios",
                type: "varchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TipoDrone",
                table: "Maquinarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DadosBrutosMaquinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMaquinario = table.Column<int>(type: "int", nullable: false),
                    MaquinarioId = table.Column<int>(type: "int", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataProcessamento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoDado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBrutosMaquinario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosBrutosMaquinario_Maquinarios_MaquinarioId",
                        column: x => x.MaquinarioId,
                        principalTable: "Maquinarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DadosBrutosVant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVoo = table.Column<int>(type: "int", nullable: false),
                    VooId = table.Column<int>(type: "int", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataProcessamento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBrutosVant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosBrutosVant_VooVants_VooId",
                        column: x => x.VooId,
                        principalTable: "VooVants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DadosBrutosMaquinario_MaquinarioId",
                table: "DadosBrutosMaquinario",
                column: "MaquinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosBrutosVant_VooId",
                table: "DadosBrutosVant",
                column: "VooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosBrutosMaquinario");

            migrationBuilder.DropTable(
                name: "DadosBrutosVant");

            migrationBuilder.DropColumn(
                name: "CapacidadeCarga",
                table: "Maquinarios");

            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "Maquinarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Maquinarios");

            migrationBuilder.DropColumn(
                name: "TipoDrone",
                table: "Maquinarios");

            migrationBuilder.AddColumn<string>(
                name: "TipoMaquinario",
                table: "Maquinarios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
