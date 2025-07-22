using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Segunda_API.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Bebidas','bebidas.jpg')");
            mb.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Lanches','lanche.jpg')");
            mb.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Sobremesas','sobremesa.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categorias WHERE Nome IN ('Bebidas', 'Lanches', 'Sobremesas')");
        }
    }
}
