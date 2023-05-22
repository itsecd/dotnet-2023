using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for passenger table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PassengerController : ControllerBase
{
    private readonly IDbContextFactory<TaxiDbContext> _contextFactory;
    private readonly ILogger<PassengerController> _logger;
    private readonly IMapper _mapper;

    public PassengerController(IDbContextFactory<TaxiDbContext> contextFactory, IMapper mapper,
        ILogger<PassengerController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Get method which returns all passengers
    /// </summary>
    /// <returns>
    ///     List of passenger
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<PassengerGetDto>> Get()
    {
        _logger.LogInformation("Get passenger");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await _mapper.ProjectTo<PassengerGetDto>(ctx.Passengers).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns passenger by id
    /// </summary>
    /// <param name="id"> Identifier of passenger</param>
    /// <returns>
    ///     Passenger with the required id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PassengerGetDto>> Get(ulong id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var passenger = await ctx.Passengers.FindAsync(id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get passenger with id={id}", id);
        return Ok(_mapper.Map<PassengerGetDto>(passenger));
    }

    /// <summary>
    ///     Post method which add new passenger in passenger table
    /// </summary>
    /// <param name="passengerToPost"> New passenger for addition</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<PassengerGetDto>> Post(PassengerSetDto passengerToPost)
    {
        _logger.LogInformation("Post passenger");
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var mappedPassenger = _mapper.Map<Passenger>(passengerToPost);

        await ctx.Passengers.AddAsync(mappedPassenger);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = mappedPassenger.Id },
            _mapper.Map<PassengerGetDto>(mappedPassenger));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired passenger by id
    /// </summary>
    /// <param name="id"> Identifier of passenger</param>
    /// <param name="passengerToPut"> New passenger data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, PassengerSetDto passengerToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var passenger = await ctx.Passengers.FindAsync(id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put passenger with id={id}", id);
        _mapper.Map(passengerToPut, passenger);
        await ctx.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    ///     Delete - method for deleting a passenger by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of passenger </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var passenger = await ctx.Passengers.FindAsync(id);
        if (passenger == null)
        {
            _logger.LogInformation("Not found passenger with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete passenger with id={id}", id);
        ctx.Passengers.Remove(passenger);
        await ctx.SaveChangesAsync();
        return NoContent();
    }
}