using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for vehicle table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;

    private readonly IMapper _mapper;

    private readonly ITaxiRepository _taxiRepository;

    public VehicleController(ILogger<VehicleController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all vehicles
    /// </summary>
    /// <returns>
    ///     List of vehicles
    /// </returns>
    [HttpGet]
    public IEnumerable<VehicleGetDto> Get()
    {
        _logger.LogInformation("Get vehicle");
        return _taxiRepository.Vehicles.Select(vehicle => _mapper.Map<VehicleGetDto>(vehicle));
    }

    /// <summary>
    ///     Get method which returns vehicle by id
    /// </summary>
    /// <param name="id"> Identifier of vehicle</param>
    /// <returns>
    ///     Vehicle with the required id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<VehicleGetDto> Get(ulong id)
    {
        Vehicle? vehicle = _taxiRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle with id={id}");
            return NotFound();
        }

        _logger.LogInformation($"Get vehicle with id={id}");
        return Ok(_mapper.Map<VehicleGetDto>(vehicle));
    }

    /// <summary>
    ///     Post method which add new vehicle in ride table
    /// </summary>
    /// <param name="vehicle"> New vehicle for addition</param>
    /// >
    [HttpPost]
    public void Post([FromBody] VehiclePostDto vehicle)
    {
        _logger.LogInformation("Post vehicle");
        _taxiRepository.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
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
    public IActionResult Put(ulong id, [FromBody] VehiclePostDto vehicleToPut)
    {
        Vehicle? vehicle = _taxiRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation($"Put vehicle with id={id}", id);
        _mapper.Map(vehicleToPut, vehicle);
        return Ok();
    }

    /// <summary>
    ///     Delete - method for deleting a vehicle by the desired identifier
    /// </summary>
    /// <param name="id"> Identifier of vehicle </param>
    /// <returns>
    ///     Signalization of success or error
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        Vehicle? vehicle = _taxiRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Delete vehicle with id={id}", id);
        _taxiRepository.Vehicles.Remove(vehicle);
        return Ok();
    }
}