using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportMgmt.Domain;
using TransportMgmtServer.Dto;

namespace TransportMgmtServer.Controllers;

/// <summary>
/// Controller for transport
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TransportController : ControllerBase
{
    /// <summary>
    /// Used to store factory contex
    /// </summary>
    private readonly IDbContextFactory<TransportMgmtContext> _contextFactory;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TransportController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Controller constructor
    /// </summary>
    public TransportController(ILogger<TransportController> logger, IDbContextFactory<TransportMgmtContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all transports
    /// </summary>
    /// <returns> Returns a list of all transports </returns>
    [HttpGet]
    public async Task<IEnumerable<TransportGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get transports");
        return _mapper.Map<IEnumerable<TransportGetDto>>(context.Transports);
    }
    /// <summary>
    /// Get method that returns transport with a specific id
    /// </summary>
    /// <param name="id"> Transports id </param>
    /// <returns> Transports with required id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TransportGetDto>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get transport with id= {id}", id);
        var transport = await context.Transports.FirstOrDefaultAsync(transport => transport.Id == id);
        if (transport == null)
        {
            _logger.LogInformation("Not found transport with id= {id} ", id);
            return NotFound();
        }
        else return Ok(_mapper.Map<TransportGetDto>(transport));
    }
    /// <summary>
    /// Post method that adding a new transport
    /// </summary>
    /// <param name="transport"> Added transport </param>
    [HttpPost]
    public async Task Post([FromBody] TransportPostDto transport)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Transports.AddAsync(_mapper.Map<Transport>(transport));
        _logger.LogInformation("Successfully added");
        await context.SaveChangesAsync();
    }
    /// <summary>
    /// Put method which allows change the data of transport with a specific id
    /// </summary>
    /// <param name="id"> Transport id whose data will change </param>
    /// <param name="transportToPut"> New transport data </param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TransportPostDto transportToPut)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var transport = await context.Transports.FirstOrDefaultAsync(transport => transport.Id == id);
        if (transport == null)
        {
            _logger.LogInformation("Not found transport with id= {id} ", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(transportToPut, transport);
            _logger.LogInformation("Successfully updates");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Delete method which allows delete a transport with a specific id
    /// </summary>
    /// <param name="id"> Transport id </param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var transport = await context.Transports.FirstOrDefaultAsync(transport => transport.Id == id);
        if (transport == null)
        {
            _logger.LogInformation("Not found transport with id= {id} ", id);
            return NotFound();
        }
        else
        {
            context.Transports.Remove(transport);
            _logger.LogInformation("Successfully removed");
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
