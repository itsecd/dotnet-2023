using AutoMapper;
using Media.Domain;
using Media.Server.Dto;
using Media.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Media.Server.Controllers;

/// <summary>
/// Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
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
    private readonly ILogger<AnalyticsController> _logger;

    public AnalyticsController(IMediaRepository repository, IMapper mapper, ILogger<AnalyticsController> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Get artist information
    /// </summary>
    /// <returns>Artist information</returns>
    [HttpGet("artist-information")]
    public IEnumerable<ArtistGetDto> GetArtistInfo()
    {
        _logger.LogInformation("Get artist information");
        return (from artist in _repository.Artists
                select _mapper.Map<Artist, ArtistGetDto>(artist)).ToList();
    }

    /// <summary>
    /// Get album information by year
    /// </summary>
    /// <param name="albumName"> Album name</param>
    /// <returns>Album information by year</returns>
    [HttpGet("tracks-in-album/{albumName}")]
    public IActionResult GetTracksInfo(string albumName)
    {
        var resultList = (from album in _repository.Albums
                          where album.Name == albumName
                          from track in album.Tracks
                          orderby track.Number
                          select track).ToList();
        if (resultList.Count == 0)
        {
            _logger.LogInformation($"Get album information by name: There are no albums named {albumName}");
            return NotFound();
        }
        _logger.LogInformation($"Get album informaion by name: {albumName}");
        return Ok(resultList);
    }

    /// <summary>
    /// Get album information
    /// </summary>
    /// <param name="year"> Year </param>
    /// <returns>Album information</returns>
    [HttpGet("albums-by-year/{year:int}")]
    public IActionResult GetAlbumsInfo(int year)
    {
        var resultList = (from album in _repository.Albums
                          where album.Year == year
                          select new Tuple<AlbumGetDto, int>(_mapper.Map<Album, AlbumGetDto>(album), album.Tracks.Count)).ToList();
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
    public IEnumerable<AlbumGetDto> GetTopAlbums()
    {
        _logger.LogInformation($"Get top-5 longest album");
        return (from album in _repository.Albums
                orderby album.Tracks.Sum(track => track.Duration) descending
                select _mapper.Map<Album, AlbumGetDto>(album)).Take(5).ToList();
    }

    /// <summary>
    /// Get the artists with the most albums
    /// <returns>Artist with the most albums</returns>
    [HttpGet("max-album-artists")]
    public IEnumerable<ArtistGetDto> GetMaxAlbumArtistTest()
    {
        _logger.LogInformation($"Get the artists with the most albums");
        return (from artist in _repository.Artists
                where artist.Albums.Count == _repository.Artists.Max(artist => artist.Albums.Count)
                select _mapper.Map<Artist, ArtistGetDto>(artist)).ToList();
    }

    /// <summary>
    /// Get information about the minimum, maximum and average duration of albums
    /// </summary>
    /// <returns>Information of album duration</returns>
    [HttpGet("information-of-duration")]
    public IEnumerable<double> GetAlbumDurationsInfo()
    {
        var durationAlbumList = (from album in _repository.Albums
                                 select new { Album = album, Duration = album.Tracks.Sum(track => track.Duration) });
        var min = durationAlbumList.Min(album => album.Duration);
        var max = durationAlbumList.Max(album => album.Duration);
        var avg = durationAlbumList.Average(album => album.Duration);
        _logger.LogInformation("Get information about the minimum, maximum and average duration of albums");
        return new List<double> { min, avg, max };
    }
}
