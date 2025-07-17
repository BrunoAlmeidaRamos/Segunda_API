namespace Segunda_API.Models;

public class Produto
{
    public int ProdutoId {set; get;}
    public string? Nome {set; get;}
    public string? Descricao {set; get;}
    public decimal Preco {set; get;}
    public string? ImagemUrl {set; get;}
    public float Estoque {set; get;}
    public DateTime DataCadastro {set; get;}
    public int CategoriaId {set; get;}

}
