using AutoMapper;
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
    private readonly IMapper _mapper;

    public ProdutosController(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("Produto/{id}")]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosCategorias(int id)
    {
        var produtos = _uof.ProdutoRepository.GetProdutoCategoria(id);

        if (produtos is null)
            return NotFound($"Não existem produtos para a categoria com ID {id}.");

        //var destino = _mapper.map<Destino>(origem);
        var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

        return Ok(produtosDto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoDTO>> Get()
    {
        var produtos = _uof.ProdutoRepository.GetAll();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrados.");
        }
        var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

        return Ok(produtosDto);
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<ProdutoDTO> Get(int id)
    {
        var produto = _uof.ProdutoRepository.GetById(c=> c.ProdutoId == id);
        if (produto is null)
        {
            return NotFound($"Esse ID {id} Não existe");
        }
        var produtosDto = _mapper.Map<ProdutoDTO>(produto);

        return Ok(produtosDto);
    }

    [HttpPost]
    public ActionResult<ProdutoDTO> Post(ProdutoDTO produtoDto)
    {
        if (produtoDto is null)
        {
            return BadRequest("Produto não pode ser nulo.");
        }
        var produto = _mapper.Map<Produto>(produtoDto);

        var NovoProduto = _uof.ProdutoRepository.Create(produto);
        _uof.commit();

        var NovoProdutoDto = _mapper.Map<ProdutoDTO>(NovoProduto);

        return new CreatedAtRouteResult("ObterProduto", new { id = NovoProdutoDto.ProdutoId }, NovoProdutoDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProdutoDTO> Put(int id,ProdutoDTO produtoDto)
    {
        if (id != produtoDto.ProdutoId)
        {
            return BadRequest("ID do produto não corresponde ao ID da URL.");
        }

        var produto = _mapper.Map<Produto>(produtoDto);

        var ProdutoAtualizado = _uof.ProdutoRepository.Update(produto);
        _uof.commit();

        var ProdutoAtualizadoDto = _mapper.Map<ProdutoDTO>(ProdutoAtualizado);

        return Ok(ProdutoAtualizadoDto);
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

        var ProdutoDeletadoDto = _mapper.Map<ProdutoDTO>(ProdutoDeletado);

        return Ok(ProdutoDeletadoDto);

    }
}
