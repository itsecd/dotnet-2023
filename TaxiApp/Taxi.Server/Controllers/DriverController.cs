using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for driver table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    private readonly ILogger<DriverController> _logger;
    private readonly IMapper _mapper;
    private readonly IDbContextFactory<TaxiContext> _contextFactory;

    public DriverController(ILogger<DriverController> logger, IDbContextFactory<TaxiContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
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
        await using var ctx =  await _contextFactory.CreateDbContextAsync();
        Driver? driver = await ctx.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);
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
    /// <param name="driver"> New driver for addition</param>
    /// >
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DriverPostDto driver)
    {
        _logger.LogInformation("Post driver");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Drivers.AddAsync(_mapper.Map<Driver>(driver));
        await ctx.SaveChangesAsync();
        return Ok();
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
    public async Task<IActionResult> Put(ulong id, [FromBody] DriverPostDto driverToPut)
    {
        await using var ctx =  await _contextFactory.CreateDbContextAsync();
        Driver? driver = await ctx.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }
        
        _logger.LogInformation("Put driver with id={id}", id);
        ctx.Update(_mapper.Map(driverToPut, driver));
        await ctx.SaveChangesAsync();
        return Ok();
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
        await using var ctx =  await _contextFactory.CreateDbContextAsync();
        Driver? driver = await ctx.Drivers.FirstOrDefaultAsync(driver => driver.Id == id);
        if (driver == null)
        {
            _logger.LogInformation("Not found driver with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete driver with id={id}", id);
        ctx.Drivers.Remove(driver);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}