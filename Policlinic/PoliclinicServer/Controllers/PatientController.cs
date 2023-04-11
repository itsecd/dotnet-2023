using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PoliclinicServer.Repository;
using PoliclinicServer.Dto;
using Policlinic;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Patient controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for PatientController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="policlinicRepository"></param>
    /// <param name="mapper"></param>
    public PatientController(ILogger<PatientController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get patient info
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<PatientGetDto> Get()
    {
        return _policlinicRepository.Patients.Select(patient => _mapper.Map<PatientGetDto>(patient));
    }

    /// <summary>
    /// Get patient info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PatientGetDto> Get(int id)
    {
        var patient = _policlinicRepository.Patients.FirstOrDefault(patient => patient.Id == id);
        if (patient == null)
        {
            _logger.LogInformation("Not found patient with id {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get patient with id {0}", id);
            return Ok(_mapper.Map<PatientGetDto>(patient));
        }
    }

    /// <summary>
    /// Post a new patient
    /// </summary>
    /// <param name="patient"></param>
    [HttpPost]
    public void Post([FromBody] PatientPostDto patient)
    {
        _policlinicRepository.Patients.Add(_mapper.Map<Patient>(patient));
    }

    /// <summary>
    /// Put patient
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patientToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PatientPostDto patientToPut)
    {
        var patient = _policlinicRepository.Patients.FirstOrDefault(patientToPut => patientToPut.Id == id);
        if (patient == null)
        {
            _logger.LogInformation("Not found patient with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(patientToPut, patient);
            return Ok();
        }
    }

    /// <summary>
    /// Delete patient by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var patient = _policlinicRepository.Patients.FirstOrDefault(patient => patient.Id == id);
        if (patient == null)
        {
            _logger.LogInformation("Not found doctor with id {0}", id);
            return NotFound();
        }
        else
        {
            _policlinicRepository.Patients.Remove(patient);
            return Ok();
        }
    }
}
