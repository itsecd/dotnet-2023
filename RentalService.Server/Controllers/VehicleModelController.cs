using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentalService.Domain;
using RentalService.Server.Dto;
using RentalService.Server.Repository;

namespace RentalService.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleModelController : ControllerBase
{
    private readonly ILogger<VehicleModelController> _logger;
    private readonly IRentalServiceRepository _rentalServiceRepository;
    private readonly IMapper _mapper;
    
    public VehicleModelController(ILogger<VehicleModelController> logger, IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<VehicleModelGetDto> Get()
    {
        return _rentalServiceRepository.VehicleModels.Select(model  => _mapper.Map<VehicleModelGetDto>(model));
    }
    
    [HttpGet("{id}")]
    public ActionResult<VehicleModelGetDto> Get(ulong id)
    {
        var vehicleModel = _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation($"Not found vehicle model: {id}");
            return NotFound(); 
        }
        else
        {
            return Ok(_mapper.Map<VehicleModelGetDto>(vehicleModel));
        }
    }
}

