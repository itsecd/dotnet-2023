using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PonrfDomain;
using PonrfServer.Dto;

namespace PonrfServer.Controllers;

/// <summary>
/// PrivatizedBuilding controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PrivatizedBuildingController : ControllerBase
{
    private readonly ILogger<PrivatizedBuildingController> _logger;

    private readonly IDbContextFactory<PonrfContext> _contextFactory;

    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for PrivatizedBuildingController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public PrivatizedBuildingController(ILogger<PrivatizedBuildingController> logger, IDbContextFactory<PonrfContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get information about all privatized buildings
    /// </summary>
    /// <returns>List of privatized buildings</returns>
    [HttpGet]
    public IEnumerable<PrivatizedBuildingGetDto> Get()
    {
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Get information about all privatized buildings");
        return _mapper.Map<IEnumerable<PrivatizedBuildingGetDto>>(context.PrivatizedBuildings);
    }

    /// <summary>
    /// Get a privatized building by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Privatized building</returns>
    [HttpGet("{id}")]
    public ActionResult<PrivatizedBuildingGetDto?> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var privatizedBuilding = context.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation("Not found privatized building with {id}", id);
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
        using var context = _contextFactory.CreateDbContext();
        _logger.LogInformation("Post a new privatized building");
        context.PrivatizedBuildings.Add(_mapper.Map<PrivatizedBuilding>(privatizedBuilding));
        context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var privatizedBuilding = context.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation("Not found privatized building with {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(privatizedBuildingToPut, privatizedBuilding);
            context.SaveChanges();
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
        using var context = _contextFactory.CreateDbContext();
        var privatizedBuilding = context.PrivatizedBuildings.FirstOrDefault(privatizedBuilding => privatizedBuilding.Id == id);
        if (privatizedBuilding == null)
        {
            _logger.LogInformation("Not found privatized building with {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Delete a privatized building");
            context.PrivatizedBuildings.Remove(privatizedBuilding);
            context.SaveChanges();
            return Ok();
        }
    }
}