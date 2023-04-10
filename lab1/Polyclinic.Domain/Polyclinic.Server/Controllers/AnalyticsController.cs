using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;

/// <summary>
///  Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IPolyclinicRepository _polyclinicRepository;

    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<AnalyticsController> logger, IPolyclinicRepository polyclinicRepository, IMapper mapper)
    {
        _logger = logger;
        _polyclinicRepository = polyclinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Display information about all doctors with at least 10 years of experience
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutDoctorsExp")]
    public IEnumerable<DoctorGetDto> GetInformationAboutDoctors()
    {
        _logger.LogInformation("Get information about doctors work exp");

        var result = from d in _polyclinicRepository.Doctors
                     where d.WorkExperience >= 10
                     select _mapper.Map<DoctorGetDto>(d);
        return result;
    }

    /// <summary>
    /// Display information about all patients registered with the specified doctor, sorted by full name.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutRegistrationsPatients")]
    public IEnumerable<PatientGetDto> GetInformationAboutPatients()
    {
        _logger.LogInformation("Get information about reg patients");

        var result = from reg in _polyclinicRepository.Registrations
                     join p in _polyclinicRepository.Patients on reg.IdPatient equals p.Id
                     join d in _polyclinicRepository.Doctors on reg.IdDoctor equals d.Id
                     where d.FullName == "Brian Sullivan"
                     orderby p.FullName
                     select _mapper.Map<PatientGetDto>(p);

        return result;
    }

    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutHealthyPatients")]
    public IEnumerable<PatientGetDto> GetInformationAboutHealtyPatients()
    {
        _logger.LogInformation("Get information about healthy patients");

        var result = from c in _polyclinicRepository.Completions
                     join p in _polyclinicRepository.Patients on c.IdPatient equals p.Id
                     where c.Status == 1
                     group p by p.Id into g
                     select _mapper.Map<PatientGetDto>(g.First());

        return result;
    }

    /// <summary>
    /// Display information about the number of appointments of patients by doctors for the last month.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutAppointmentsPatients")]
    public IActionResult GetInformationAboutAppointmentsPatients(DateTime lastMonth1, DateTime lastMonth2)
    {
        _logger.LogInformation("Get information about count patients of visits to doctors for last month");
        /*var lastMonth1 = new DateTime(2023, 4, 1);
        var lastMonth2 = new DateTime(2023, 4, 30);*/

        var result = from r in _polyclinicRepository.Registrations
                     join p in _polyclinicRepository.Patients on r.IdPatient equals p.Id
                     join d in _polyclinicRepository.Doctors on r.IdDoctor equals d.Id
                     where r.TimeAdmission >= lastMonth1 && r.TimeAdmission <= lastMonth2
                     group r by d into dGroup
                     select new { Doctor = dGroup.Key.FullName, Appointments = dGroup.Count() };

        return Ok(result);
    }

    /// <summary>
    /// Display information about the top 5 most common diseases among patients
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutTopFiveDiseases")]
    public IActionResult GetInformationAboutTopFiveDiseases()
    {
        _logger.LogInformation("Get information about top 5 most common diseases patients");

        var result = (from c in _polyclinicRepository.Completions
                      join p in _polyclinicRepository.Patients on c.IdPatient equals p.Id
                      group c by c.Conclusion into g
                      orderby g.Count() descending
                      select new { Disease = g.Key, Count = g.Count() }).Take(5).ToList();

        return Ok(result);
    }

    /// <summary>
    /// Display information about patients over 30 years of age who have appointments with several doctors, sorted by date of birth.
    /// </summary>
    /// <returns></returns>
    [HttpGet("/InformationAboutPatientsOverThirty")]
    public IEnumerable<PatientGetDto> GetInformationAboutPatientsOverThirty()
    {
        _logger.LogInformation("Get information about patients older than 30 who are registered on multiple doctor appointments");

        var result = from p in _polyclinicRepository.Patients
                     let age = (int)(DateOnly.FromDateTime(DateTime.Today).Year - p.DateBirth.Year / 365)
                     where age > 30
                     join r in _polyclinicRepository.Registrations on p.Id equals r.IdPatient into appointments
                     where appointments.GroupBy(a => a.IdDoctor).Count() > 1
                     orderby p.DateBirth
                     select _mapper.Map<PatientGetDto>(p);

        return result;
    }
}
