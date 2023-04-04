using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    private readonly ILogger<VehicleModelController> _logger;
    private readonly IMapper _mapper;
    private readonly IRentalServiceRepository _rentalServiceRepository;

    public VehicleModelController(ILogger<VehicleModelController> logger,
        IRentalServiceRepository rentalServiceRepository, IMapper mapper)
    {
        _logger = logger;
        _rentalServiceRepository = rentalServiceRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get method which returns all vehicle models
    /// </summary>
    [HttpGet]
    public IEnumerable<VehicleModelGetDto> Get()
    {
        return _rentalServiceRepository.VehicleModels.Select(model => _mapper.Map<VehicleModelGetDto>(model));
    }

    /// <summary>
    ///     Get method which returns vehicle model by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<VehicleModelGetDto> Get(ulong id)
    {
        VehicleModel? vehicleModel =
            _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation($"Not found vehicle model: {id}");
            return NotFound();
        }

        return Ok(_mapper.Map<VehicleModelGetDto>(vehicleModel));
    }
    
    /// <summary>
    ///     Post method which add new vehicle model
    /// </summary>
    [HttpPost]
    public void Post([FromBody] VehicleModelPostDto vehicleModel)
    {
        _rentalServiceRepository.VehicleModels.Add(_mapper.Map<VehicleModel>(vehicleModel));
    }
    
    /// <summary>
    ///     Put method for changing data in the vehicle model table
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult Put(ulong id, [FromBody] VehicleModelPostDto vehicleModelToPut)
    {
        VehicleModel? vehicleModel = _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation("Not found vehicle model: {id}", id);
            return NotFound();
        }

        _mapper.Map(vehicleModelToPut, vehicleModel);

        return Ok();
    }

    /// <summary>
    ///     Delete method for deleting a vehicle model
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(ulong id)
    {
        VehicleModel? vehicleModel = _rentalServiceRepository.VehicleModels.FirstOrDefault(vehicleModel => vehicleModel.Id == id);
        if (vehicleModel == null)
        {
            _logger.LogInformation($"Not found vehicle model: {id}");
            return NotFound();
        }

        _rentalServiceRepository.VehicleModels.Remove(vehicleModel);
        return Ok();
    }
}