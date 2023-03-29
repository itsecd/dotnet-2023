using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;

    private readonly INonResidentialFundRepository _buildingsRepository;

    private readonly IMapper _mapper;

    public BuildingController(ILogger<BuildingController> logger, INonResidentialFundRepository buildingsRepository, IMapper mapper)
    {
        _logger = logger;
        _buildingsRepository = buildingsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buildings
    /// </summary>
    /// <returns>List of buildings</returns>
    [HttpGet]
    public IEnumerable<Building> Get()
    {
        _logger.LogInformation("Get all buildings");
        return _buildingsRepository.Buildings;
    }

    /// <summary>
    /// Returns the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the building</param>
    /// <returns>Result of operation and building object</returns>
    [HttpGet("{registrationNumber}")]
    public ActionResult<Building> Get(int registrationNumber)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building with registration number: {registrationNumber}", registrationNumber);
            return Ok(building);
        }
    }

    /// <summary>
    /// Creates new building
    /// </summary>
    /// <param name="building">Building to be created</param>
    [HttpPost]
    public void Post([FromBody] BuildingPostDto building)
    {
        _buildingsRepository.Buildings.Add(_mapper.Map<Building>(building));
    }

    /// <summary>
    /// Changes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be changed</param>
    /// <param name="buildingToPut">New building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public IActionResult Put(int registrationNumber, [FromBody] BuildingPostDto buildingToPut)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _mapper.Map(buildingToPut, building);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public IActionResult Delete(int registrationNumber)
    {
        var building = _buildingsRepository.Buildings.FirstOrDefault(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _buildingsRepository.Buildings.Remove(building);
            return Ok();
        }
    }
}
