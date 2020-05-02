using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agencia = table.Column<int>(nullable: false),
                    NumeroConta = table.Column<int>(nullable: false),
                    DigitoConta = table.Column<int>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    SaldoAtual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrenteTransacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaCorrenteId = table.Column<int>(nullable: false),
                    DataTransacao = table.Column<DateTime>(nullable: false),
                    TipoTransacao = table.Column<int>(nullable: false),
                    ValorTransacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrenteTransacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContaCorrenteTransacoes_ContaCorrentes_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContaCorrenteTransacoes_ContaCorrenteId",
                table: "ContaCorrenteTransacoes",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContaCorrenteTransacoes");

            migrationBuilder.DropTable(
                name: "ContaCorrentes");
        }
    }
}
