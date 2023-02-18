using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supermercadoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Popularcomprodutos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //popular a tabela de produtos
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Arroz', 'Arroz 5kg', 10.50, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Feijão', 'Feijão 1kg', 3.50, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Macarrão', 'Macarrão 1kg', 2.50, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Café', 'Café 500g', 5.50, 10, 'Alimentos')");
            //popular a tabela de produtos bebidax
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Coca-Cola', 'Coca-Cola 2L', 5.50, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Guaraná', 'Guaraná 2L', 5.50, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Fanta', 'Fanta 2L', 5.50, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Sprite', 'Sprite 2L', 5.50, 10, 'Bebidas')");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Categoria = 'Alimentos'");
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Categoria = 'Bebidas'");
        }
    }
}
