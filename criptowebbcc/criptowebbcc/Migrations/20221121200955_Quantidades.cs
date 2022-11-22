using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class Quantidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidadeCompra",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantidadeVenda",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidadeCompra",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "quantidadeVenda",
                table: "Produtos");
        }
    }
}
