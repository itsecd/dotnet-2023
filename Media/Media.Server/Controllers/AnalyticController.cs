using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Media.Server.Controllers;

/// <summary>
/// Analytic controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticController : ControllerBase
{
    /// <summary>
    /// Used to store map-object
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<AnalyticController> _logger;

    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<MediaContext> _contextFactory;

    public AnalyticController(IMapper mapper, ILogger<AnalyticController> logger, IDbContextFactory<MediaContext> contextFactory)
    {
        _mapper = mapper;
        _logger = logger;
        _contextFactory = contextFactory;
    }

    /// <summary>
    /// Get artist information
    /// </summary>
    /// <returns>Artist information</returns>
    [HttpGet("artist-information")]
    public async Task<IEnumerable<ArtistGetDto>> GetArtistInfo()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get artist information");
        return await (from artist in context.Artists
                select _mapper.Map<Artist, ArtistGetDto>(artist)).ToListAsync();
    }

    /// <summary>
    /// Get album information by year
    /// </summary>
    /// <param name="albumName">Album name</param>
    /// <returns>Album information by year</returns>
    [HttpGet("tracks-in-album/{albumName}")]
    public async Task<IActionResult> GetTracksInfo(string albumName)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var resultList = await (from album in context.Albums.Include(album => album.Tracks)
                          where album.Name == albumName
                          from track in album.Tracks
                          orderby track.Number
                          select track).ToListAsync();
        if (resultList.Count == 0)
        {
            _logger.LogInformation($"Get album information by name: There are no albums named {albumName}");
            return NotFound();
        }
        _logger.LogInformation($"Get album information by name: {albumName}");
        return Ok(resultList);
    }

    /// <summary>
    /// Get album information
    /// </summary>
    /// <param name="year">Year</param>
    /// <returns>Album information</returns>
    [HttpGet("albums-by-year/{year:int}")]
    public async Task<IActionResult> GetAlbumsInfo(int year)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var resultList = await (from album in context.Albums.Include(album => album.Tracks)
                          where album.Year == year
                          select new Tuple<AlbumGetDto, int>(_mapper.Map<Album, AlbumGetDto>(album), album.Tracks.Count)).ToListAsync();
        if (resultList.Count == 0)
        {
            _logger.LogInformation($"Get album information by year: There are no album released in {year}");
            return NotFound();
        }
        _logger.LogInformation($"Get album information by year:{year}");
        return Ok(resultList);
    }

    /// <summary>
    /// Get top-5 longest albums
    /// </summary>
    /// <returns>Top-5 albums</returns>
    [HttpGet("top-5-albums")]
    public async Task<IEnumerable<AlbumGetDto>> GetTopAlbums()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get top-5 longest album");
        return await (from album in context.Albums.Include(album => album.Tracks)
                orderby album.Tracks.Sum(track => track.Duration) descending
                select _mapper.Map<Album, AlbumGetDto>(album)).Take(5).ToListAsync();
    }

    /// <summary>
    /// Get the artists with the most albums
    /// <returns>Artist with the most albums</returns>
    [HttpGet("max-album-artists")]
    public async Task<IEnumerable<ArtistGetDto>> GetMaxAlbumArtistTest()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get the artists with the most albums");
        var maxCount = await context.Artists.MaxAsync(artist => artist.Albums.Count);
        return await (from artist in context.Artists.Include(artist => artist.Albums)
                where artist.Albums.Count == maxCount
                select _mapper.Map<Artist, ArtistGetDto>(artist)).ToListAsync();
    }

    /// <summary>
    /// Get information about the minimum, maximum and average duration of albums
    /// </summary>
    /// <returns>Information of album duration</returns>
    [HttpGet("information-of-duration")]
    public async Task<IEnumerable<double>> GetAlbumDurationsInfo()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var durationAlbumList = (from album in context.Albums.Include(album => album.Tracks)
                                 select new { Album = album, Duration = album.Tracks.Sum(track => track.Duration) });
        var min = await durationAlbumList.MinAsync(album => album.Duration);
        var max = await durationAlbumList.MaxAsync(album => album.Duration);
        var avg = await durationAlbumList.AverageAsync(album => album.Duration);
        _logger.LogInformation("Get information about the minimum, maximum and average duration of albums");
        return new List<double> { min, avg, max };
    }
}
