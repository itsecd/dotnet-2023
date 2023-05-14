using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for transport types
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransportTypeController : ControllerBase
{
    /// <summary>
    /// Used to store factory contex
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TransportTypeController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TransportTypeController(IDbContextFactory<TransportMgmtContext> contextFactory, ILogger<TransportTypeController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all transport types
    /// </summary>
    /// <returns> Returns a list of all transport types </returns>
    [HttpGet]
    public async Task<IEnumerable<TransportTypesGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get transport types");
        return _mapper.Map<IEnumerable<TransportTypesGetDto>>(context.TransportTypes);
    }
    /// <summary>
    /// Get method that returns transport types with a specific id
    /// </summary>
    /// <param name="id"> Transport type id </param>
    /// <returns> Transport type with required id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TransportTypesGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get transport type with id= {id}", id);
        var transportType = await context.TransportTypes.FirstOrDefaultAsync(transport => transport.Id == id);
        if (transportType == null)
        {
            _logger.LogInformation("Not found transport type with id= {id}", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<TransportTypesGetDto>(transportType));
    }
}