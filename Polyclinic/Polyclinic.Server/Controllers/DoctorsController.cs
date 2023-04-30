using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Doctors controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly ILogger<DoctorsController> _logger;
    private readonly IDbContextFactory<PolyclinicDbContext> _contextFactory;
    private readonly IMapper _mapper;
    public DoctorsController(ILogger<DoctorsController> logger, IDbContextFactory<PolyclinicDbContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Get doctors
    /// </summary>
    /// <returns>doctors</returns>
    [HttpGet]
    public async Task<IEnumerable<DoctorGetDto>> Get()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var doctors = await ctx.Doctors.ToArrayAsync();
        _logger.LogInformation("Get doctor");
        return _mapper.Map<IEnumerable<DoctorGetDto>>(doctors);
    }

    /// <summary>
    /// Get doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>doctor</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var doctor = await ctx.FindAsync<DoctorGetDto>(id);
        if (doctor == null)
        {
            _logger.LogInformation($"Not found doctor: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get completion with id {id}");
            return Ok(doctor);
        }
    }

    /// <summary>
    /// Post doctor
    /// </summary>
    /// <param name="doctor"></param>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DoctorPostDto doctor)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Post doctor");
        await ctx.Doctors.AddAsync(_mapper.Map<Doctor>(doctor));
        await ctx.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Put doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="doctorToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] DoctorPostDto doctorToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var doctor = await ctx.FindAsync<Doctor>(id);
        if (doctor == null)
        {
            _logger.LogInformation($"Not found doctor: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put doctor with id {id}");
            _mapper.Map(doctorToPut, doctor);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Delete doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var doctor = await ctx.FindAsync<Doctor>(id);
        if (doctor == null)
        {
            _logger.LogInformation($"Not found doctor: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put doctor with id {id}");
            ctx.Doctors.Remove(doctor);
            await ctx.SaveChangesAsync();
            return Ok();
        }
    }
}
