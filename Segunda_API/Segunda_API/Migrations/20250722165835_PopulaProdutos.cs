using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Segunda_API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)   
        {   
            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Coca-Cola', 'Coca-cola Zero', 5.00, 'coca-cola.jpg', true, now(), 1)");
            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Lanche de Frango', 'Lanche de Frango com Salada', 10.00, 'frango.jpg', true, now(), 2)");
            mb.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) VALUES ('Bolo de Chocolate', 'Bolo de Chocolate com Ninho', 25.00, 'bolo.jpg', false, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos WHERE Nome IN ('Coca-Cola', 'Lanche de Frango', 'Bolo de Chocolate')");
        }
    }
}
