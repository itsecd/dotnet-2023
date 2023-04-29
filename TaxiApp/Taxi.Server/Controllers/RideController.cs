using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for ride table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RideController : ControllerBase
{
    private readonly IDbContextFactory<TaxiDbContext> _contextFactory;
    private readonly ILogger<RideController> _logger;
    private readonly IMapper _mapper;

    public RideController(IDbContextFactory<TaxiDbContext> contextFactory, IMapper mapper,
        ILogger<RideController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Get method which returns all rides
    /// </summary>
    /// <returns>
    ///     List of ride
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<RideGetDto>> Get()
    {
        _logger.LogInformation("Get rides");
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        return await _mapper.ProjectTo<RideGetDto>(ctx.Rides).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns ride by id
    /// </summary>
    /// <param name="id"> Identifier of ride</param>
    /// <returns>
    ///     Ride with the required id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<RideGetDto>> Get(ulong id)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        Ride? ride = await ctx.Rides.FindAsync(id);
        if (ride == null)
        {
            _logger.LogInformation("Not found ride with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get ride with id={id}", id);
        return Ok(_mapper.Map<RideGetDto>(ride));
    }

    /// <summary>
    ///     Post method which add new ride in ride table
    /// </summary>
    /// <param name="rideToPost"> New ride for addition</param>
    /// >
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<Ride>> Post(RideSetDto rideToPost)
    {
        _logger.LogInformation("Post ride");
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        Ride? mappedRide = _mapper.Map<Ride>(rideToPost);

        await ctx.Rides.AddAsync(mappedRide);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = mappedRide.Id },
            _mapper.Map<RideGetDto>(mappedRide));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired ride by id
    /// </summary>
    /// <param name="id"> Identifier of ride</param>
    /// <param name="rideToPut"> New ride data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, RideSetDto rideToPut)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        Ride? ride = await ctx.Rides.FindAsync(id);
        if (ride == null)
        {
            _logger.LogInformation("Not found ride with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put ride with id={id}", id);
        _mapper.Map(rideToPut, ride);
        await ctx.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    ///     Delete - method for deleting a ride by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of ride </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        Ride? ride = await ctx.Rides.FindAsync(id);
        if (ride == null)
        {
            _logger.LogInformation("Not found ride with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete ride with id={id}", id);
        ctx.Rides.Remove(ride);
        await ctx.SaveChangesAsync();
        return NoContent();
    }
}