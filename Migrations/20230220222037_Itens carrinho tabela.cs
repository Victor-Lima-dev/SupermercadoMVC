using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supermercadoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Itenscarrinhotabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItensCarrinho",
                columns: table => new
                {
                    ItemCarrinhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    CarrinhoId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinho", x => x.ItemCarrinhoId);
                    table.ForeignKey(
                        name: "FK_ItensCarrinho_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinho_ProdutoId",
                table: "ItensCarrinho",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCarrinho");
        }
    }
}
