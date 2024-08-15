using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaWebApplicationMVC.Migrations
{
    /// <inheritdoc />
    public partial class publicaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ejemplares_Publicacion_PublicacionId",
                table: "Ejemplares");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Publicacion_PublicacionId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Revistas_Publicacion_PublicacionId",
                table: "Revistas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicacion",
                table: "Publicacion");

            migrationBuilder.RenameTable(
                name: "Publicacion",
                newName: "Publicaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicaciones",
                table: "Publicaciones",
                column: "PublicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ejemplares_Publicaciones_PublicacionId",
                table: "Ejemplares",
                column: "PublicacionId",
                principalTable: "Publicaciones",
                principalColumn: "PublicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Publicaciones_PublicacionId",
                table: "Libros",
                column: "PublicacionId",
                principalTable: "Publicaciones",
                principalColumn: "PublicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revistas_Publicaciones_PublicacionId",
                table: "Revistas",
                column: "PublicacionId",
                principalTable: "Publicaciones",
                principalColumn: "PublicacionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ejemplares_Publicaciones_PublicacionId",
                table: "Ejemplares");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Publicaciones_PublicacionId",
                table: "Libros");

            migrationBuilder.DropForeignKey(
                name: "FK_Revistas_Publicaciones_PublicacionId",
                table: "Revistas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publicaciones",
                table: "Publicaciones");

            migrationBuilder.RenameTable(
                name: "Publicaciones",
                newName: "Publicacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publicacion",
                table: "Publicacion",
                column: "PublicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ejemplares_Publicacion_PublicacionId",
                table: "Ejemplares",
                column: "PublicacionId",
                principalTable: "Publicacion",
                principalColumn: "PublicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Publicacion_PublicacionId",
                table: "Libros",
                column: "PublicacionId",
                principalTable: "Publicacion",
                principalColumn: "PublicacionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Revistas_Publicacion_PublicacionId",
                table: "Revistas",
                column: "PublicacionId",
                principalTable: "Publicacion",
                principalColumn: "PublicacionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
