using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;

namespace Segunda_API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("Produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        return _context.Categorias.Include(p=> p.Produtos).AsNoTracking().ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _context.Categorias?.AsNoTracking().ToList();

        if (categorias is null)
        {
            return NotFound("Categoria não encontrados.");
        }

        return categorias;
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categorias?.FirstOrDefault(p => p.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }
        return categoria;
    }

    [HttpPost]
    public ActionResult<Produto> Post(Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest("Categoria não pode ser nulo.");
        }
        _context.Categorias?.Add(categoria);
        _context.SaveChanges();
        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest("ID do Categoria não corresponde ao ID da URL.");
        }

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _context.Categorias?.FirstOrDefault(p => p.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound($"Categoria com ID {id} não encontrado.");
        }
        _context.Categorias?.Remove(categoria);
        _context.SaveChanges();
        return Ok($"Categoria com ID {id} foi removido com sucesso.");
    }
}
