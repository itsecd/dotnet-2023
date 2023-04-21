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
    public async Task<IEnumerable<Genre>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of genre");
        return await context.Genres.ToListAsync();
    }

    /// <summary>
    /// Get genre by id
    /// </summary>
    /// <param name="id">Genre Id</param>
    /// <returns>Genre</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var genre = await context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
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
    public async Task<IActionResult> Post([FromBody] GenrePostDto genre)
    { 
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post new genre");
        await context.Genres.AddAsync(_mapper.Map<GenrePostDto, Genre>(genre));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put genre
    /// </summary>
    /// <param name="id">Genre Id</param>
    /// <param name="putGenre">Genre to putting</param>
    /// <returns>Id of put-genre</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] GenrePostDto putGenre)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var genre = await context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
        if (genre == null)
        {
            _logger.LogInformation($"PUT: Genre with id = {id} not found");
            return NotFound();
        }
        else
        {
            genre.Name = putGenre.Name;
            _logger.LogInformation($"PUT: Put genre with id = {id}");
            await context.SaveChangesAsync();
            return Ok(new { genre.Id });
        }
    }

    /// <summary>
    /// Delete genre by id
    /// </summary>
    /// <param name="id">Genre Id</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var genre = await context.Genres.FirstOrDefaultAsync(genre => genre.Id == id);
        if (genre != null)
        {
            context.Genres.Remove(genre);
            _logger.LogInformation($"DELETE: Delete genre with id = {id}");
            await context.SaveChangesAsync();
            return Ok();
        }
        return NotFound();
    }
}
