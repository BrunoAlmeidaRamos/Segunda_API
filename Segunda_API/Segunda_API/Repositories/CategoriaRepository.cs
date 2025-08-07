using Segunda_API.Context;
using Segunda_API.Models;

namespace Segunda_API.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppContext _context;
    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Categoria> GeCategorias()
    {
        throw new NotImplementedException();
    }
    public Categoria GetCategoria(int id)
    {
        throw new NotImplementedException();
    }
    public Categoria Create(Categoria categoria)
    {
        throw new NotImplementedException();
    }
    public Categoria Update(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public Categoria Delete(int id)
    {
        throw new NotImplementedException();
    }
}
