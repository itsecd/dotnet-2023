using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleModelController : ControllerBase
{
    private readonly ILogger<VehicleModelController> _logger;
    
    private readonly IRentalServiceRepository _rentalServiceRepository;
    
    public VehicleModelController(ILogger<VehicleModelController> logger, IRentalServiceRepository rentalServiceRepository )
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
    }
    
    [HttpGet]
    public IEnumerable<VehicleModel> Get()
    {
        return _rentalServiceRepository.VehicleModels;
    }
    
    [HttpGet("{id}")]
    public ActionResult<VehicleModel> Get(ulong id)
    {
        var vehicleModel = _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation($"Not found vehicle model: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(vehicleModel);
        }
    }
}

