using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;
using PonrfServer.Repository;

namespace PonrfServer.Controllers;
/// <summary>
/// Building controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;

    private readonly IPonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for BuildingController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ponrfRepository"></param>
    /// <param name="mapper"></param>
    public BuildingController(ILogger<BuildingController> logger, IPonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all buildings
    /// </summary>
    /// <returns>List of buildings</returns>
    [HttpGet]
    public IEnumerable<BuildingGetDto> Get()
    {
        _logger.LogInformation("Get information about all buildings");
        return _mapper.Map<IEnumerable<BuildingGetDto>>(_ponrfRepository.Buildings);
    }

    /// <summary>
    /// Get a building by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Building</returns>
    [HttpGet("{id}")]
    public ActionResult<BuildingGetDto?> Get(int id)
    {
        var building = _ponrfRepository.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation($"Not found building with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get a building");
            return Ok(_mapper.Map<BuildingGetDto>(building));
        }
    }

    /// <summary>
    /// Post a new building
    /// </summary>
    /// <param name="building"></param>
    [HttpPost]
    public void Post([FromBody] BuildingPostDto building)
    {
        _logger.LogInformation("Post a new building");
        _ponrfRepository.Buildings.Add(_mapper.Map<Building>(building));
    }

    /// <summary>
    /// Put a building
    /// </summary>
    /// <param name="id"></param>
    /// <param name="buildingToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BuildingPostDto buildingToPut)
    {
        var building = _ponrfRepository.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation($"Not found building with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(buildingToPut, building);
            _logger.LogInformation("Put a building");
            return Ok();
        }
    }

    /// <summary>
    /// Delete a building by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var building = _ponrfRepository.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation($"Not found building with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a building");
            _ponrfRepository.Buildings.Remove(building);
            return Ok();
        }
    }
}
