using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

/// <summary>
///     Controller for vehicle model table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleModelController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly RentalServiceDbContext _context;

    public VehicleModelController(RentalServiceDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all vehicle models
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleModelGetDto>>> Get()
    {
        //return _rentalServiceRepository.VehicleModels.Select(model => _mapper.Map<VehicleModelGetDto>(model));
        if (_context.VehicleModels == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<VehicleModelGetDto>(_context.VehicleModels).ToListAsync();
    }

    /// <summary>
    ///     Get method which returns vehicle model by id
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleModelGetDto>> Get(ulong id)
    {
        /*VehicleModel? vehicleModel =
            _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation($"Not found vehicle model: {id}");
            return NotFound();
        }

        return Ok(_mapper.Map<VehicleModelGetDto>(vehicleModel));*/
        if (_context.VehicleModels == null)
        {
            return NotFound();
        }
        var vehicleModel = await _context.VehicleModels.FindAsync(id);

        if (vehicleModel == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<VehicleModelGetDto>(vehicleModel));
    }
    
    /// <summary>
    ///     Post method which add new vehicle model
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<VehicleModelGetDto>> Post([FromBody] VehicleModelPostDto vehicleModel)
    {
        //_rentalServiceRepository.VehicleModels.Add(_mapper.Map<VehicleModel>(vehicleModel));
        if (_context.VehicleModels == null)
        {
            return Problem("Entity set 'DataBaseContext.VehicleModels'  is null.");
        }

        var mappedVehicleModel = _mapper.Map<VehicleModel>(vehicleModel);
        
        _context.VehicleModels.Add(mappedVehicleModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Post", new { id = mappedVehicleModel.Id }, _mapper.Map<VehicleModelGetDto>(mappedVehicleModel));
    }
    
    /// <summary>
    ///     Put method for changing data in the vehicle model table
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ulong id, [FromBody] VehicleModelPostDto vehicleModelToPut)
    {
        /*VehicleModel? vehicleModel = _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation("Not found vehicle model: {id}", id);
            return NotFound();
        }

        _mapper.Map(vehicleModelToPut, vehicleModel);

        return Ok();*/
        if (_context.VehicleModels == null)
        {
            return NotFound();
        }
        
        var vehicleModelToModify = await _context.VehicleModels.FindAsync(id);

        if (vehicleModelToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(vehicleModelToPut, vehicleModelToModify);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    ///     Delete method for deleting a vehicle model
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ulong id)
    {
        /*VehicleModel? vehicleModel = _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation($"Not found vehicle model: {id}");
            return NotFound();
        }

        _rentalServiceRepository.VehicleModels.Remove(vehicleModel);
        return Ok();*/
        if (_context.VehicleModels == null)
        {
            return NotFound();
        }
        var vehicleModel = await _context.VehicleModels.FindAsync(id);
        if (vehicleModel == null)
        {
            return NotFound();
        }

        _context.VehicleModels.Remove(vehicleModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}