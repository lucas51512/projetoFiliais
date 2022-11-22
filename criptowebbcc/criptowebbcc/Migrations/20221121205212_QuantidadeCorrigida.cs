using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class QuantidadeCorrigida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "compra",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "quantidadeCompra",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "venda",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "quantidadeVenda",
                table: "Produtos",
                newName: "quantidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Produtos",
                newName: "quantidadeVenda");

            migrationBuilder.AddColumn<float>(
                name: "compra",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "quantidadeCompra",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "venda",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
