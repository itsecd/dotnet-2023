using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;

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
    private readonly IMapper _mapper;

    public VehicleClassificationController(IDbContextFactory<TaxiDbContext> contextFactory,
        ILogger<VehicleClassificationController> logger, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
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


    /// <summary>
    ///     Post method which add new vehicle classification in ride table
    /// </summary>
    /// <param name="vehicleClassificationToPost"> New vehicle for addition</param>
    /// >
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<VehicleClassification>> Post(VehicleClassificationSetDto vehicleClassificationToPost)
    {
        _logger.LogInformation("Post vehicle classification");
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        VehicleClassification? mappedVehicleClassification =
            _mapper.Map<VehicleClassification>(vehicleClassificationToPost);

        await ctx.VehicleClassifications.AddAsync(mappedVehicleClassification);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = mappedVehicleClassification.Id },
            _mapper.Map<VehicleClassification>(mappedVehicleClassification));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired vehicle classification by id
    /// </summary>
    /// <param name="id"> Identifier of vehicle classification</param>
    /// <param name="vehicleToPut"> New vehicle data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, VehicleClassificationSetDto vehicleClassificationToPut)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();

        VehicleClassification? vehicleClassification = await ctx.VehicleClassifications.FindAsync(id);
        if (vehicleClassification == null)
        {
            _logger.LogInformation("Not found vehicle classification with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put vehicle classification with id={id}", id);
        _mapper.Map(vehicleClassificationToPut, vehicleClassification);
        await ctx.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    ///     Delete - method for deleting a vehicle classification by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of vehicle classification</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        await using TaxiDbContext ctx = await _contextFactory.CreateDbContextAsync();
        VehicleClassification? vehicleClassification = await ctx.VehicleClassifications.FindAsync(id);
        if (vehicleClassification == null)
        {
            _logger.LogInformation("Not found vehicle classification with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete vehicle classification with id={id}", id);
        ctx.VehicleClassifications.Remove(vehicleClassification);
        await ctx.SaveChangesAsync();
        return NoContent();
    }
}