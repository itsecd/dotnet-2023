using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media.Server.Controllers;

/// <summary>
/// Genre controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<GenreController> _logger;

    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<MediaContext> _contextFactory;

    public GenreController(IMapper mapper, ILogger<GenreController> logger, IDbContextFactory<MediaContext> contextFactory)
    {
        _mapper = mapper;
        _logger = logger;
        _contextFactory = contextFactory;
    }

    /// <summary>
    /// Get list of genre 
    /// </summary>
    /// <returns>List of genre</returns>
    [HttpGet]
    public IEnumerable<Genre> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("GET: Get list of genre");
        return context.Genres.ToList();
    }

    /// <summary>
    /// Get genre by id
    /// </summary>
    /// <param name="id">Genre Id</param>
    /// <returns>Genre</returns>
    [HttpGet("{id}")]
    public ActionResult<Genre> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var genre = context.Genres.FirstOrDefault(genre => genre.Id == id);
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
    /// <param name="genre">Genre name</param>
    [HttpPost]
    public void Post([FromBody] GenrePostDto genre)
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post new genre");
        context.Genres.Add(_mapper.Map<GenrePostDto, Genre>(genre));
        context.SaveChanges();
    }

    /// <summary>
    /// Put genre
    /// </summary>
    /// <param name="id">Genre Id</param>
    /// <param name="putGenre">Genre to putting</param>
    /// <returns>Id of put-genre</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GenrePostDto putGenre)
    {
        using var context = _contextFactory.CreateDbContext();
        var genre = context.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre == null)
        {
            _logger.LogInformation($"PUT: Genre with id = {id} not found");
            return NotFound();
        }
        else
        {
            genre.Name = putGenre.Name;
            _logger.LogInformation($"PUT: Put genre with id = {id}");
            context.SaveChanges();
            return Ok(new { genre.Id });
        }
    }

    /// <summary>
    /// Delete genre by id
    /// </summary>
    /// <param name="id">Genre Id</param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var genre = context.Genres.FirstOrDefault(genre => genre.Id == id);
        if (genre != null)
        {
            context.Genres.Remove(genre);
            _logger.LogInformation($"DELETE: Delete genre with id = {id}");
            context.SaveChanges();
        }
    }
}
