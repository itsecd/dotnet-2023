using Airlines.Domain;
using Airlines.Server.Dto;
using Airlines.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airlines.Server.Controllers;

/// <summary>
/// Controller for airplane table
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AirplaneController : ControllerBase
{
    private readonly ILogger<AirplaneController> _logger;
    private readonly IAirlinesRepository _airlinesRepository;
    private readonly IDbContextFactory<AirlinesContext> _contextFactory;
    private readonly IMapper _mapper;

    public AirplaneController(IDbContextFactory<AirlinesContext> contextFactory,ILogger<AirplaneController> logger, IAirlinesRepository airlinesRepository, IMapper mapper)
    {
        _contextFactory= contextFactory;
        _logger = logger;
        _airlinesRepository = airlinesRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get method for airplane table
    /// </summary>
    /// <returns>
    /// Return all airplanes
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<AirplaneGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get airplaes");
        return _mapper.Map<IEnumerable<AirplaneGetDto>>(ctx.Airplanes);
    }

    /// <summary>
    /// Get by id method for airplane table
    /// </summary>
    /// <returns>
    /// Return airplane with specified id
    /// </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<AirplaneGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Get airplane with id ({id})");
        var airplane = ctx.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane with id ({id})");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<AirplaneGetDto>(airplane));
        }
    }

    /// <summary>
    /// Post method for airplane table
    /// </summary>
    /// <param name="airplane"> Airplane class instance to insert to table</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AirplanePostDto airplane)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post airplane");
        ctx.Airplanes.Add(_mapper.Map<Airplane>(airplane));
        ctx.SaveChanges();
        return Ok();
    }

    /// <summary>
    /// Put method for airplane table
    /// </summary>
    /// <param name="id">An id of airplane which would be changed </param>
    /// <param name="airplaneToPut">Airplane class instance to insert to table</param>
    /// <returns>Signalization of success of error</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] AirplanePostDto airplaneToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Put airplane with id {0}", id);
        var airplane = ctx.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation("Not found airplane with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(airplaneToPut, airplane);
            ctx.SaveChanges();
            return Ok();
        }
    }

    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="id">An id of airplane which would be deleted</param>
    /// <returns>Signalization of success of error</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation($"Put airplane with id ({id})");
        var airplane = ctx.Airplanes.FirstOrDefault(airplane => airplane.Id == id);
        if (airplane == null)
        {
            _logger.LogInformation($"Not found airplane with id ({id})");
            return NotFound();
        }
        else
        {
            ctx.Airplanes.Remove(airplane);
            ctx.SaveChanges();
            return Ok();
        }
    }
}