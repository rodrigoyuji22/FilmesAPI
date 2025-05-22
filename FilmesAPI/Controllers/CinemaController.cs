using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("controller")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult CriarCinema(CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new {id = cinema.Id}, cinemaDto);
    }

    [HttpGet]
    public IActionResult RecuperaCinemas()
    {
        var cinemas = _context.Cinemas.ToList();
        var cinemasDto = _mapper.Map<List<ReadCinemaDto>>(cinemas);
        return Ok(cinemasDto);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorId(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));
        if (cinema is null)
        {
            return NotFound();
        }
        var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Ok(cinemaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AlterarCinema(int id,[FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));
        if (cinema is null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult AlterarCinemaParcialmente(int id, JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));
        if (cinema is null)
        {
            return NotFound();
        }
        var cinemaParaAtualizar = _mapper.Map<UpdateCinemaDto>(cinema);
        patch.ApplyTo(cinemaParaAtualizar, ModelState);
        if (!TryValidateModel(cinemaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(cinemaParaAtualizar, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id.Equals(id));
        if (cinema is null)
        {
            return NotFound();
        }
        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }

}

