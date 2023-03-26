using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleClassificationController : ControllerBase
{
    private readonly ILogger<VehicleClassificationController> _logger;
    
    private readonly ITaxiRepository _taxiRepository;
    
    public VehicleClassificationController(ILogger<VehicleClassificationController> logger, ITaxiRepository taxiRepository)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
    }

    [HttpGet]
    public IEnumerable<VehicleClassification> Get()
    {
        _logger.LogInformation("Get vehicles classification");
        return _taxiRepository.VehicleClassifications;
    }

    [HttpGet("{id}")]
    public ActionResult<VehicleClassification> Get(ulong id)
    {
        var vehicleClassification = _taxiRepository.VehicleClassifications.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicleClassification == null)
        {
            _logger.LogInformation($"Not found vehicle classification with id={id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get vehicle classification with id={id}");
            return Ok(vehicleClassification);
        }
    }
    
}