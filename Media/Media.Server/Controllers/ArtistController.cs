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
    private readonly IMediaRepository _repository;

    private readonly IMapper _mapper;
    public ArtistController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ArtistGetDto> Get()
    {
        return _repository.Artists.Select(artist => _mapper.Map<Artist, ArtistGetDto>(artist));
    }

    [HttpGet("{id}")]
    public ActionResult<ArtistGetDto> Get(int id)
    {
        var artist = _repository.Artists.FirstOrDefault(artist => artist.Id == id);
        if (artist == null) { return NotFound(); }
        else return Ok(_mapper.Map<Artist, ArtistGetDto>(artist));
    }

    [HttpPost]
    public void Post([FromBody] ArtistPostDto artist)
    {
        _repository.Artists.Add(_mapper.Map<ArtistPostDto, Artist>(artist));
    }

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

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var artist = _repository.Artists.FirstOrDefault(artist => artist.Id == id);
        if (artist != null) _repository.Artists.Remove(artist);
    }
}
