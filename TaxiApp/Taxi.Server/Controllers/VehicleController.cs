using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Domain;
using Taxi.Server.Dto;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for vehicle table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IDbContextFactory<TaxiDbContext> _contextFactory;
    private readonly ILogger<VehicleController> _logger;
    private readonly IMapper _mapper;

    public VehicleController(IDbContextFactory<TaxiDbContext> contextFactory, IMapper mapper,
        ILogger<VehicleController> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Get method which returns all vehicles
    /// </summary>
    /// <returns>
    ///     List of vehicles
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<VehicleGetDto>> Get()
    {
        _logger.LogInformation("Get vehicle");
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await _mapper.ProjectTo<VehicleGetDto>(ctx.Vehicles).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns vehicle by id
    /// </summary>
    /// <param name="id"> Identifier of vehicle</param>
    /// <returns>
    ///     Vehicle with the required id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleGetDto>> Get(ulong id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var vehicle = await ctx.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get vehicle with id={id}", id);
        return Ok(_mapper.Map<VehicleGetDto>(vehicle));
    }

    /// <summary>
    ///     Post method which add new vehicle in ride table
    /// </summary>
    /// <param name="vehicleToPost"> New vehicle for addition</param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<VehicleGetDto>> Post(VehicleSetDto vehicleToPost)
    {
        _logger.LogInformation("Post vehicle");
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var driverToPost = await ctx.Drivers.FindAsync(vehicleToPost.DriverId);
        if (driverToPost == null)
        {
            _logger.LogInformation("Not found driver with id={vehicleToPost.DriverId}", vehicleToPost.DriverId);
            return BadRequest();
        }

        var vehicleClassificationToPost =
            await ctx.VehicleClassifications.FindAsync(vehicleToPost.VehicleClassificationId);
        if (vehicleClassificationToPost == null)
        {
            _logger.LogInformation("Not found vehicle classification with id={vehicleToPost.VehicleClassificationId}",
                vehicleToPost.VehicleClassificationId);
            return BadRequest();
        }

        var mappedVehicle = _mapper.Map<Vehicle>(vehicleToPost);

        await ctx.Vehicles.AddAsync(mappedVehicle);
        await ctx.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = mappedVehicle.Id },
            _mapper.Map<VehicleGetDto>(mappedVehicle));
    }

    /// <summary>
    ///     Put method which allows change the data of the desired vehicle by id
    /// </summary>
    /// <param name="id"> Identifier of vehicle</param>
    /// <param name="vehicleToPut"> New vehicle data</param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, VehicleSetDto vehicleToPut)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var driverToPut = await ctx.Drivers.FindAsync(vehicleToPut.DriverId);
        if (driverToPut == null)
        {
            _logger.LogInformation("Not found driver with id={vehicleToPut.DriverId}", vehicleToPut.DriverId);
            return BadRequest();
        }

        var vehicleClassificationToPut =
            await ctx.VehicleClassifications.FindAsync(vehicleToPut.VehicleClassificationId);
        if (vehicleClassificationToPut == null)
        {
            _logger.LogInformation("Not found vehicle classification with id={vehicleToPut.VehicleClassificationId}",
                vehicleToPut.VehicleClassificationId);
            return BadRequest();
        }

        var vehicle = await ctx.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Put vehicle with id={id}", id);
        await ctx.SaveChangesAsync();
        _mapper.Map(vehicleToPut, vehicle);
        return NoContent();
    }

    /// <summary>
    ///     Delete - method for deleting a vehicle by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of vehicle </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        var vehicle = await ctx.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete vehicle with id={id}", id);
        ctx.Vehicles.Remove(vehicle);
        await ctx.SaveChangesAsync();
        return NoContent();
    }
}