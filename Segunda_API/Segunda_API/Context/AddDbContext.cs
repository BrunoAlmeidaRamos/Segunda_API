using Microsoft.EntityFrameworkCore;
using Segunda_API.Models;

namespace Segunda_API.Context;

public class AddDbContext
{
    public AddDbContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias {set; get;}
    public DbSet<Produto>? Produtos { set; get; }
}   

