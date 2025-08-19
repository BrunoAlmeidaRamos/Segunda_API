using Segunda_API.Context;
using Segunda_API.Models;

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
}
