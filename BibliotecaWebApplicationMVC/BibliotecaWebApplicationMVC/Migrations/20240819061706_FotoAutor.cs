using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaWebApplicationMVC.Migrations
{
    /// <inheritdoc />
    public partial class FotoAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Autores");
        }
    }
}
