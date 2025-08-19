using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;
using Segunda_API.Repositories;

namespace Segunda_API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IRepository<Produto> _repository;

    public ProdutosController(IRepository<Produto> repository, IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
        _repository = repository;
    }

    [HttpGet("Produto/{id}")]
    public ActionResult<IEnumerable<Produto>> GetProdutosCategorias(int id)
    {
        var produtos = _produtoRepository.GetProdutoCategoria(id);

        if (produtos is null)
            return NotFound($"Não existem produtos para a categoria com ID {id}.");

        return Ok(produtos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _repository.GetAll();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados.");
        }

        return Ok(produtos);
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _repository.GetById(c=> c.ProdutoId == id);
        if (produto is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }
        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<Produto> Post(Produto produto)
    {
        if (produto is null)
        {
            return BadRequest("Produto não pode ser nulo.");
        }
        
        var NovoProduto = _repository.Create(produto);

        return new CreatedAtRouteResult("ObterProduto", new { id = NovoProduto.ProdutoId }, NovoProduto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id,Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest("ID do produto não corresponde ao ID da URL.");
        }

        var ProdutoAtualizado = _repository.Update(produto);

        return Ok(ProdutoAtualizado);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
       var produto = _repository.GetById(p=> p.ProdutoId == id);

        if (produto is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }

        var ProdutoDeletado = _repository.Delete(produto);
        return Ok(ProdutoDeletado);

    }
}
