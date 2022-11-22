using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetofiliais.Migrations
{
    public partial class Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeProduto = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    descricaoProduto = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    compra = table.Column<float>(type: "real", nullable: false),
                    venda = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeFilial = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cidadeFilial = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    estadoFilial = table.Column<int>(type: "int", nullable: false),
                    Clienteid = table.Column<int>(type: "int", nullable: true),
                    Produtoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.id);
                    table.ForeignKey(
                        name: "FK_Filiais_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Filiais_Produtos_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "Produtos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_Clienteid",
                table: "Filiais",
                column: "Clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_Produtoid",
                table: "Filiais",
                column: "Produtoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
