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
    public async Task<IEnumerable<BuildingGetDto>> Get()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about all buildings");
        return _mapper.Map<IEnumerable<BuildingGetDto>>(context.Buildings);
    }

    /// <summary>
    /// Get a building by id
    /// </summary>
    /// <param name="id">Building's id</param>
    /// <returns>Building with required id</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BuildingGetDto?>> Get(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var building = await context.Buildings.FirstOrDefaultAsync(building => building.Id == id);
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
    /// <param name="building">New building</param>
    /// <returns>Ok (success code)</returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] BuildingPostDto building)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post a new building");
        context.Buildings.Add(_mapper.Map<Building>(building));
        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put a building
    /// </summary>
    /// <param name="id">Building's id</param>
    /// <param name="buildingToPut">New building</param>
    /// <returns>Ok (success code) or NotFound (error code)</returns>
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
    /// <param name="id">Building's id</param>
    /// <returns>Ok (success code) or NotFound (error code)</returns>
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
