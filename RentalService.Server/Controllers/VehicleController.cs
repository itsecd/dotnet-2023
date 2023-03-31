using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly ILogger<VehicleController> _logger;
    
    private readonly IRentalServiceRepository _rentalServiceRepository;

    private readonly IMapper _mapper;
    
    public VehicleController(ILogger<VehicleController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// ffddgfhgsfvs
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<VehicleGetDto> Get()
    {
        return _rentalServiceRepository.Vehicles.Select(vehicle => _mapper.Map<VehicleGetDto>(vehicle));
    }
    
    [HttpGet("{id}")]
    public ActionResult<VehicleGetDto> Get(ulong id)
    {
        var vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(_mapper.Map<VehicleGetDto>(vehicle));
        }
    }
    
    [HttpPost]
    public void Post([FromBody] VehiclePostDto vehicle)
    {
        _rentalServiceRepository.Vehicles.Add(_mapper.Map<Vehicle>(vehicle));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] VehiclePostDto vehicleToPut)
    {
        var vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation("Not found vehicle: {id}", id);
            return NotFound(); 
        }
        else
        {
            _mapper.Map(vehicleToPut, vehicle);
    
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        var vehicle = _rentalServiceRepository.Vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicle == null)
        {
            _logger.LogInformation($"Not found vehicle: {id}");
            return NotFound(); 
        }
        else
        {
            _rentalServiceRepository.Vehicles.Remove(vehicle);
            return Ok();
        }
    }
}

