using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media.Server.Controllers;

/// <summary>
/// Artist Controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ArtistController : ControllerBase
{
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ArtistController> _logger;

    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<MediaContext> _contextFactory;

    public ArtistController(IMapper mapper, ILogger<ArtistController> logger, IDbContextFactory<MediaContext> contextFactory)
    {
        _mapper = mapper;
        _logger = logger;
        _contextFactory = contextFactory;
    }

    /// <summary>
    /// Get list of artist 
    /// </summary>
    /// <returns>List of artist</returns>
    [HttpGet]
    public async Task<IEnumerable<ArtistGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of artist");
        return _mapper.Map<IEnumerable<ArtistGetDto>>(context.Artists);
    }

    /// <summary>
    /// Get artist by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Artist</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ArtistGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var artist = await context.Artists.FirstOrDefaultAsync(artist => artist.Id == id);
        if (artist == null)
        {
            _logger.LogInformation($"GET(id): Artist with id = {id} not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET(id): Get artist with id = {id}");
            return Ok(_mapper.Map<Artist, ArtistGetDto>(artist));
        }
    }

    /// <summary>
    /// Post new artist
    /// </summary>
    /// <param name="artist"></param>
    [HttpPost]
    public async void Post([FromBody] ArtistPostDto artist)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Artists.AddAsync(_mapper.Map<ArtistPostDto, Artist>(artist));
        await context.SaveChangesAsync();
        _logger.LogInformation("POST: Post new artist");
    }

    /// <summary>
    /// Put artist
    /// </summary>
    /// <param name="id"></param>
    /// <param name="putArtist"></param>
    /// <returns>Id of put-artist</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] ArtistPostDto putArtist)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var artist = await context.Artists.FirstOrDefaultAsync(artist => artist.Id == id);
        if (artist == null)
        {
            _logger.LogInformation($"PUT: Artist with id = {id} not found");
            return NotFound();
        }
        else
        {
            artist.Name = putArtist.Name;
            artist.Description = putArtist.Description;
            _logger.LogInformation("PUT: Put artist with id = {id}", id);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete artist by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var artist = await context.Artists.FirstOrDefaultAsync(artist => artist.Id == id);
        if (artist != null)
        {
            context.Artists.Remove(artist); 
            _logger.LogInformation($"DELETE: Delete artist with id = {id}");
            await context.SaveChangesAsync();
            return Ok();
        }
        return NotFound();
    }
}
