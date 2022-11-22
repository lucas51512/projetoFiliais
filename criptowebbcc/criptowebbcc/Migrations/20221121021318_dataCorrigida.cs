using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class dataCorrigida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tansacoes_Contas_contaid",
                table: "Tansacoes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Moedas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tansacoes",
                table: "Tansacoes");

            migrationBuilder.RenameTable(
                name: "Tansacoes",
                newName: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "operacao",
                table: "Transacoes",
                newName: "tipoProduto");

            migrationBuilder.RenameColumn(
                name: "contaid",
                table: "Transacoes",
                newName: "filialid");

            migrationBuilder.RenameIndex(
                name: "IX_Tansacoes_contaid",
                table: "Transacoes",
                newName: "IX_Transacoes_filialid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Filiais_filialid",
                table: "Transacoes",
                column: "filialid",
                principalTable: "Filiais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Filiais_filialid",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "Tansacoes");

            migrationBuilder.RenameColumn(
                name: "tipoProduto",
                table: "Tansacoes",
                newName: "operacao");

            migrationBuilder.RenameColumn(
                name: "filialid",
                table: "Tansacoes",
                newName: "contaid");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_filialid",
                table: "Tansacoes",
                newName: "IX_Tansacoes_contaid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tansacoes",
                table: "Tansacoes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Moedas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    compra = table.Column<float>(type: "real", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    venda = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moedas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    moedaid = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contas_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Moedas_moedaid",
                        column: x => x.moedaid,
                        principalTable: "Moedas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_clienteid",
                table: "Contas",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_moedaid",
                table: "Contas",
                column: "moedaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tansacoes_Contas_contaid",
                table: "Tansacoes",
                column: "contaid",
                principalTable: "Contas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
