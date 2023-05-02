using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;

namespace Polyclinic.Server.Controllers;

/// <summary>
///  Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly IDbContextFactory<PolyclinicDbContext> _contextFactory;
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IMapper _mapper;
    public AnalyticsController(IDbContextFactory<PolyclinicDbContext> contextFactory, ILogger<AnalyticsController> logger, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Display information about all doctors with at least 10 years of experience
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutDoctorsExp")]
    public async Task<IActionResult> GetInformationAboutDoctors()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about doctors work experience");

        var result = await (from d in ctx.Doctors
                            where d.WorkExperience >= 10
                            select _mapper.Map<DoctorGetDto>(d)).ToListAsync();
        return Ok(result);
    }

    /// <summary>
    /// Display information about all patients registered with the specified doctor, sorted by full name.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutRegistrationsPatients")]
    public async Task<IActionResult> GetInformationAboutPatients(string name)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about registrations patients");

        var result = await (from reg in ctx.Registrations
                            join p in ctx.Patients on reg.IdPatient equals p.Id
                            join d in ctx.Doctors on reg.IdDoctor equals d.Id
                            where d.FullName == name
                            orderby p.FullName
                            select _mapper.Map<PatientGetDto>(p)).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutHealthyPatients")]
    public async Task<IActionResult> GetInformationAboutHealtyPatients()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about healthy patients");

        var result = await (from c in ctx.Completions
                            join p in ctx.Patients on c.IdPatient equals p.Id
                            where c.Status == 1
                            group p by p.Id into g
                            select _mapper.Map<PatientGetDto>(g.First())).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Display information about the number of appointments of patients by doctors for the last month.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutAppointmentsPatients")]
    public async Task<IActionResult> GetInformationAboutAppointmentsPatients()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about count patients of visits to doctors for last month");

        var result = await (from r in ctx.Registrations
                            join p in ctx.Patients on r.IdPatient equals p.Id
                            join d in ctx.Doctors on r.IdDoctor equals d.Id
                            where r.TimeAdmission >= DateTime.Now.AddMonths(-1) && r.TimeAdmission <= DateTime.Now
                            group r by d into dGroup
                            select new { Doctor = dGroup.Key.FullName, Appointments = dGroup.Count() }).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Display information about the top 5 most common diseases among patients
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutTopFiveDiseases")]
    public async Task<IActionResult> GetInformationAboutTopFiveDiseases()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about top 5 most common diseases patients");

        var result = await ((from c in ctx.Completions
                             join p in ctx.Patients on c.IdPatient equals p.Id
                             group c by c.Conclusion into g
                             orderby g.Count() descending
                             select new { Disease = g.Key, Count = g.Count() }).Take(5)).ToListAsync();

        return Ok(result);
    }

    /// <summary>
    /// Display information about patients over 30 years of age who have appointments with several doctors, sorted by date of birth.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutPatientsOverThirty")]
    public async Task<IActionResult> GetInformationAboutPatientsOverThirty()
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about patients older than 30 who are registered on multiple doctor appointments");

        var result = await (from p in ctx.Patients
                            let age = (int)(DateOnly.FromDateTime(DateTime.Today).Year - p.DateBirth.Year / 365)
                            where age > 30
                            join r in ctx.Registrations on p.Id equals r.IdPatient into appointments
                            where appointments.GroupBy(a => a.IdDoctor).Count() > 1
                            orderby p.DateBirth
                            select _mapper.Map<PatientGetDto>(p)).ToListAsync();

        return Ok(result);
    }
}
