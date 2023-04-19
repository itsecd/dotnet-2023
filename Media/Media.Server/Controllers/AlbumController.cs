using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media.Server.Controllers;

/// <summary>
/// Album controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<AlbumController> _logger;

    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<MediaContext> _contextFactory;

    public AlbumController(IMapper mapper, ILogger<AlbumController> logger, IDbContextFactory<MediaContext> contextFactory)
    {
        _mapper = mapper;
        _logger = logger;
        _contextFactory = contextFactory;
    }

    /// <summary>
    /// Get list of album 
    /// </summary>
    /// <returns>List of album</returns>
    [HttpGet]
    public IEnumerable<AlbumGetDto> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("GET: Get list of album");
        return _mapper.Map<IEnumerable<AlbumGetDto>>(context.Albums);
    }

    /// <summary>
    /// Get album by id
    /// </summary>
    /// <param name="id">Album Id</param>
    /// <returns>Album</returns>
    [HttpGet("{id}")]
    public ActionResult<AlbumGetDto> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var album = context.Albums.FirstOrDefault(album => album.Id == id);
        if (album == null)
        {
            _logger.LogInformation($"GET(id): Album with id = {id} not found");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"GET(id): Get album with id = {id}");
            return Ok(_mapper.Map<Album, AlbumGetDto>(album));
        }
    }

    /// <summary>
    /// Post new album
    /// </summary>
    /// <param name="album">Album name</param>
    [HttpPost]
    public void Post([FromBody] AlbumPostDto album)
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post new album");
        context.Albums.Add(_mapper.Map<AlbumPostDto, Album>(album) );
        context.SaveChanges();
    }

    /// <summary>
    /// Put album
    /// </summary>
    /// <param name="id">Album Id</param>
    /// <param name="putAlbum">Album for putting</param>
    /// <returns>Id of put-album</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] AlbumPostDto putAlbum)
    {
        using var context = _contextFactory.CreateDbContext();
        var album = context.Albums.FirstOrDefault(album => album.Id == id);
        if (album == null)
        {
            _logger.LogInformation($"PUT: Album with id = {id} not found");
            return NotFound();
        }
        else
        {
            album.Name = putAlbum.Name;
            album.ArtistId = putAlbum.ArtistId;
            album.GenreId = putAlbum.GenreId;
            album.Year = putAlbum.Year;
            _logger.LogInformation($"PUT: Put album with id = {id}");
            context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var album = context.Albums.FirstOrDefault(album => album.Id == id);
        if (album != null)
        {
            context.Albums.Remove(album);
            context.SaveChanges();
            _logger.LogInformation($"DELETE: Delete album with id = {id}");
        }
    }
}
