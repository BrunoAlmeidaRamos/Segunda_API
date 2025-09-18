using Segunda_API.Context;
using Segunda_API.Models;
using Segunda_API.Paginations;

namespace Segunda_API.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }
    public IEnumerable<Produto> GetProdutoCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }

    public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParamets)
    {
       return GetAll()
            .Skip((produtosParamets.PageNumber - 1) * produtosParamets.PageSize)
            .Take(produtosParamets.PageSize);
    }
}
