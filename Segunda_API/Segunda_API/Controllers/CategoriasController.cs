using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Segunda_API.Context;
using Segunda_API.Models;
using Microsoft.Extensions.Logging;
using Segunda_API.Repositories;
using Segunda_API.DTOs;
using Segunda_API.DTOs.Mappings;

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
    public ActionResult<IEnumerable<CategoriaDTO>> Get()
    {
        var categorias = _uof.CategoriaRepository.GetAll();
        var categoriasDto = categorias.ToCategoriaDTOList();

        return Ok(categoriasDto);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<CategoriaDTO> Get(int id)
    {
        // 1️⃣ Pega a categoria do banco pelo repositório
        var categoria = _uof.CategoriaRepository.GetById(c=> c.CategoriaId == id);

        var categoriaDto = categoria.ToCategoriaDTO();

        // 3️⃣ Retorna o DTO na resposta da API
        return Ok(categoriaDto);
    }

    [HttpPost]
    public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto)
    {
        if (categoriaDto is null)
        {
            return BadRequest("Categoria não pode ser nulo.");
        }

        var categoria = CategoriaDTO.ToCategoria();

        var CategoriaCriada = _uof.CategoriaRepository.Create(categoria);
        _uof.commit();

        var NovaCategoriaDto = CategoriaCriada.ToCategoriaDTO();

        return new CreatedAtRouteResult("ObterCategoria", new { id = NovaCategoriaDto.CategoriaId }, NovaCategoriaDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.CategoriaId)
        {
            return BadRequest("ID do Categoria não corresponde ao ID da URL.");
        }

        var categoria = categoriaDto.ToCategoria();

        var categoriaAtualizada = _uof.CategoriaRepository.Update(categoria);
        _uof.commit();

        var categoriaAtualizadaDto = categoriaAtualizada.ToCategoriaDTO();

        return Ok(categoriaAtualizadaDto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> Delete(int id)
    {
        var categoria = _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
        if (categoria is null)
        {
            return NotFound($"Categoria com ID {id} não encontrado.");
        }
        
        var categoriaRemovida = _uof.CategoriaRepository.Delete(categoria);
        _uof.commit();

        var categoriaRemovidaDto = categoriaRemovida.ToCategoriaDTO();

        return Ok($"Categoria com ID {id} foi removido com sucesso.");
    }
}
