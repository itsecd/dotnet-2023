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
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly IMediaRepository _repository;

    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    public AlbumController(IMediaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get list of album 
    /// </summary>
    /// <returns>List of album</returns>
    [HttpGet]
    public IEnumerable<AlbumGetDto> Get()
    {
        return _repository.Albums.Select(album => _mapper.Map<Album, AlbumGetDto>(album));
    }

    /// <summary>
    /// Get album by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Album</returns>
    [HttpGet("{id}")]
    public ActionResult<AlbumGetDto> Get(int id)
    {
        var album = _repository.Albums.FirstOrDefault(album => album.Id == id);
        if (album == null) { return NotFound(); }
        else return Ok(_mapper.Map<Album, AlbumGetDto>(album));
    }

    /// <summary>
    /// Post new album
    /// </summary>
    /// <param name="album"></param>
    [HttpPost]
    public void Post([FromBody] AlbumPostDto album)
    {
        _repository.Albums.Add(_mapper.Map<AlbumPostDto, Album>(album));
    }

    /// <summary>
    /// Put album
    /// </summary>
    /// <param name="id"></param>
    /// <param name="putAlbum"></param>
    /// <returns>Id of puttable album</returns>
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
            album.Year = putAlbum.Year;
            return Ok(new { album.Id });
        }
    }

    /// <summary>
    /// Delete album by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var album = _repository.Albums.FirstOrDefault(album => album.Id == id);
        if (album != null) _repository.Albums.Remove(album);
    }
}
