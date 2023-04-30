using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Patient controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;
    private readonly IDbContextFactory<PolyclinicDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public PatientController(ILogger<PatientController> logger, IDbContextFactory<PolyclinicDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Get patients
    /// </summary>
    /// <returns>patients</returns>
    [HttpGet]
    public async Task<IEnumerable<PatientGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get Patients");
        var patients = await ctx.Patients.ToArrayAsync();
        return _mapper.Map<IEnumerable<PatientGetDto>>(patients);
    }

    /// <summary>
    /// Get patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>patient</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var patient = await ctx.FindAsync<PatientGetDto>(id);
        if (patient == null)
        {
            _logger.LogInformation($"Not found patient: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get patient with id {id}");
            return Ok(patient);
        }
    }

    /// <summary>
    /// Post patient
    /// </summary>
    /// <param name="patient"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] PatientPostDto patient)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post patient");
        await ctx.Patients.AddAsync(_mapper.Map<Patient>(patient));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patientToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] PatientPostDto patientToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var patient = await ctx.FindAsync<Patient>(id);
        if (patient == null)
        {
            _logger.LogInformation($"Not found patient: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put patient with id {id}");
            _mapper.Map(patientToPut, patient);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var patient = await ctx.FindAsync<Patient>(id);
        if (patient == null)
        {
            _logger.LogInformation($"Not found patient: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put patient with id {id}");
            ctx.Patients.Remove(patient);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
