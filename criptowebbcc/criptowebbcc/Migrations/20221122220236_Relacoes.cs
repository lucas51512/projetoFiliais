using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class Relacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Clientes_Clienteid",
                table: "Filiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Produtos_Produtoid",
                table: "Filiais");

            migrationBuilder.RenameColumn(
                name: "Produtoid",
                table: "Filiais",
                newName: "produtoId");

            migrationBuilder.RenameColumn(
                name: "Clienteid",
                table: "Filiais",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Filiais_Produtoid",
                table: "Filiais",
                newName: "IX_Filiais_produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Filiais_Clienteid",
                table: "Filiais",
                newName: "IX_Filiais_clienteId");

            migrationBuilder.AlterColumn<int>(
                name: "produtoId",
                table: "Filiais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteId",
                table: "Filiais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "transacaoId",
                table: "Filiais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_transacaoId",
                table: "Filiais",
                column: "transacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Clientes_clienteId",
                table: "Filiais",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Produtos_produtoId",
                table: "Filiais",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Transacoes_transacaoId",
                table: "Filiais",
                column: "transacaoId",
                principalTable: "Transacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Clientes_clienteId",
                table: "Filiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Produtos_produtoId",
                table: "Filiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Transacoes_transacaoId",
                table: "Filiais");

            migrationBuilder.DropIndex(
                name: "IX_Filiais_transacaoId",
                table: "Filiais");

            migrationBuilder.DropColumn(
                name: "transacaoId",
                table: "Filiais");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "Filiais",
                newName: "Produtoid");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Filiais",
                newName: "Clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Filiais_produtoId",
                table: "Filiais",
                newName: "IX_Filiais_Produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_Filiais_clienteId",
                table: "Filiais",
                newName: "IX_Filiais_Clienteid");

            migrationBuilder.AlterColumn<int>(
                name: "Produtoid",
                table: "Filiais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Clienteid",
                table: "Filiais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Clientes_Clienteid",
                table: "Filiais",
                column: "Clienteid",
                principalTable: "Clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Produtos_Produtoid",
                table: "Filiais",
                column: "Produtoid",
                principalTable: "Produtos",
                principalColumn: "id");
        }
    }
}
