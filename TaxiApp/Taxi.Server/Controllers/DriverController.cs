using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for driver table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly IDbContextFactory<TaxiDbContext> _contextFactory;
    private readonly ILogger<DriverController> _logger;
    private readonly IMapper _mapper;

    public DriverController(IDbContextFactory<TaxiDbContext> contextFactory, IMapper mapper,
        ILogger<DriverController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Get method which returns all drivers
    /// </summary>
    /// <returns>
    ///     List of drivers
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<Driver>> Get()
    {
        _logger.LogInformation("Get drivers");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.Drivers.ToListAsync();
    }

    /// <summary>
    ///     Get method which returns driver by id
    /// </summary>
    /// <param name="id"> Identifier of driver</param>
    /// <returns>
    ///     Driver with the required id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> Get(ulong id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var driver = await ctx.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get driver with id={id}", id);
        return Ok(driver);
    }

    /// <summary>
    ///     Post method which add new driver in driver table
    /// </summary>
    /// <param name="driverToPost"> New driver for addition</param>
    /// >
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<Driver>> Post(DriverSetDto driverToPost)
    {
        _logger.LogInformation("Post driver");
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var mappedDriver = _mapper.Map<Driver>(driverToPost);

        await ctx.Drivers.AddAsync(mappedDriver);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = mappedDriver.Id }, mappedDriver);
    }

    /// <summary>
    ///     Put method which allows change the data of the desired driver by id
    /// </summary>
    /// <param name="id"> Identifier of driver</param>
    /// <param name="driverToPut"> New driver data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, DriverSetDto driverToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var driver = await ctx.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put driver with id={id}", id);
        _mapper.Map(driverToPut, driver);
        await ctx.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    ///     Delete - method for deleting a driver by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of driver </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var driver = await ctx.Drivers.FindAsync(id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete driver with id={id}", id);
        ctx.Drivers.Remove(driver);
        await ctx.SaveChangesAsync();
        return NoContent();
    }
}