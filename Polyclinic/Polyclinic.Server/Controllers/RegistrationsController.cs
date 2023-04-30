using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Registration controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RegistrationsController : ControllerBase
{
    private readonly ILogger<RegistrationsController> _logger;
    private readonly IDbContextFactory<PolyclinicDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public RegistrationsController(ILogger<RegistrationsController> logger, IDbContextFactory<PolyclinicDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get registrations
    /// </summary>
    /// <returns>patients</returns>
    [HttpGet]
    public async Task<IEnumerable<RegistrationGetDto>> Get()
    {
        _logger.LogInformation("Get Registrations");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var registrations = await ctx.Registrations.ToArrayAsync();
        return _mapper.Map<IEnumerable<RegistrationGetDto>>(registrations);
    }

    /// <summary>
    /// Get regiastration by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>patient</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Registration>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var registration = await ctx.FindAsync<RegistrationGetDto>(id);
        if (registration == null)
        {
            _logger.LogInformation($"Not found registration: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get registration with id {id}");
            return Ok(registration);
        }
    }

    /// <summary>
    /// Post registration
    /// </summary>
    /// <param name="registration"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] RegistrationPostDto registration)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post registration");
        await ctx.Registrations.AddAsync(_mapper.Map<Registration>(registration));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put registration by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="registrationToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] RegistrationPostDto registrationToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var registration = await ctx.FindAsync<Registration>(id);
        if (registration == null)
        {
            _logger.LogInformation($"Not found registration: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put registration with id {id}");
            _mapper.Map(registrationToPut, registration);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete registration by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var registration = await ctx.FindAsync<Registration>(id);
        if (registration == null)
        {
            _logger.LogInformation($"Not found registration: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put registration with id {id}");
            ctx.Registrations.Remove(registration);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
