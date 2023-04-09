using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PonrfDomain;
using PonrfServer.Dto;
using PonrfServer.Repository;

namespace PonrfServer.Controllers;

/// <summary>
/// PrivatizedBuilding controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PrivatizedBuildingController : ControllerBase
{
    private readonly ILogger<PrivatizedBuildingController> _logger;

    private readonly IPonrfRepository _ponrfRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for PrivatizedBuildingController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="ponrfRepository"></param>
    /// <param name="mapper"></param>
    public PrivatizedBuildingController(ILogger<PrivatizedBuildingController> logger, IPonrfRepository ponrfRepository, IMapper mapper)
    {
        _logger = logger;
        _ponrfRepository = ponrfRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all privatized buildings
    /// </summary>
    /// <returns>List of privatized buildings</returns>
    [HttpGet]
    public IEnumerable<PrivatizedBuildingGetDto> Get()
    {
        _logger.LogInformation("Get information about all privatized buildings");
        return _mapper.Map<IEnumerable<PrivatizedBuildingGetDto>>(_ponrfRepository.PrivatizedBuildings);
    }

    /// <summary>
    /// Get a privatized building by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Privatized building</returns>
    [HttpGet("{id}")]
    public ActionResult<PrivatizedBuildingGetDto?> Get(int id)
    {
        var privatizedBuilding = _ponrfRepository.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation($"Not found privatized building with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get a privatized building");
            return Ok(_mapper.Map<PrivatizedBuildingGetDto>(privatizedBuilding));
        }
    }

    /// <summary>
    /// Post a new privatized building
    /// </summary>
    /// <param name="privatizedBuilding"></param>
    [HttpPost]
    public void Post([FromBody] PrivatizedBuildingPostDto privatizedBuilding)
    {
        _logger.LogInformation("Post a new privatized building");
        _ponrfRepository.PrivatizedBuildings.Add(_mapper.Map<PrivatizedBuilding>(privatizedBuilding));
    }

    /// <summary>
    /// Put a privatized building
    /// </summary>
    /// <param name="id"></param>
    /// <param name="privatizedBuildingToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PrivatizedBuildingPostDto privatizedBuildingToPut)
    {
        var privatizedBuilding = _ponrfRepository.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation($"Not found privatized building with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(privatizedBuildingToPut, privatizedBuilding);
            _logger.LogInformation("Put a privatized building");
            return Ok();
        }
    }

    /// <summary>
    /// Delete a privatized building by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var privatizedBuilding = _ponrfRepository.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation($"Not found privatized building with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a privatized building");
            _ponrfRepository.PrivatizedBuildings.Remove(privatizedBuilding);
            return Ok();
        }
    }
}