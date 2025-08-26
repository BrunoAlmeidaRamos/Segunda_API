using System.ComponentModel.DataAnnotations;

namespace Segunda_API.DTOs;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
}
