using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    public partial class AtualizarProduto4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "UrlArquivo",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlArquivo",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "OrderDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
