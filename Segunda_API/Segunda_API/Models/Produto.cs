using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Segunda_API.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId {set; get;}

    [Required(ErrorMessage = "O Nome é obrigatório...")]
    [StringLength(100)]
    public string? Nome {set; get;}

    [Required]
    [StringLength(300)]
    public string? Descricao {set; get;}

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco {set; get;}

    [Required]
    [StringLength(300)]
    public string? ImagemUrl {set; get;}
    public float Estoque {set; get;}
    public DateTime DataCadastro {set; get;}
    public int CategoriaId {set; get;}

    [JsonIgnore]
    public Categoria? Categoria {set; get; }

}
