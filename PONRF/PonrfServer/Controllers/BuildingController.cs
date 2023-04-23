using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer.Controllers;

/// <summary>
/// Building controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ILogger<BuildingController> _logger;

    private readonly IDbContextFactory<PonrfContext> _contextFactory;

    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for BuildingController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public BuildingController(ILogger<BuildingController> logger, IDbContextFactory<PonrfContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all buildings
    /// </summary>
    /// <returns>List of buildings</returns>
    [HttpGet]
    public IEnumerable<BuildingGetDto> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get information about all buildings");
        return _mapper.Map<IEnumerable<BuildingGetDto>>(context.Buildings);
    }

    /// <summary>
    /// Get a building by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Building</returns>
    [HttpGet("{id}")]
    public ActionResult<BuildingGetDto?> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var building = context.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation("Not found building with {id}", id);
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
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post a new building");
        context.Buildings.Add(_mapper.Map<Building>(building));
        context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var building = context.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation("Not found building with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(buildingToPut, building);
            context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var building = context.Buildings.FirstOrDefault(building => building.Id == id);
        if (building == null)
        {
            _logger.LogInformation("Not found building with {id}", id);
            return NotFound();
        }
        else
        {
            context.Buildings.Remove(building);
            context.SaveChanges();
            _logger.LogInformation("Delete a building");
            return Ok();
        }
    }
}
