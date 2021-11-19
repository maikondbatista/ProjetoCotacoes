using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cotacoes.Infra.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cotacao",
                columns: table => new
                {
                    NumeroCotacao = table.Column<long>(type: "bigint", nullable: false),
                    CNPJComprador = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CNPJFornecedor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntregaCotacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotacao", x => x.NumeroCotacao);
                });

            migrationBuilder.CreateTable(
                name: "CotacaoItem",
                columns: table => new
                {
                    NumeroItem = table.Column<long>(type: "bigint", nullable: false),
                    NumeroCotacao = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotacaoItem", x => x.NumeroItem);
                    table.ForeignKey(
                        name: "FK_CotacaoItem_Cotacao_NumeroCotacao",
                        column: x => x.NumeroCotacao,
                        principalTable: "Cotacao",
                        principalColumn: "NumeroCotacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotacaoItem_NumeroCotacao",
                table: "CotacaoItem",
                column: "NumeroCotacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotacaoItem");

            migrationBuilder.DropTable(
                name: "Cotacao");
        }
    }
}
