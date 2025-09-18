using Segunda_API.Models;
using Segunda_API.Paginations;

namespace Segunda_API.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParamets);
    IEnumerable<Produto> GetProdutoCategoria(int id);
}
