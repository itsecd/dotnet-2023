using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

/// <summary>
/// Genre controller
/// </summary>
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

    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<GenreController> _logger;

    public GenreController(IMediaRepository repository, IMapper mapper, ILogger<GenreController> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get list of genre 
    /// </summary>
    /// <returns>List of genre</returns>
    [HttpGet]
    public IEnumerable<Genre> Get()
    {
        _logger.LogInformation("GET: Get list of genre");
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
        if (genre == null)
        {
            _logger.LogInformation($"GET(id): Genre with id = {id} not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET(id): Get genre with id = {id}");
            return Ok(genre);
        }
    }

    /// <summary>
    /// Post new genre
    /// </summary>
    /// <param name="genre"></param>
    [HttpPost]
    public void Post([FromBody] GenrePostDto genre)
    {
        _logger.LogInformation("Post new genre");
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
        if (genre == null)
        {
            _logger.LogInformation($"PUT: Genre with id = {id} not found");
            return NotFound();
        }
        else
        {
            genre.Name = putGenre.Name;
            _logger.LogInformation($"PUT: Put genre with id = {id}");
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
        if (genre != null)
        {
            if (_repository.Genres.Remove(genre)) _logger.LogInformation($"DELETE: Delete genre with id = {id}");
        }
    }
}
