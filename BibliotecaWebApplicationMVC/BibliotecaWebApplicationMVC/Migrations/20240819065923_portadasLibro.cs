using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaWebApplicationMVC.Migrations
{
    /// <inheritdoc />
    public partial class portadasLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContraportadaUrl",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PortadaUrl",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContraportadaUrl",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "PortadaUrl",
                table: "Libros");
        }
    }
}
