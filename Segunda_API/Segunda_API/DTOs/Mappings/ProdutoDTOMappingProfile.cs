using AutoMapper;
using Segunda_API.Models;

namespace Segunda_API.DTOs.Mappings;

public class ProdutoDTOMappingProfile : Profile
{
    public ProdutoDTOMappingProfile()
    {
        CreateMap<ProdutoDTO, Produto>().ReverseMap();
        CreateMap<CategoriaDTO, Categoria>().ReverseMap();
    }
}
