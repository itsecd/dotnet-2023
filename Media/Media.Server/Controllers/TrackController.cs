using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media.Server.Controllers;

/// <summary>
/// Track controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TrackController : ControllerBase
{
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TrackController> _logger;

    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<MediaContext> _contextFactory;

    public TrackController(IMapper mapper, ILogger<TrackController> logger, IDbContextFactory<MediaContext> contextFactory)
    {
        _mapper = mapper;
        _logger = logger;
        _contextFactory = contextFactory;
    }

    /// <summary>
    /// Get list of track 
    /// </summary>
    /// <returns>List of track</returns>
    [HttpGet]
    public async Task<IEnumerable<Track>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of track");
        return await context.Tracks.ToListAsync();
    }

    /// <summary>
    /// Get track by id
    /// </summary>
    /// <param name="id">Track Id</param>
    /// <returns>Track</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Track>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var track = await context.Tracks.FirstOrDefaultAsync(track => track.Id == id);
        if (track == null)
        {
            _logger.LogInformation($"GET(id): Track with id = {id} not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET(id): Get track with id = {id}");
            return Ok(track);
        }
    }

    /// <summary>
    /// Post new track
    /// </summary>
    /// <param name="postTrack">Track name</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TrackPostDto postTrack)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var trackAlbum = await context.Albums.FirstOrDefaultAsync(album => album.Id == postTrack.AlbumId);
        if(trackAlbum == null)
            return StatusCode(422, $"Not found album with Id = {postTrack.AlbumId}");
        _logger.LogInformation("Post new track");
        await context.Tracks.AddAsync(_mapper.Map<TrackPostDto, Track>(postTrack));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put track
    /// </summary>
    /// <param name="id">Track Id</param>
    /// <param name="putTrack">Track fo putting</param>
    /// <returns>Id of put-track</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TrackPostDto putTrack)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var track = await context.Tracks.FirstOrDefaultAsync(track => track.Id == id);
        if (track == null)
        {
            _logger.LogInformation($"PUT: Track with id = {id} not found");
            return NotFound();
        }
        else
        {
            var trackAlbum = await context.Albums.FirstOrDefaultAsync(album => album.Id == putTrack.AlbumId);
            if (trackAlbum == null)
                return StatusCode(422, $"Not found album with Id = {putTrack.AlbumId}");
            track.Name = putTrack.Name;
            track.Number = putTrack.Number;
            track.AlbumId = putTrack.AlbumId;
            track.Duration = putTrack.Duration;
            _logger.LogInformation($"PUT: Put track with id = {id}");
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete track by id
    /// </summary>
    /// <param name="id">Track name</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var track = await context.Tracks.FirstOrDefaultAsync(track => track.Id == id);
        if (track != null)
        {
            context.Tracks.Remove(track);
            _logger.LogInformation($"DELETE: Delete track with id = {id}");
            await context.SaveChangesAsync();
            return Ok();
        }
        return NotFound();
    }
}
