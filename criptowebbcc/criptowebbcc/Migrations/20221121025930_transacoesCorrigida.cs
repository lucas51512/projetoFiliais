using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class transacoesCorrigida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Filiais_filialid",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_filialid",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "filialid",
                table: "Transacoes");

            migrationBuilder.AlterColumn<string>(
                name: "tipoProduto",
                table: "Transacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "tipoProduto",
                table: "Transacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "quantidade",
                table: "Transacoes",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "filialid",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_filialid",
                table: "Transacoes",
                column: "filialid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Filiais_filialid",
                table: "Transacoes",
                column: "filialid",
                principalTable: "Filiais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
