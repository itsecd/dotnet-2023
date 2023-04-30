using AirplaneBookingSystem.Model;
using AirplaneBookingSystem.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirplaneBookingSystem.Server.Controllers;
/// <summary>
/// Flights
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly IDbContextFactory<AirplaneBookingSystemDbContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<AirplaneController> _logger;

    public FlightController(ILogger<AirplaneController> logger, IDbContextFactory<AirplaneBookingSystemDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for flight table
    /// </summary>
    /// <returns>
    /// Return all flights
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<FlightGetDto>> GetFlights()
    {
        _logger.LogInformation("Get all flights");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var flights = await ctx.Flights.ToArrayAsync();
        return _mapper.Map<IEnumerable<FlightGetDto>>(flights);
    }
    /// <summary>
    /// Get by id method for flight table
    /// </summary>
    /// <param name="idFlight">id flight</param>
    /// <returns>Ok with FlightGetDto or NotFound</returns>
    [HttpGet("{idFlight}")]
    public async Task<ActionResult<FlightGetDto>> GetFlight(int idFlight)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var flight = await ctx.Flights.FirstOrDefaultAsync(flight => flight.Id == idFlight);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight : {idFlight}", idFlight);
            return NotFound($"The flight does't exist by this id {idFlight}");
        }
        else
        {
            _logger.LogInformation("Get flight by {idFlight}", idFlight);
            return Ok(_mapper.Map<FlightGetDto>(flight));
        }
    }
    /// <summary>
    /// Put method for flight table
    /// </summary>
    /// <param name="idFlight">An id of flight which would be changed </param>
    /// <param name="flightToPut">Flight class instance to insert to table</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idFlight}")]
    public async Task<IActionResult> PutFlight(int idFlight, [FromBody] FlightPostDto flightToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var flight = await ctx.Flights.FirstOrDefaultAsync(flight => flight.Id == idFlight);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight : {idFlight}", idFlight);
            return NotFound($"The flight does't exist by this id {idFlight}");
        }
        else
        {
            _logger.LogInformation("Update flight by id {idFlight}", idFlight);
            _mapper.Map(flightToPut, flight);
            ctx.Flights.Update(_mapper.Map<Flight>(flight));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Post method for flight table
    /// </summary>
    /// <param name="flight"> Flight class instance to insert to table</param>
    /// <returns>Сreated Flight</returns>
    [HttpPost]
    public async Task PostFlight([FromBody] FlightPostDto flight)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new flight");
        await ctx.Flights.AddAsync(_mapper.Map<Flight>(flight));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="idFlight">An id of flight which would be deleted</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idFlight}")]
    public async Task<IActionResult> DeleteFlight(int idFlight)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var flight = await ctx.Flights.Include(flight => flight.Airplane)
                                        .Include(flights => flights.Tickets)
                                        .FirstOrDefaultAsync(flights => flights.Id == idFlight);
        if (flight == null)
        {
            _logger.LogInformation("Not found flight : {idFlight}", idFlight);
            return NotFound($"The flight does't exist by this id {idFlight}");
        }
        else
        {
            _logger.LogInformation("Delete flight by id {idFlight}", idFlight);
            ctx.Flights.Remove(flight);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}