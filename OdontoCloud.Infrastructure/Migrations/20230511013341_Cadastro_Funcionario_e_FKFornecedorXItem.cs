using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoCloud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cadastro_Funcionario_e_FKFornecedorXItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Atendimento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelResidencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<int>(type: "int", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Fornecedor_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelResidencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Funcionario_PK", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdFornecedor",
                table: "Item",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdFuncionario",
                table: "Atendimento",
                column: "IdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimento_Funcionario_IdFuncionario",
                table: "Atendimento",
                column: "IdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Fornecedor_IdFornecedor",
                table: "Item",
                column: "IdFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimento_Funcionario_IdFuncionario",
                table: "Atendimento");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Fornecedor_IdFornecedor",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Item_IdFornecedor",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Atendimento_IdFuncionario",
                table: "Atendimento");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Atendimento");
        }
    }
}
