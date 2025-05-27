using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdcionaFilme([FromBody]CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Recupera uma coleção de filmes do banco de dados
    /// </summary>
    /// <param name="skip">Quantos objetos ele vai pular antes de retornar a lista de filmes</param>
    /// <param name="take">Quantos filmes serão retornados do banco de dados</param>
    /// <returns>IEnumerable de filmes</returns>
    /// <response code="200">Caso a requisição seja feita com sucesso</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0,[FromQuery]int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
    }

    /// <summary>
    /// Recupera um filme através do seu Id
    /// </summary>
    /// <param name="id">Identificação unica do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso requsição seja feita com sucesso</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme is null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
        // return filmes.Where(filme => filme.Id == id); o Where retorna um IEnumerable então não funciona, eu teria q trocar o método para retornar um IEnumerable
    }

    /// <summary>
    /// Faz um update de um filme por completo, precisa enviar todas as propriedades do corpo
    /// </summary>
    /// <param name="id">Identificação unica do filme</param>
    /// <param name="filmeDto">Objeto de um ReadDto</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o update seja feito com sucesso</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFilme(int id,[FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if ( filme is null)
        {
            return NotFound();  
        }
        _mapper.Map(filmeDto, filme); 
        _context.SaveChanges();
        return NoContent();

    }

    /// <summary>
    /// Faz um update parcial de um filme, assim podendo escolher quais propriedades serão alteradas
    /// </summary>
    /// <param name="id">Identificação unica do filme</param>
    /// <param name="patch">Instancia de um JsonPatchDocument</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o update seja feito com sucesso</response>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filme is null)
        {
            return NotFound();
        }
        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);
        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Remove um filme do banco de dados
    /// </summary>
    /// <param name="id">Identificação unica do filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso a remoção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id.Equals(id));
        if (filme is null)
        {
            return NotFound();
        }
        else
        {
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
