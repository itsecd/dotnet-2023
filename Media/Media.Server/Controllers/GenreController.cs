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
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IMediaRepository _repository;

    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    public GenreController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get list of genre 
    /// </summary>
    /// <returns>List of genre</returns>
    [HttpGet]
    public IEnumerable<Genre> Get()
    {
        return _repository.Genres;
    }

    /// <summary>
    /// Get genre by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Genre</returns>
    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre == null) { return NotFound(); }
        else return Ok(genre);
    }

    /// <summary>
    /// Post new genre
    /// </summary>
    /// <param name="genre"></param>
    [HttpPost]
    public void Post([FromBody] GenrePostDto genre)
    {
        _repository.Genres.Add(_mapper.Map<GenrePostDto, Genre>(genre));
    }

    /// <summary>
    /// Put genre
    /// </summary>
    /// <param name="id"></param>
    /// <param name="putGenre"></param>
    /// <returns>Id of puttable genre</returns>
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

    /// <summary>
    /// Delete genre by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var genre = _repository.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre != null) _repository.Genres.Remove(genre);
    }
}
