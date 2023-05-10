using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for vehicle table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly RentalServiceDbContext _context;
    private readonly IMapper _mapper;

    public VehicleController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all vehicles
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleGetDto>>> Get()
    {
        if (_context.Vehicles == null)
        {
            return NotFound();
        }

        return await _mapper.ProjectTo<VehicleGetDto>(_context.Vehicles).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns vehicle by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleGetDto>> Get(ulong id)
    {
        if (_context.Vehicles == null)
        {
            return NotFound();
        }

        Vehicle? vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<VehicleGetDto>(vehicle));
    }

    /// <summary>
    ///     Post method which add new vehicle
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<VehicleGetDto>> Post([FromBody] VehiclePostDto vehicle)
    {
        if (_context.Vehicles == null)
        {
            return Problem("Entity set 'DataBaseContext.Vehicles'  is null.");
        }

        Vehicle? mappedVehicle = _mapper.Map<Vehicle>(vehicle);

        _context.Vehicles.Add(mappedVehicle);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedVehicle.Id }, _mapper.Map<VehicleGetDto>(mappedVehicle));
    }

    /// <summary>
    ///     Put method for changing data in the vehicle table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] VehiclePostDto vehicleToPut)
    {
        if (_context.Vehicles == null)
        {
            return NotFound();
        }

        Vehicle? vehicleToModify = await _context.Vehicles.FindAsync(id);

        if (vehicleToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(vehicleToPut, vehicleToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a vehicle
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        if (_context.Vehicles == null)
        {
            return NotFound();
        }

        Vehicle? vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}