using Segunda_API.Models;

namespace Segunda_API.DTOs.Mappings;

public static class CategoriaDTOMappingExtensions
{
    //1
    public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
    {         
        if (categoria == null) 
            return null;

        return new CategoriaDTO
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        };
    }

    //2
    public static Categoria? ToCategoria(this CategoriaDTO categoriaDto)
    {
        if (categoriaDto == null) 
            return null;

        return new Categoria
        {
            CategoriaId = categoriaDto.CategoriaId,
            Nome = categoriaDto.Nome,
            ImagemUrl = categoriaDto.ImagemUrl
        };
    }

    //3
    public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
    {
        if (categorias == null) 
            return Enumerable.Empty<CategoriaDTO>();
        return categorias.Select(categoria => categoria.ToCategoriaDTO()!).ToList();
    }
}
