using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for passenger table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController : ControllerBase
{
    private readonly ILogger<PassengerController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IDbContextFactory<AirlinesContext> _contextFactory;
    private readonly IMapper _mapper;

    public PassengerController(IDbContextFactory<AirlinesContext> contextFactory, ILogger<PassengerController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method for passenger table
    /// </summary>
    /// <returns>
    /// Return all passengers
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<PassengerGetDto>> Get()
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get passengers");
        return _mapper.Map<IEnumerable<PassengerGetDto>>(await ctx.Passengers.ToListAsync());
    }

    /// <summary>
    /// Get by id method for passenger table
    /// </summary>
    /// <returns>
    /// Return passenger with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PassengerGetDto>> Get(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get passenger with id ({id})");
        var passenger = ctx.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<PassengerGetDto>(passenger));
        }
    }


    /// <summary>
    /// Post method for passenger table
    /// </summary>
    /// <param name="passenger"> Passenger class instance to insert to table</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PassengerPostDto passenger)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post");
        await ctx.Passengers.AddAsync(_mapper.Map<Passenger>(passenger));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put method for passenger table
    /// </summary>
    /// <param name="id">An id of passenger which would be changed </param>
    /// <param name="passengerToPut">Passenger class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] PassengerPostDto passengerToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put passenger with id {0}", id);
        var passenger = ctx.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id {0}", id);
            return NotFound();
        }
        else
        {
            ctx.Update(_mapper.Map(passengerToPut, passenger));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of passenger which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put passenger with id ({id})");
        var passenger = ctx.Passengers.FirstOrDefault(passenger => passenger.Id == id);
        if (passenger == null)
        {
            _logger.LogInformation($"Not found passenger with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Passengers.Remove(passenger);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}