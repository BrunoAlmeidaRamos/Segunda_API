using Segunda_API.Models;

namespace Segunda_API.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutoCategoria(int id);
}
