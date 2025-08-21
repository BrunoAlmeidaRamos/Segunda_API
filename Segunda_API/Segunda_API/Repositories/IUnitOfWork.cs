namespace Segunda_API.Repositories;

public interface IUnitOfWork
{
    ICategoriaRepository CategoriaRepository { get; }
    IProdutoRepository ProdutoRepository { get; }
    void commit();
}
