using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace supermercadoMVC.Migrations
{
    /// <inheritdoc />
    public partial class Popularcomprodutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //adicionar produtos - categoria: Alimentos
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Arroz', 'Arroz 5kg', 15.99, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Feijão', 'Feijão 1kg', 5.99, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Macarrão', 'Macarrão 1kg', 3.99, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Açúcar', 'Açúcar 1kg', 2.99, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Sal', 'Sal 1kg', 1.99, 10, 'Alimentos')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Óleo', 'Óleo 1L', 4.99, 10, 'Alimentos')");
            //adicionar produtos - categoria: Bebidas
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Coca-Cola', 'Coca-Cola 2L', 5.99, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Guaraná', 'Guaraná 2L', 5.99, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Fanta', 'Fanta 2L', 5.99, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Suco de Laranja', 'Suco de Laranja 1L', 4.99, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Suco de Uva', 'Suco de Uva 1L', 4.99, 10, 'Bebidas')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Água Mineral', 'Água Mineral 1L', 2.99, 10, 'Bebidas')");
            //adicionar produtos - categoria: Limpeza
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Sabão em Pó', 'Sabão em Pó 1kg', 5.99, 10, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Detergente', 'Detergente 1L', 4.99, 10, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Álcool', 'Álcool 1L', 3.99, 10, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Amaciante', 'Amaciante 1L', 4.99, 10, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Desinfetante', 'Desinfetante 1L', 3.99, 10, 'Limpeza')");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, Quantidade, Categoria) VALUES ('Sabonete', 'Sabonete 1kg', 2.99, 10, 'Limpeza')");
            //adicionar produtos - categoria: Higiene


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Categoria = 'Alimentos'");
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Categoria = 'Bebidas'");
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Categoria = 'Limpeza'");
            migrationBuilder.Sql("DELETE FROM Produtos WHERE Categoria = 'Higiene'");
        }
    }
}
