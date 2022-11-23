using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class RelacoesTransacoesCorrigido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "produtoid",
                table: "Transacoes",
                newName: "produtoId");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Transacoes",
                newName: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_clienteId",
                table: "Transacoes",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_produtoId",
                table: "Transacoes",
                column: "produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Clientes_clienteId",
                table: "Transacoes",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Produtos_produtoId",
                table: "Transacoes",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Clientes_clienteId",
                table: "Transacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Produtos_produtoId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_clienteId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_produtoId",
                table: "Transacoes");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "Transacoes",
                newName: "produtoid");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Transacoes",
                newName: "clienteid");
        }
    }
}
