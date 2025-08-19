using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;
using Microsoft.Extensions.Logging;
using Segunda_API.Repositories;

namespace Segunda_API.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly IRepository<Categoria> _repository;
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(IRepository<Categoria> repository, ILogger<CategoriasController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /*ttpGet("Produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    {
        return _repository.Categorias.Include(p=> p.Produtos).AsNoTracking().ToList();
    }*/ 

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        var categorias = _repository.GetAll();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _repository.GetById(c=> c.CategoriaId == id);
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<Produto> Post(Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest("Categoria não pode ser nulo.");
        }
       var CategoriaCriada = _repository.Create(categoria);

        return new CreatedAtRouteResult("ObterCategoria", new { id = CategoriaCriada.CategoriaId }, CategoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest("ID do Categoria não corresponde ao ID da URL.");
        }

        _repository.Update(categoria);
        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _repository.GetById(c => c.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound($"Categoria com ID {id} não encontrado.");
        }
        
        var categoriaRemovida = _repository.Delete(categoria);
        return Ok($"Categoria com ID {id} foi removido com sucesso.");
    }
}
