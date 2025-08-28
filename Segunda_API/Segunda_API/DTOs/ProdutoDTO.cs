using Segunda_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Segunda_API.DTOs;

public class ProdutoDTO
{
    public int ProdutoId { set; get; }

    [Required(ErrorMessage = "O Nome é obrigatório...")]
    [StringLength(100)]
    // [PrimeiraLetraMaiuscula]
    public string? Nome { set; get; }

    [Required]
    [StringLength(300)]
    public string? Descricao { set; get; }

    [Required]
    public decimal Preco { set; get; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { set; get; }
    public int CategoriaId { set; get; }

}
