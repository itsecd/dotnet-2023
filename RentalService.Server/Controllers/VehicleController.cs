using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    private readonly ILogger<VehicleController> _logger;

    private readonly IMapper _mapper;

    private readonly IRentalServiceRepository _rentalServiceRepository;

    public VehicleController(ILogger<VehicleController> logger, IRentalServiceRepository rentalServiceRepository,
        IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all vehicles
    /// </summary>
    [HttpGet]
    public IEnumerable<VehicleGetDto> Get()
    {
        return _rentalServiceRepository.Vehicles.Select(vehicle => _mapper.Map<VehicleGetDto>(vehicle));
    }

    /// <summary>
    ///     Get method which returns vehicle by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<VehicleGetDto> Get(ulong id)
    {
        Vehicle? vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle: {id}");
            return NotFound();
        }

        return Ok(_mapper.Map<VehicleGetDto>(vehicle));
    }

    /// <summary>
    ///     Post method which add new vehicle
    /// </summary>
    [HttpPost]
    public void Post([FromBody] VehiclePostDto vehicle)
    {
        _rentalServiceRepository.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
    }

    /// <summary>
    ///     Put method for changing data in the vehicle table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] VehiclePostDto vehicleToPut)
    {
        Vehicle? vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle: {id}", id);
            return NotFound();
        }

        _mapper.Map(vehicleToPut, vehicle);

        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a vehicle
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        Vehicle? vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle: {id}");
            return NotFound();
        }

        _rentalServiceRepository.Vehicles.Remove(vehicle);
        return Ok();
    }
}