using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoCloud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ArrumandoCampoBairroTabelaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bairo",
                table: "Endereco",
                newName: "Bairro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bairro",
                table: "Endereco",
                newName: "Bairo");
        }
    }
}
