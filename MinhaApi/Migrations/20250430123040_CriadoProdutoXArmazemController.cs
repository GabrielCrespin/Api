using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinhaApi.Migrations
{
    /// <inheritdoc />
    public partial class CriadoProdutoXArmazemController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Saldo",
                table: "ProdutoXArmazens",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoXArmazens_IdArmazem",
                table: "ProdutoXArmazens",
                column: "IdArmazem");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoXArmazens_IdProduto",
                table: "ProdutoXArmazens",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoXArmazens_Armazens_IdArmazem",
                table: "ProdutoXArmazens",
                column: "IdArmazem",
                principalTable: "Armazens",
                principalColumn: "UniqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoXArmazens_Produtos_IdProduto",
                table: "ProdutoXArmazens",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoXArmazens_Armazens_IdArmazem",
                table: "ProdutoXArmazens");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoXArmazens_Produtos_IdProduto",
                table: "ProdutoXArmazens");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoXArmazens_IdArmazem",
                table: "ProdutoXArmazens");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoXArmazens_IdProduto",
                table: "ProdutoXArmazens");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "ProdutoXArmazens",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
