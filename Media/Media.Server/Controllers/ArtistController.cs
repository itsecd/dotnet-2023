using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArtistController : ControllerBase
{
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IMediaRepository _repository;

    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    public ArtistController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get list of artist 
    /// </summary>
    /// <returns>List of artist</returns>
    [HttpGet]
    public IEnumerable<ArtistGetDto> Get()
    {
        return _repository.Artists.Select(artist => _mapper.Map<Artist, ArtistGetDto>(artist));
    }

    /// <summary>
    /// Get artist by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Artist</returns>
    [HttpGet("{id}")]
    public ActionResult<ArtistGetDto> Get(int id)
    {
        var artist = _repository.Artists.FirstOrDefault(artist => artist.Id == id);
        if (artist == null) { return NotFound(); }
        else return Ok(_mapper.Map<Artist, ArtistGetDto>(artist));
    }

    /// <summary>
    /// Post new artist
    /// </summary>
    /// <param name="artist"></param>
    [HttpPost]
    public void Post([FromBody] ArtistPostDto artist)
    {
        _repository.Artists.Add(_mapper.Map<ArtistPostDto, Artist>(artist));
    }

    /// <summary>
    /// Put artist
    /// </summary>
    /// <param name="id"></param>
    /// <param name="putArtist"></param>
    /// <returns>Id of puttable artist</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ArtistPostDto putArtist)
    {
        var artist = _repository.Artists.FirstOrDefault(artist => artist.Id == id);
        if (artist == null) return NotFound();
        else
        {
            artist.Name = putArtist.Name;
            artist.Description = putArtist.Description;
            return Ok(new { artist.Id });
        }
    }

    /// <summary>
    /// Delete artist by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var artist = _repository.Artists.FirstOrDefault(artist => artist.Id == id);
        if (artist != null) _repository.Artists.Remove(artist);
    }
}
