using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrosApi.Migrations
{
    /// <inheritdoc />
    public partial class Corrigindoatabelalivrosparte3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Livros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Livros",
                type: "integer",
                nullable: true);
        }
    }
}
