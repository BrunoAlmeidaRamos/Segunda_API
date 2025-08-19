using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;

namespace Segunda_API.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaRepository(AppDbContext context) : base(context)
    {
    }
}
