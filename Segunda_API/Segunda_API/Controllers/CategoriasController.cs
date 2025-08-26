using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;
using Microsoft.Extensions.Logging;
using Segunda_API.Repositories;
using Segunda_API.DTOs;

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
    public ActionResult<CategoriaDTO> Get(int id)
    {
        // 1️⃣ Pega a categoria do banco pelo repositório
        var categoria = _uof.CategoriaRepository.GetById(c=> c.CategoriaId == id);

        // 2️⃣ Converte a entidade para DTO
        var categoriaDto = new CategoriaDTO
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        };

        // 3️⃣ Retorna o DTO na resposta da API
        return Ok(categoriaDto);
    }

    [HttpPost]
    public ActionResult<Produto> Post(CategoriaDTO categoriaDto)
    {
        if (categoriaDto is null)
        {
            return BadRequest("Categoria não pode ser nulo.");
        }


       var CategoriaCriada = _uof.CategoriaRepository.Create(categoria);
        _uof.commit();

        return new CreatedAtRouteResult("ObterCategoria", new { id = CategoriaCriada.CategoriaId }, CategoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.CategoriaId)
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
