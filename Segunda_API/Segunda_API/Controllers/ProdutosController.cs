using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.DTOs;
using Segunda_API.Models;
using Segunda_API.Repositories;

namespace Segunda_API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uof;

    public ProdutosController(IUnitOfWork uof)
    {
        _uof = uof;
    }

    [HttpGet("Produto/{id}")]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosCategorias(int id)
    {
        var produtos = _uof.ProdutoRepository.GetProdutoCategoria(id);

        if (produtos is null)
            return NotFound($"Não existem produtos para a categoria com ID {id}.");

        return Ok(produtos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoDTO>> Get()
    {
        var produtos = _uof.ProdutoRepository.GetAll();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados.");
        }

        return Ok(produtos);
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<ProdutoDTO> Get(int id)
    {
        var produto = _uof.ProdutoRepository.GetById(c=> c.ProdutoId == id);
        if (produto is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }
        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<ProdutoDTO> Post(ProdutoDTO produtoDto)
    {
        if (produtoDto is null)
        {
            return BadRequest("Produto não pode ser nulo.");
        }
        
        var NovoProduto = _uof.ProdutoRepository.Create(produto);
        _uof.commit();

        return new CreatedAtRouteResult("ObterProduto", new { id = NovoProduto.ProdutoId }, NovoProduto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProdutoDTO> Put(int id,ProdutoDTO produtoDto)
    {
        if (id != produtoDto.ProdutoId)
        {
            return BadRequest("ID do produto não corresponde ao ID da URL.");
        }

        var ProdutoAtualizado = _uof.ProdutoRepository.Update(produto);
        _uof.commit();

        return Ok(ProdutoAtualizado);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<ProdutoDTO> Delete(int id)
    {
       var produto = _uof.ProdutoRepository.GetById(p=> p.ProdutoId == id);

        if (produto is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }

        var ProdutoDeletado = _uof.ProdutoRepository.Delete(produto);
        _uof.commit();

        return Ok(ProdutoDeletado);

    }
}
