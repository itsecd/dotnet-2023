using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for routes
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RoutesController : Controller
{
    /// <summary>
    /// Used to store factory context
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<RoutesController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public RoutesController(ILogger<RoutesController> logger, IDbContextFactory<TransportMgmtContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all routes
    /// </summary>
    /// <returns> Returns a list of all routes </returns>
    [HttpGet]
    public async Task<IEnumerable<RoutesGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get routes");
        return _mapper.Map<IEnumerable<RoutesGetDto>>(context.Routes);
    }
    /// <summary>
    /// Get method that returns route with a specific id
    /// </summary>
    /// <param name="id"> Route id </param>
    /// <returns> Route with required id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RoutesGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get route with id= {id}", id);
        var route = await context.Routes.FirstOrDefaultAsync(route => route.Id == id);
        if (route == null)
        {
            _logger.LogInformation("Not found route with id= {id}", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<RoutesGetDto>(route));
    }
}
