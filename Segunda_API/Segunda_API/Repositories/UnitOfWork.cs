using Segunda_API.Context;

namespace Segunda_API.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private ICategoriaRepository? _CategoriaRepo;
    private IProdutoRepository? _ProdutoRepo;
    public AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _CategoriaRepo ??= new CategoriaRepository(_context);
        }
    }
    public IProdutoRepository ProdutoRepository
    {
        get
        {
            return _ProdutoRepo ??= new ProdutoRepository(_context);
        }
    }
    public void commit()
    {
        _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
