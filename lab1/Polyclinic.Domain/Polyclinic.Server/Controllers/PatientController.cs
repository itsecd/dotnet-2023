using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Patient controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;
    private readonly IPolyclinicRepository _polyclinicRepository;
    private readonly IMapper _mapper;
    public PatientController(ILogger<PatientController> logger, IPolyclinicRepository polyclinicRepository, IMapper mapper)
    {
        _logger = logger;
        _polyclinicRepository = polyclinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get patients
    /// </summary>
    /// <returns>patients</returns>
    [HttpGet]
    public IEnumerable<PatientGetDto> Get()
    {
        _logger.LogInformation("Get Patients");
        return _polyclinicRepository.Patients.Select(patient => _mapper.Map<PatientGetDto>(patient));
    }

    /// <summary>
    /// Get patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>patient</returns>
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var patient = _polyclinicRepository.Patients.FirstOrDefault(patient => patient.Id == id);
        if (patient == null)
        {
            _logger.LogInformation($"Not found patient: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get patient with id {id}");
            return Ok(_mapper.Map<PatientGetDto>(patient));
        }
    }

    /// <summary>
    /// Post patient
    /// </summary>
    /// <param name="patient"></param>
    [HttpPost]
    public void Post([FromBody] PatientPostDto patient)
    {
        _polyclinicRepository.Patients.Add(_mapper.Map<Patient>(patient));
    }

    /// <summary>
    /// Put patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patientToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PatientPostDto patientToPut)
    {
        var patient = _polyclinicRepository.Patients.FirstOrDefault(patient => patient.Id == id);
        if (patient == null)
        {
            _logger.LogInformation($"Not found patient: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put patient with id {id}");
            _mapper.Map(patientToPut, patient);
            return Ok();
        }
    }

    /// <summary>
    /// Delete patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var patient = _polyclinicRepository.Patients.FirstOrDefault(patient => patient.Id == id);
        if (patient == null)
        {
            _logger.LogInformation($"Not found patient: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put patient with id {id}");
            _polyclinicRepository.Patients.Remove(patient);
            return Ok();
        }
    }
}
