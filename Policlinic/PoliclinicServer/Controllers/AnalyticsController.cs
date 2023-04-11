using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PoliclinicServer.Dto;
using PoliclinicServer.Repository;
namespace PoliclinicServer.Controllers;

/// <summary>
/// Analytics controller for queries
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;
    private readonly IPoliclinicRepository _policlinicRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor for AnalyticsController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="policlinicRepository"></param>
    /// <param name="mapper"></param>
    public AnalyticsController(ILogger<AnalyticsController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Display information about all doctors whose work experience is at least 10 years
    /// </summary>
    [HttpGet("Doctors_10_years")]
    public List<DoctorGetDto> GetDoctors()
    {
        _logger.LogInformation("Doctors whose work experience is at least 10 years");
        return (from doctor in _policlinicRepository.Doctors
                where doctor.WorkExperience >= 10
                select _mapper.Map<DoctorGetDto>(doctor)).ToList();
    }

    /// <summary>
    /// Display information about all patients who have made an appointment with the specified doctor, arrange by name
    /// </summary>
    [HttpGet("Patients_with_the_specified_doctor")]
    public IActionResult GetPatients(int id)
    {
        _logger.LogInformation("Patients who have made an appointment with the specified doctor");
        var requestPatientList = (from patient in _policlinicRepository.Patients
                                  join reception in _policlinicRepository.Receptions on patient.Id equals reception.PatientId
                                  join doctor in _policlinicRepository.Doctors on reception.DoctorId equals doctor.Id
                                  where reception.DoctorId == id
                                  orderby patient.Fio
                                  select patient.Fio).ToList();
        if (requestPatientList.Count == 0) return NotFound();
        else return Ok(requestPatientList);
    }
    /// <summary>
    /// Display information about currently healthy patients
    /// </summary>
    [HttpGet("Currently_healthy_patients")]
    public IActionResult GetHealthyPatients()
    {
        _logger.LogInformation("Currently healthy patients");
        var requestHealthyPatientList = (from patient in _policlinicRepository.Patients
                                         join reception in _policlinicRepository.Receptions on patient.Id equals reception.PatientId
                                         where reception.Status == "Healthy"
                                         select patient).Distinct().ToList();
        if (requestHealthyPatientList.Count == 0) return NotFound();
        else return Ok(requestHealthyPatientList);
    }
    /// <summary>
    /// Display information about the number of patient appointments by doctors for the last month
    /// </summary>
    [HttpGet("The_number_of_patient_for_the_last_month")]
    public IActionResult GetCountByDoctors()
    {
        _logger.LogInformation("Information about the number of patient appointments by doctors for the last month");
        var requestCountReceptionsInOneMonth = (from doctor in _policlinicRepository.Doctors
                                                join reception in _policlinicRepository.Receptions on doctor.Id equals reception.DoctorId
                                                where reception.DateAndTime > new DateTime(2023, 1, 31) && reception.DateAndTime < new DateTime(2023, 3, 1)
                                                orderby doctor.Receptions.Count descending
                                                select new
                                                {
                                                    count = doctor.Receptions.Count,
                                                    key = doctor.Fio
                                                }).Distinct().ToList();
        if (requestCountReceptionsInOneMonth.Count == 0) return NotFound();
        else return Ok(requestCountReceptionsInOneMonth);
    }
    /// <summary>
    /// Display information about the top 5 most common diseases among patients
    /// </summary>
    [HttpGet("Top_5_most_diseases")]
    public IActionResult GetTopFiveDisease()
    {
        _logger.LogInformation("Information about the top 5 most common diseases among patients");
        var requestTopDiseases = (from reception in _policlinicRepository.Receptions
                                  where reception.Conclusion != ""
                                  orderby reception.Conclusion
                                  select reception.Conclusion).Take(5).ToList();
        if (requestTopDiseases.Count == 0) return NotFound();
        else return Ok(requestTopDiseases);
    }
    /// <summary>
    /// Display information about patients over the age of 30 who have an appointment with several doctors, arrange by date of birth
    /// </summary>
    [HttpGet("Patients_over_30")]
    public IActionResult GetPatientsOverThirty()
    {
        _logger.LogInformation("Information patients over the age of 30 who have an appointment with several doctors, arrange by date of birth");
        var requestPatientsAndSeveralDoctors = (from patient in _policlinicRepository.Patients
                                                join reception in _policlinicRepository.Receptions on patient.Id equals reception.PatientId
                                                where patient.Receptions.Count > 1
                                                select new
                                                {
                                                    count = patient.Receptions.Count,
                                                    fio = patient.Fio,
                                                    birthDate = patient.BirthDate
                                                }).ToList();
        var requestOlderPatients = (from patient in requestPatientsAndSeveralDoctors
                                    where DateTime.Today.Year - patient.birthDate.Year > 30
                                    select patient).Distinct().ToList();
        if (requestOlderPatients.Count == 0) return NotFound();
        else return Ok(requestOlderPatients);
    }
}
