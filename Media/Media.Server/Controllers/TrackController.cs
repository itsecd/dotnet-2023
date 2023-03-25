using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

/// <summary>
/// Track controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TrackController : ControllerBase
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
    private readonly ILogger<TrackController> _logger;

    public TrackController(IMediaRepository repository, IMapper mapper, ILogger<TrackController> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get list of track 
    /// </summary>
    /// <returns>List of track</returns>
    [HttpGet]
    public IEnumerable<Track> Get()
    {
        _logger.LogInformation("GET: Get list of track");
        return _repository.Tracks;
    }

    /// <summary>
    /// Get track by id
    /// </summary>
    /// <param name="id">Track Id</param>
    /// <returns>Track</returns>
    [HttpGet("{id}")]
    public ActionResult<Track> Get(int id)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
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
        _logger.LogInformation("Post new track");
        _repository.Tracks.Add(_mapper.Map<TrackPostDto, Track>(track));
    }

    /// <summary>
    /// Put track
    /// </summary>
    /// <param name="id">Track Id</param>
    /// <param name="putTrack">Track fo putting</param>
    /// <returns>Id of puttable track</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TrackPostDto putTrack)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
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
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
        if (track != null)
        {
            if (_repository.Tracks.Remove(track)) _logger.LogInformation($"DELETE: Delete track with id = {id}");
        }
    }
}
