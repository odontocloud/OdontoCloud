using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoCloud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelResidencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndicadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cliente_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DescricaoEndereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Endereco_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeEstoque = table.Column<double>(type: "float", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<double>(type: "float", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Item_PK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anamnese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DoencaCardiovascular = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoDoencaCardiovascular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hipertencao = table.Column<bool>(type: "bit", nullable: false),
                    Diabetes = table.Column<bool>(type: "bit", nullable: false),
                    DoencaRespiratoria = table.Column<bool>(type: "bit", nullable: false),
                    DoencaHepatica = table.Column<bool>(type: "bit", nullable: false),
                    Osteoporose = table.Column<bool>(type: "bit", nullable: false),
                    CoagulacaoSangramento = table.Column<bool>(type: "bit", nullable: false),
                    ProblemaGastrico = table.Column<bool>(type: "bit", nullable: false),
                    Hepatite = table.Column<bool>(type: "bit", nullable: false),
                    TratamentoMedico = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoTratamentoMedico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alergia = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoAlergia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fumante = table.Column<bool>(type: "bit", nullable: false),
                    Gravida = table.Column<bool>(type: "bit", nullable: false),
                    GravidaAmamentando = table.Column<bool>(type: "bit", nullable: false),
                    RestricaoMedicamento = table.Column<bool>(type: "bit", nullable: false),
                    DescricaoRestricaoMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicamentoUso = table.Column<bool>(type: "bit", nullable: false),
                    ProblemaAnestesia = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Anamnese_PK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamnese_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoDuracao = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Atendimento_PK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimento_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalheAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    QuantidadeItem = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DetalheAtendimento_PK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalheAtendimento_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalheAtendimento_Item_IdItem",
                        column: x => x.IdItem,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamnese_IdCliente",
                table: "Anamnese",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdCliente",
                table: "Atendimento",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheAtendimento_IdAtendimento",
                table: "DetalheAtendimento",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheAtendimento_IdItem",
                table: "DetalheAtendimento",
                column: "IdItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anamnese");

            migrationBuilder.DropTable(
                name: "DetalheAtendimento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
