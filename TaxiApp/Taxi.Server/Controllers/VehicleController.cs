using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Dto;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController: ControllerBase
{
    private readonly ILogger<VehicleController> _logger;
    
    private readonly ITaxiRepository _taxiRepository;

    private readonly IMapper _mapper;
    
    public VehicleController(ILogger<VehicleController> logger, ITaxiRepository taxiRepository, IMapper mapper)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<VehicleGetDto> Get()
    {
        _logger.LogInformation("Get vehicle");
        return _taxiRepository.Vehicles.Select(vehicle => _mapper.Map<VehicleGetDto>(vehicle));
    }

    [HttpGet("{id}")]
    public ActionResult<VehicleGetDto> Get(ulong id)
    {
        var vehicle = _taxiRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get vehicle with id={id}");
            return Ok(_mapper.Map<VehicleGetDto>(vehicle));
        }
    }

    [HttpPost]
    public void Post([FromBody] VehiclePostDto vehicle)
    {
        _logger.LogInformation($"Post vehicle");
        _taxiRepository.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
    }
    
    [HttpPut("{id}")]

    public IActionResult Put(ulong id, [FromBody] VehiclePostDto vehicleToPut)
    {
        var vehicle = _taxiRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle with id={id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put vehicle with id={id}", id);
            _mapper.Map(vehicleToPut, vehicle);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    
    public IActionResult Delete(ulong id)
    {
        var vehicle = _taxiRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Delete vehicle with id={id}");
            _taxiRepository.Vehicles.Remove(vehicle);
            return Ok();
        }
    }
}