using BicycleRentals.Domain;
using BicycleRentals.Server.Respostory;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentals.Server.ControllersModels;
[Route("api/[controller]")]
[ApiController]
public class BicycleTypeController : ControllerBase
{
    private readonly ILogger<BicycleTypeController> _logger;

    private readonly IDbContextFactory<BicycleRentalContext> _contextFactory;
    public BicycleTypeController(ILogger<BicycleTypeController> logger, IDbContextFactory<BicycleRentalContext> contextFactory)
    {
        _logger = logger;
        _contextFactory = contextFactory;
    }

    /// <summary> 
    /// Returns a list of all types. 
    /// </summary> 
    /// <returns>The list of all types.</returns>
    [HttpGet]
    public async Task<IEnumerable<BicycleType>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("GET: Get list of type");
        return await context.BicycleTypes.ToListAsync();
    }

    /// <summary> 
    /// Returns a type by id. 
    /// </summary> 
    /// <param name="id">The type id.</param> 
    /// <returns>OK (the type found by the specified id) or NotFound. </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BicycleType>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var bicycleType = await context.BicycleTypes.FirstOrDefaultAsync(bt => bt.TypeId == id);
        if (bicycleType == null)
        {
            _logger.LogInformation($"Not found type with id {id}");
            return NotFound();
        }
        else
            return Ok(bicycleType);
    }
}
