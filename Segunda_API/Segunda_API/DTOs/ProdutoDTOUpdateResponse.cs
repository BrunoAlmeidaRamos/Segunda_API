using Segunda_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Segunda_API.DTOs;

public class ProdutoDTOUpdateResponse
{
   
    public int ProdutoId { set; get; }
    public string? Nome { set; get; }
    public string? Descricao { set; get; }
    public decimal Preco { set; get; }
    public string? ImagemUrl { set; get; }
    public float Estoque { set; get; }
    public DateTime DataCadastro { set; get; }
    public int CategoriaId { set; get; }
    public Categoria? Categoria { set; get; }
}
