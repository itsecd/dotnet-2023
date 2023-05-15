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
    public async Task<IEnumerable<AlbumGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of album");
        return _mapper.Map<IEnumerable<AlbumGetDto>>(context.Albums);
    }

    /// <summary>
    /// Get album by id
    /// </summary>
    /// <param name="id">Album Id</param>
    /// <returns>Album</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<AlbumGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var album = await context.Albums.FirstOrDefaultAsync(album => album.Id == id);
        if (album == null)
        {
            _logger.LogInformation("GET(id): Album with id = {id} not found", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("GET(id): Get album with id = {id}", id);
            return Ok(_mapper.Map<Album, AlbumGetDto>(album));
        }
    }

    /// <summary>
    /// Post new album
    /// </summary>
    /// <param name="album">Album name</param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AlbumPostDto album)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var albumGenre = await context.Genres.FirstOrDefaultAsync(genre => genre.Id == album.GenreId);
        if (albumGenre == null)
            return StatusCode(422, $"Not found genre with Id = {album.GenreId}");
        var albumArtist = await context.Artists.FirstOrDefaultAsync(artist => artist.Id == album.ArtistId);
        if (albumArtist == null)
            return StatusCode(422, $"Not found artist with Id = {album.ArtistId}");
        await context.Albums.AddAsync(_mapper.Map<AlbumPostDto, Album>(album));
        await context.SaveChangesAsync();
        _logger.LogInformation("Post new album");
        return Ok();
    }

    /// <summary>
    /// Put album
    /// </summary>
    /// <param name="id">Album Id</param>
    /// <param name="putAlbum">Album for putting</param>
    /// <returns>Id of put-album</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AlbumPostDto putAlbum)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var album = await context.Albums.FirstOrDefaultAsync(album => album.Id == id);
        if (album == null)
        {
            _logger.LogInformation("PUT: Album with id = {id} not found", id);
            return NotFound();
        }
        else
        {
            var albumGenre = await context.Genres.FirstOrDefaultAsync(genre => genre.Id == album.GenreId);
            if (albumGenre == null)
                return StatusCode(422, $"Not found genre with Id = {album.GenreId}");
            var albumArtist = await context.Artists.FirstOrDefaultAsync(artist => artist.Id == album.ArtistId);
            if (albumArtist == null)
                return StatusCode(422, $"Not found artist with Id = {album.GenreId}");
            album.Name = putAlbum.Name;
            album.ArtistId = putAlbum.ArtistId;
            album.GenreId = putAlbum.GenreId;
            album.Year = putAlbum.Year;
            _logger.LogInformation("PUT: Put album with id = {id}", id);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete album by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var album = await context.Albums.FirstOrDefaultAsync(album => album.Id == id);
        if (album != null)
        {
            context.Albums.Remove(album);
            await context.SaveChangesAsync();
            _logger.LogInformation("DELETE: Delete album with id = {id}", id);
            return Ok();
        }
        return NotFound();
    }
}
