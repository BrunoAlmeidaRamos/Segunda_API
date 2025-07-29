using Segunda_API.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Segunda_API.Models;

[Table("Produtos")]
public class Produto : IValidatableObject
{
    [Key]
    public int ProdutoId {set; get;}

    [Required(ErrorMessage = "O Nome é obrigatório...")]
    [StringLength(100)]
    // [PrimeiraLetraMaiuscula]
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Nome))
        {
            var primeiraletra = this.Nome[0].ToString();
            if (primeiraletra != primeiraletra.ToUpper())
            {
                yield return new ValidationResult("A primeira letra do nome deve ser maiúscula.", new[] { nameof(Nome) });
            }
        }

        if (this.Estoque <= 0)
        {
            yield return new ValidationResult("O estoque não pode ser negativo.", new[] { nameof(Estoque) });
        }
    }
}
