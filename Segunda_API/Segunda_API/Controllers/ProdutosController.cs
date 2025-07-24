using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;

namespace Segunda_API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        var produtos = _context.Produtos?.AsNoTracking().ToList();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados.");
        }

        return produtos;
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }
        return produto;
    }

    [HttpPost]
    public ActionResult<Produto> Post(Produto produto)
    {
        if (produto is null)
        {
            return BadRequest("Produto não pode ser nulo.");
        }
        _context.Produtos?.Add(produto);
        _context.SaveChanges();
        return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id,Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return BadRequest("ID do produto não corresponde ao ID da URL.");
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos?.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            return NotFound($"Produto com ID {id} não encontrado.");
        }
        _context.Produtos?.Remove(produto);
        _context.SaveChanges();
        return Ok($"Produto com ID {id} foi removido com sucesso.");
    }
}
