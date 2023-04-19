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
    public IEnumerable<Track> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("GET: Get list of track");
        return context.Tracks.ToList();
    }

    /// <summary>
    /// Get track by id
    /// </summary>
    /// <param name="id">Track Id</param>
    /// <returns>Track</returns>
    [HttpGet("{id}")]
    public ActionResult<Track> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var track = context.Tracks.FirstOrDefault(track => track.Id == id);
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
    /// <param name="track">Track name</param>
    [HttpPost]
    public void Post([FromBody] TrackPostDto track)
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post new track");
        context.Tracks.Add(_mapper.Map<TrackPostDto, Track>(track));
        context.SaveChanges();
    }

    /// <summary>
    /// Put track
    /// </summary>
    /// <param name="id">Track Id</param>
    /// <param name="putTrack">Track fo putting</param>
    /// <returns>Id of put-track</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TrackPostDto putTrack)
    {
        using var context = _contextFactory.CreateDbContext();
        var track = context.Tracks.FirstOrDefault(track => track.Id == id);
        if (track == null)
        {
            _logger.LogInformation($"PUT: Track with id = {id} not found");
            return NotFound();
        }
        else
        {
            track.Name = putTrack.Name;
            track.Number = putTrack.Number;
            track.AlbumId = putTrack.AlbumId;
            track.Duration = putTrack.Duration;
            _logger.LogInformation($"PUT: Put track with id = {id}");
            context.SaveChanges();
            return Ok(new { track.Id });
        }
    }

    /// <summary>
    /// Delete track by id
    /// </summary>
    /// <param name="id">Track name</param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var track = context.Tracks.FirstOrDefault(track => track.Id == id);
        if (track != null)
        {
            context.Tracks.Remove(track);
            _logger.LogInformation($"DELETE: Delete track with id = {id}");
            context.SaveChanges();
        }
    }
}
