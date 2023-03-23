using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IMediaRepository _repository;

    private readonly IMapper _mapper;
    public AlbumController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<AlbumGetDto> Get()
    {
        return _repository.Albums.Select(album => _mapper.Map<Album, AlbumGetDto>(album));
    }

    [HttpGet("{id}")]
    public ActionResult<AlbumGetDto> Get(int id)
    {
        var album = _repository.Albums.FirstOrDefault(album => album.Id == id);
        if (album == null) { return NotFound(); }
        else return Ok(_mapper.Map<Album, AlbumGetDto>(album));
    }

    [HttpPost]
    public void Post([FromBody] AlbumPostDto album)
    {
        _repository.Albums.Add(_mapper.Map<AlbumPostDto, Album>(album));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AlbumPostDto putAlbum)
    {
        var album = _repository.Albums.FirstOrDefault(album => album.Id == id);
        if (album == null) return NotFound();
        else
        {
            album.Name = putAlbum.Name;
            album.ArtistId = putAlbum.ArtistId;
            album.GenreId = putAlbum.GenreId;
            album.Year= putAlbum.Year;
            return Ok(new { album.Id });
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var album = _repository.Albums.FirstOrDefault(album => album.Id == id);
        if (album != null) _repository.Albums.Remove(album);
    }
}
