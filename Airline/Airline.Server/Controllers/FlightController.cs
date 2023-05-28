using Airline.Server.Dto;
using AirLine.Model;
using AirlineModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Server.Controllers;

/// <summary>
/// Flight table controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly IDbContextFactory<AirlineContext> _contextFactory;
    private readonly ILogger<FlightController> _logger;
    private readonly IMapper _mapper;

    public FlightController(IDbContextFactory<AirlineContext> contextFactory, ILogger<FlightController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get table flight
    /// </summary>
    /// <returns>
    /// Return all flights
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<FlightGetDto>> Get()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var flights = await context.Flights.ToArrayAsync();
        _logger.LogInformation($"Get flights\n{flights}");
        return _mapper.Map<IEnumerable<FlightGetDto>>(flights);
    }

    /// <summary>
    /// Get flight by id
    /// </summary>
    /// <returns>
    /// Return flight with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FlightGetDto>> Get(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get flight: id ({id})");
        var flight = await context.FindAsync<Flight>(id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight: id ({id})");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get flight with id {id}");
            return Ok(_mapper.Map<FlightGetDto>(flight));
        }
    }

    /// <summary>
    /// Post flight
    /// </summary>
    /// <param name="flight"> Flight class for insert in table</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FlightPostDto flight)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post flight");
        await context.Flights.AddAsync(_mapper.Map<Flight>(flight));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put flight
    /// </summary>
    /// <param name="id">Flight id for be changed</param>
    /// <param name="flightToPut">Flight class for insert in table</param>
    /// <returns>Triggered of success and error</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] FlightPostDto flightToPut)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put flight: id {0}", id);
        var flight = await context.FindAsync<Flight>(id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight: id {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put flight with id {id}");
            _mapper.Map(flightToPut, flight);
            await context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete flight 
    /// </summary>
    /// <param name="id">Flight id for deleting</param>
    /// <returns>Triggered of success and error</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put flight: id ({id})");
        var flight = await context.FindAsync<Flight>(id);
        if (flight == null)
        {
            _logger.LogInformation($"Not found flight: id ({id})");
            return NotFound();
        }
        else
        {
            context.Flights.Remove(flight);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}