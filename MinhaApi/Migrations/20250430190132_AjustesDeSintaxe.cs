using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class AjustesDeSintaxe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoXArmazens_Armazens_IdArmazem",
                table: "ProdutoXArmazens");

            migrationBuilder.RenameColumn(
                name: "IdArmazem",
                table: "ProdutoXArmazens",
                newName: "ArmazemUniqueId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoXArmazens_IdArmazem",
                table: "ProdutoXArmazens",
                newName: "IX_ProdutoXArmazens_ArmazemUniqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoXArmazens_Armazens_ArmazemUniqueId",
                table: "ProdutoXArmazens",
                column: "ArmazemUniqueId",
                principalTable: "Armazens",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoXArmazens_Armazens_ArmazemUniqueId",
                table: "ProdutoXArmazens");

            migrationBuilder.RenameColumn(
                name: "ArmazemUniqueId",
                table: "ProdutoXArmazens",
                newName: "IdArmazem");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoXArmazens_ArmazemUniqueId",
                table: "ProdutoXArmazens",
                newName: "IX_ProdutoXArmazens_IdArmazem");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoXArmazens_Armazens_IdArmazem",
                table: "ProdutoXArmazens",
                column: "IdArmazem",
                principalTable: "Armazens",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
