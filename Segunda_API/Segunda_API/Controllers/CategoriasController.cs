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
    private readonly IUnitOfWork _uof;
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(IUnitOfWork uof, ILogger<CategoriasController> logger)
    {
        _uof = uof;
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
        var categorias = _uof.CategoriaRepository.GetAll();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _uof.CategoriaRepository.GetById(c=> c.CategoriaId == id);
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<Produto> Post(Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest("Categoria não pode ser nulo.");
        }
       var CategoriaCriada = _uof.CategoriaRepository.Create(categoria);
        _uof.commit();

        return new CreatedAtRouteResult("ObterCategoria", new { id = CategoriaCriada.CategoriaId }, CategoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest("ID do Categoria não corresponde ao ID da URL.");
        }

        _uof.CategoriaRepository.Update(categoria);
        _uof.commit();

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound($"Categoria com ID {id} não encontrado.");
        }
        
        var categoriaRemovida = _uof.CategoriaRepository.Delete(categoria);
        _uof.commit();

        return Ok($"Categoria com ID {id} foi removido com sucesso.");
    }
}
