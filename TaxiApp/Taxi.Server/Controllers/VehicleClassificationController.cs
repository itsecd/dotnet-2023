using Microsoft.AspNetCore.Mvc;
using Taxi.Domain;
using Taxi.Server.Repository;

namespace Taxi.Server.Controllers;

/// <summary>
///     Controller for vehicle classification table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleClassificationController : ControllerBase
{
    private readonly ILogger<VehicleClassificationController> _logger;

    private readonly ITaxiRepository _taxiRepository;

    public VehicleClassificationController(ILogger<VehicleClassificationController> logger,
        ITaxiRepository taxiRepository)
    {
        _logger = logger;
        _taxiRepository = taxiRepository;
    }

    /// <summary>
    ///     Get method which returns vehicles classification
    /// </summary>
    /// <returns>
    ///     List of vehicle classification
    /// </returns>
    [HttpGet]
    public IEnumerable<VehicleClassification> Get()
    {
        _logger.LogInformation("Get vehicles classification");
        return _taxiRepository.VehicleClassifications;
    }

    /// <summary>
    ///     Get method which returns vehicle classification by id
    /// </summary>
    /// <param name="id"> Identifier of vehicle classification</param>
    /// <returns>
    ///     Vehicle classification with the required id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<VehicleClassification> Get(ulong id)
    {
        VehicleClassification? vehicleClassification =
            _taxiRepository.VehicleClassifications.FirstOrDefault(vehicle => vehicle.Id == id);
        if (vehicleClassification == null)
        {
            _logger.LogInformation("Not found vehicle classification with id={id}", id);
            return NotFound();
        }

        _logger.LogInformation("Get vehicle classification with id={id}", id);
        return Ok(vehicleClassification);
    }
}