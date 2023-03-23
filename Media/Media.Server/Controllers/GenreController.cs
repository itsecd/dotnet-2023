using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IMediaRepository _repository;

    private readonly IMapper _mapper;
    public GenreController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Genre> Get()
    {
        return _repository.Genres;
    }

    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre == null) { return NotFound(); }
        else return Ok(genre);
    }

    [HttpPost]
    public void Post([FromBody] GenrePostDto genre)
    {
        _repository.Genres.Add(_mapper.Map<GenrePostDto, Genre>(genre));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GenrePostDto putGenre)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre == null) return NotFound();
        else
        {
            genre.Name = putGenre.Name;
            return Ok(new { genre.Id });
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre != null) _repository.Genres.Remove(genre);
    }
}
