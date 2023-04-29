using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductoId",
                table: "Categorias",
                type: "numeric(38,0)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProductoId",
                table: "Categorias",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Productos_ProductoId",
                table: "Categorias",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Productos_ProductoId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_ProductoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Categorias");
        }
    }
}
