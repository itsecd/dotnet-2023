using AirplaneBookingSystem.Domain;
using AirplaneBookingSystem.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirplaneBookingSystem.Server.Controllers;
/// <summary>
/// Airplanes
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class AirplaneController : ControllerBase
{
    private readonly IDbContextFactory<AirplaneBookingSystemDbContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<AirplaneController> _logger;

    public AirplaneController(ILogger<AirplaneController> logger, IDbContextFactory<AirplaneBookingSystemDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    /// <summary>
    /// Get method for airplane table
    /// </summary>
    /// <returns>
    /// Return all airplanes
    /// </returns>
    [HttpGet]
    public async Task<IEnumerable<AirplaneGetDto>> GetAirplanes()
    {
        _logger.LogInformation("Get all airplanes");
        var ctx = await _contextFactory.CreateDbContextAsync();
        var airplanes = await ctx.Airplanes.ToArrayAsync();
        return _mapper.Map<IEnumerable<AirplaneGetDto>>(airplanes);
    }
    /// <summary>
    /// Get by id method for airplane table
    /// </summary>
    /// <param name="idAirplane">id airplane</param>
    /// <returns>Ok with AirplaneGetDto or NotFound</returns>
    [HttpGet("{idAirplane}")]
    public async Task<ActionResult<AirplaneGetDto>> GetAirplane(int idAirplane)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var airplane = await ctx.Airplanes.FirstOrDefaultAsync(airplane => airplane.Id == idAirplane);
        if (airplane == null)
        {
            _logger.LogInformation("Not found airplane : {idAirplane}", idAirplane);
            return NotFound($"The airplane does't exist by this id {idAirplane}");
        }
        else
        {
            _logger.LogInformation("Get airplane by {idAirplane}", idAirplane);
            return Ok(_mapper.Map<AirplaneGetDto>(airplane));
        }
    }
    /// <summary>
    /// Put method for airplane table
    /// </summary>
    /// <param name="idAirplane">An id of airplane which would be changed </param>
    /// <param name="airplaneToPut">Airplane class instance to insert to table</param>
    /// <returns>Ok or NotFound</returns>
    [HttpPut("{idAirplane}")]
    public async Task<IActionResult> PutAirplane(int idAirplane, [FromBody] AirplanePostDto airplaneToPut)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var airplane = await ctx.Airplanes.FirstOrDefaultAsync(airplane => airplane.Id == idAirplane);
        if (airplane == null)
        {
            _logger.LogInformation("Not found airplane : {idAirplane}", idAirplane);
            return NotFound($"The airplane does't exist by this id {idAirplane}");
        }
        else
        {
            _logger.LogInformation("Update airplane by id {idAirplane}", idAirplane);
            _mapper.Map(airplaneToPut, airplane);
            ctx.Airplanes.Update(_mapper.Map<Airplane>(airplane));
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
    /// <summary>
    /// Post method for airplane table
    /// </summary>
    /// <param name="airplane"> Airplane class instance to insert to table</param>
    /// <returns>Сreated airplane</returns>
    [HttpPost]
    public async Task PostAirplane([FromBody] AirplanePostDto airplane)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Create new airplane");
        await ctx.Airplanes.AddAsync(_mapper.Map<Airplane>(airplane));
        await ctx.SaveChangesAsync();
    }
    /// <summary>
    /// Delete method 
    /// </summary>
    /// <param name="idAirplane">An id of airplane which would be deleted</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("{idAirplane}")]
    public async Task<IActionResult> DeleteAirplane(int idAirplane)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();
        var airplane = await ctx.Airplanes.Include(airplane => airplane.Flights)
                                        .FirstOrDefaultAsync(airplane => airplane.Id == idAirplane);
        if (airplane == null)
        {
            _logger.LogInformation("Not found airplane : {idAirplane}", idAirplane);
            return NotFound($"The airplane does't exist by this id {idAirplane}");
        }
        else
        {
            _logger.LogInformation("Delete airplane by id {idAirplane}", idAirplane);
            ctx.Airplanes.Remove(airplane);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}