using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for vehicle classification table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleClassificationController : ControllerBase
{
    private readonly IDbContextFactory<TaxiDbContext> _contextFactory;
    private readonly ILogger<VehicleClassificationController> _logger;

    public VehicleClassificationController(IDbContextFactory<TaxiDbContext> contextFactory,
        ILogger<VehicleClassificationController> logger)
    {
        _contextFactory = contextFactory;
        _logger = logger;
    }

    /// <summary>
    ///     Get method which returns vehicles classification
    /// </summary>
    /// <returns>
    ///     List of vehicle classification
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<VehicleClassification>> Get()
    {
        _logger.LogInformation("Get vehicles classification");
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.VehicleClassifications.ToListAsync();
    }

    /// <summary>
    ///     Get method which returns vehicle classification by id
    /// </summary>
    /// <param name="id"> Identifier of vehicle classification</param>
    /// <returns>
    ///     Vehicle classification with the required id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleClassification>> Get(ulong id)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        VehicleClassification? vehicleClassification = await ctx.VehicleClassifications.FindAsync(id);
        if (vehicleClassification == null)
        {
            _logger.LogInformation("Not found vehicle classification with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get vehicle classification with id={id}", id);
        return Ok(vehicleClassification);
    }
}