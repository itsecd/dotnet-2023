using Airlines.Domain;
using Airlines.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for flight table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly ILogger<FlightController> _logger;
    private readonly IDbContextFactory<AirlinesContext> _contextFactory;
    private readonly IMapper _mapper;

    public FlightController(IDbContextFactory<AirlinesContext> contextFactory, ILogger<FlightController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
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
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flights");
        return _mapper.Map<IEnumerable<FlightGetDto>>(await ctx.Flights.ToListAsync());
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
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get flight with id ({id})", id);
        var flight = ctx.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id ({id})", id);
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
    public async Task<IActionResult> Post([FromBody] FlightPostDto flight)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post flight");
        var airplane = ctx.Airplanes.FirstOrDefault(airplane => airplane.Id == flight.AirplaneId);
        if (airplane == null)
        {
            return StatusCode(422, $"Not found airplane id: {flight.AirplaneId}");
        }
        await ctx.Flights.AddAsync(_mapper.Map<Flight>(flight));
        await ctx.SaveChangesAsync();
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
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put flight with id {id}", id);
        var airplane = ctx.Airplanes.FirstOrDefault(airplane => airplane.Id == flightToPut.AirplaneId);
        if (airplane == null)
        {
            return StatusCode(422, $"Not found airplane id: {flightToPut.AirplaneId}");
        }
        var flight = ctx.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id {id}", id);
            return NotFound();
        }
        else
        {
            ctx.Update(_mapper.Map(flightToPut, flight));
            await ctx.SaveChangesAsync();
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
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put flight with id ({id})", id);
        var flight = ctx.Flights.FirstOrDefault(flight => flight.Id == id);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight with id ({id})", id);
            return NotFound();
        }
        else
        {
            ctx.Flights.Remove(flight);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}