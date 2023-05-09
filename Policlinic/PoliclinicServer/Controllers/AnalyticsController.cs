using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policlinic;
using PoliclinicServer.Dto;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Analytics controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IDbContextFactory<PoliclinicDbContext> _contextFactory;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="contextFactory"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<PoliclinicDbContext> contextFactory, IMapper mapper)
    {
        _contextFactory = contextFactory;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// Display information about all doctors whose work experience is at least 10 years
    /// </summary>
    /// <returns>List of doctors</returns>
    [HttpGet("Doctors_10_years")]
    public async Task<List<DoctorGetDto>> GetDoctors()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Doctors whose work experience is at least 10 years");
        return await (from doctor in context.Doctors
                      where doctor.WorkExperience >= 10
                      select _mapper.Map<DoctorGetDto>(doctor)).ToListAsync();
    }

    /// <summary>
    /// Display information about all patients who have made an appointment with the specified doctor, arrange by name
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <returns>Code of operation</returns>
    [HttpGet("Patients_with_the_specified_doctor")]
    public async Task<IActionResult> GetPatients(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Patients who have made an appointment with the specified doctor");
        var requestPatientList = await (from patient in context.Patients
                                        join reception in context.Receptions on patient.Id equals reception.PatientId
                                        join doctor in context.Doctors on reception.DoctorId equals doctor.Id
                                        where reception.DoctorId == id
                                        orderby patient.Fio
                                        select patient.Fio).ToListAsync();
        return Ok(requestPatientList);
    }
    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    /// <returns>Code of operation</returns>
    [HttpGet("Currently_healthy_patients")]
    public async Task<IActionResult> GetHealthyPatients()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Currently healthy patients");
        var requestHealthyPatientList = await (from patient in context.Patients
                                               join reception in context.Receptions on patient.Id equals reception.PatientId
                                               where reception.Status == "Healthy"
                                               select patient).Distinct().ToListAsync();
        return Ok(requestHealthyPatientList);
    }
    /// <summary>
    /// Display information about the number of patient appointments by doctors for the last month
    /// </summary>
    /// <returns>Code of operation</returns>
    [HttpGet("The_number_of_patient_for_the_last_month")]
    public async Task<IActionResult> GetCountByDoctors()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Information about the number of patient appointments by doctors for the last month");
        var requestCountReceptionsInOneMonth = await (from doctor in context.Doctors
                                                      join reception in context.Receptions on doctor.Id equals reception.DoctorId
                                                      where reception.DateAndTime > new DateTime(2023, 1, 31) && reception.DateAndTime < new DateTime(2023, 3, 1)
                                                      orderby doctor.Receptions.Count descending
                                                      select new
                                                      {
                                                          count = doctor.Receptions.Count,
                                                          key = doctor.Fio
                                                      }).Distinct().ToListAsync();
        return Ok(requestCountReceptionsInOneMonth);
    }
    /// <summary>
    /// Display information about the top 5 most common diseases among patients
    /// </summary>
    /// <returns>Code of operation</returns>
    [HttpGet("Top_5_most_diseases")]
    public async Task<IActionResult> GetTopFiveDisease()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Information about the top 5 most common diseases among patients");
        var requestTopDiseases = await (from reception in context.Receptions
                                        where reception.Conclusion != ""
                                        orderby reception.Conclusion
                                        select reception.Conclusion).Take(5).ToListAsync();
        return Ok(requestTopDiseases);
    }
    /// <summary>
    /// Display information about patients over the age of 30 who have an appointment with several doctors, arrange by date of birth
    /// </summary>
    /// <returns>Code of operation</returns>
    [HttpGet("Patients_over_30")]
    public async Task<IActionResult> GetPatientsOverThirty()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Information patients over the age of 30 who have an appointment with several doctors, arrange by date of birth");
        var requestPatientsAndSeveralDoctors = await (from patient in context.Patients
                                                      join reception in context.Receptions on patient.Id equals reception.PatientId
                                                      where patient.Receptions.Count > 1
                                                      select new
                                                      {
                                                          count = patient.Receptions.Count,
                                                          fio = patient.Fio,
                                                          birthDate = patient.BirthDate
                                                      }).ToListAsync();
        var requestOlderPatients = (from patient in requestPatientsAndSeveralDoctors
                                    where DateTime.Today.Year - patient.birthDate.Year > 30
                                    select patient).Distinct().ToList();
        return Ok(requestOlderPatients);
    }
}
