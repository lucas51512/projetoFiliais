using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace criptowebbcc.Migrations
{
    public partial class Anotacoes_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contas_clientes_clienteid",
                table: "contas");

            migrationBuilder.DropForeignKey(
                name: "FK_contas_moedas_moedaid",
                table: "contas");

            migrationBuilder.DropForeignKey(
                name: "FK_transacoes_contas_contaid",
                table: "transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_moedas",
                table: "moedas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contas",
                table: "contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes");

            migrationBuilder.RenameTable(
                name: "moedas",
                newName: "Moedas");

            migrationBuilder.RenameTable(
                name: "contas",
                newName: "Contas");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "transacoes",
                newName: "Tansacoes");

            migrationBuilder.RenameIndex(
                name: "IX_contas_moedaid",
                table: "Contas",
                newName: "IX_Contas_moedaid");

            migrationBuilder.RenameIndex(
                name: "IX_contas_clienteid",
                table: "Contas",
                newName: "IX_Contas_clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_transacoes_contaid",
                table: "Tansacoes",
                newName: "IX_Tansacoes_contaid");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Moedas",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "moedaid",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Clientes",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "Clientes",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "Tansacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moedas",
                table: "Moedas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                table: "Contas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tansacoes",
                table: "Tansacoes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Moedas_moedaid",
                table: "Contas",
                column: "moedaid",
                principalTable: "Moedas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tansacoes_Contas_contaid",
                table: "Tansacoes",
                column: "contaid",
                principalTable: "Contas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_clienteid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Moedas_moedaid",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tansacoes_Contas_contaid",
                table: "Tansacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moedas",
                table: "Moedas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                table: "Contas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tansacoes",
                table: "Tansacoes");

            migrationBuilder.RenameTable(
                name: "Moedas",
                newName: "moedas");

            migrationBuilder.RenameTable(
                name: "Contas",
                newName: "contas");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameTable(
                name: "Tansacoes",
                newName: "transacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_moedaid",
                table: "contas",
                newName: "IX_contas_moedaid");

            migrationBuilder.RenameIndex(
                name: "IX_Contas_clienteid",
                table: "contas",
                newName: "IX_contas_clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Tansacoes_contaid",
                table: "transacoes",
                newName: "IX_transacoes_contaid");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "moedas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<int>(
                name: "moedaid",
                table: "contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "cidade",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<int>(
                name: "contaid",
                table: "transacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_moedas",
                table: "moedas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contas",
                table: "contas",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transacoes",
                table: "transacoes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_contas_clientes_clienteid",
                table: "contas",
                column: "clienteid",
                principalTable: "clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_contas_moedas_moedaid",
                table: "contas",
                column: "moedaid",
                principalTable: "moedas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transacoes_contas_contaid",
                table: "transacoes",
                column: "contaid",
                principalTable: "contas",
                principalColumn: "id");
        }
    }
}
