using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for flight table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly ILogger<FlightController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IDbContextFactory<AirlinesContext> _contextFactory;
    private readonly IMapper _mapper;

    public FlightController(IDbContextFactory<AirlinesContext> contextFactory,ILogger<FlightController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method for flight table
    /// </summary>
    /// <returns>
    /// Return all flights
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<FlightGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights");
        return _mapper.Map<IEnumerable<FlightGetDto>>(ctx.Flights);
    }

    /// <summary>
    /// Get by id method for flight table
    /// </summary>
    /// <returns>
    /// Return flight with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FlightGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get flight with id ({id})");
        var flight = ctx.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<FlightGetDto>(flight));
        }
    }

    /// <summary>
    /// Post method for flight table
    /// </summary>
    /// <param name="flight"> Flight class instance to insert to table</param>
    [HttpPost]
    public async Task<IActionResult> Task<Post>([FromBody] FlightPostDto flight)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post");
        ctx.Flights.Add(_mapper.Map<Flight>(flight));
        ctx.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Put method for flight table
    /// </summary>
    /// <param name="id">An id of flight which would be changed </param>
    /// <param name="flightToPut">Flight class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FlightPostDto flightToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put flight with id {0}", id);
        var flight = ctx.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(flightToPut, flight);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of flight which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put flight with id ({id})");
        var flight = ctx.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Flights.Remove(flight);
            ctx.SaveChanges();
            return Ok();
        }
    }
}