using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Media.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrackController : ControllerBase
{
    private readonly IMediaRepository _repository;

    private readonly IMapper _mapper;
    public TrackController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    [HttpGet]
    public IEnumerable<Track> Get()
    {
        return _repository.Tracks;
    }

    [HttpGet("{id}")]
    public ActionResult<Track> Get(int id)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
        if (track == null) { return NotFound(); }
        else return Ok(track);
    }

    [HttpPost]
    public void Post([FromBody] TrackPostDto track)
    {
        _repository.Tracks.Add(_mapper.Map<TrackPostDto, Track>(track));
    }

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

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var track = _repository.Tracks.FirstOrDefault(track => track.Id == id);
        if (track != null) _repository.Tracks.Remove(track);
    }
}
