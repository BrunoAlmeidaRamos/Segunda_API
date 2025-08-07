using Segunda_API.Models;

namespace Segunda_API.Repositories;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> GeCategorias();
    Categoria GetCategoria(int id);
    Categoria Create (Categoria categoria);
    Categoria Update(Categoria categoria);
    Categoria Delete(int id);
}
