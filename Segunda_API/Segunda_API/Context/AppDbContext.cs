using Microsoft.EntityFrameworkCore;
using Segunda_API.Models;

namespace Segunda_API.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias {set; get;}
    public DbSet<Produto>? Produtos { set; get; }
}   

