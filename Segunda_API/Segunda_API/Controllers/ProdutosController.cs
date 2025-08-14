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
    private readonly IProdutoRepository _repository;

    public ProdutosController(IProdutoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _repository.GetProdutos().ToList();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados.");
        }

        return Ok(produtos);
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _repository.GetProduto(id);
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

        bool atualizado = _repository.Update(produto);
        if (atualizado)
        {
            return Ok(produto);
        }
        else
        {
            return StatusCode(500, $"Produto com ID {id} não encontrado ou não pôde ser atualizado.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
       bool deletado = _repository.Delete(id);
        if (deletado)
        {
            return Ok($"Produto com ID {id} foi deletado.");
        }
        else
        {
            return StatusCode(500, $"Produto com ID {id} não encontrado ou não pôde ser exluido.");
        }
    }
}
