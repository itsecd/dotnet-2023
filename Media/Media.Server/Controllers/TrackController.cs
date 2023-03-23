using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

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

    public TrackController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get list of track 
    /// </summary>
    /// <returns>List of track</returns>
    [HttpGet]
    public IEnumerable<Track> Get()
    {
        return _repository.Tracks;
    }

    /// <summary>
    /// Get track by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Track</returns>
    [HttpGet("{id}")]
    public ActionResult<Track> Get(int id)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
        if (track == null) { return NotFound(); }
        else return Ok(track);
    }

    /// <summary>
    /// Post new track
    /// </summary>
    /// <param name="track"></param>
    [HttpPost]
    public void Post([FromBody] TrackPostDto track)
    {
        _repository.Tracks.Add(_mapper.Map<TrackPostDto, Track>(track));
    }

    /// <summary>
    /// Put tarck
    /// </summary>
    /// <param name="id"></param>
    /// <param name="putTrack"></param>
    /// <returns>Id of puttable track</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TrackPostDto putTrack)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
        if (track == null) return NotFound();
        else
        {
            track.Name = putTrack.Name;
            track.Number = putTrack.Number;
            track.AlbumId = putTrack.AlbumId;
            track.Duration = putTrack.Duration;
            return Ok(new { track.Id });
        }
    }

    /// <summary>
    /// Delete track by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
        if (track != null) _repository.Tracks.Remove(track);
    }
}
