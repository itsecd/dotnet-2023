using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for vehicle table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly RentalServiceDbContext _context;

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
        //return _rentalServiceRepository.Vehicles.Select(vehicle => _mapper.Map<VehicleGetDto>(vehicle));
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
        /*Vehicle? vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle: {id}");
            return NotFound();
        }

        return Ok(_mapper.Map<VehicleGetDto>(vehicle));*/
        if (_context.Vehicles == null)
        {
            return NotFound();
        }
        var vehicle = await _context.Vehicles.FindAsync(id);

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
        //_rentalServiceRepository.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
        if (_context.Vehicles == null)
        {
            return Problem("Entity set 'DataBaseContext.Vehicles'  is null.");
        }

        var mappedVehicle = _mapper.Map<Vehicle>(vehicle);
        
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
        /*Vehicle? vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle: {id}", id);
            return NotFound();
        }

        _mapper.Map(vehicleToPut, vehicle);

        return Ok();*/
        if (_context.Vehicles == null)
        {
            return NotFound();
        }
        
        var vehicleToModify = await _context.Vehicles.FindAsync(id);

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
        /*Vehicle? vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle: {id}");
            return NotFound();
        }

        _rentalServiceRepository.Vehicles.Remove(vehicle);
        return Ok();*/
        if (_context.Vehicles == null)
        {
            return NotFound();
        }
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null)
        {
            return NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}