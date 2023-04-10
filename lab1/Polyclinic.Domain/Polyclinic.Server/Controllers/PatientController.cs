using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;
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

    // GET: api/<PatientController>
    [HttpGet]
    public IEnumerable<PatientGetDto> Get()
    {
        _logger.LogInformation("Get Patients");
        return _polyclinicRepository.Patients.Select(patient => _mapper.Map<PatientGetDto>(patient));
    }

    // GET api/<PatientController>/5
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

    // POST api/<PatientController>
    [HttpPost]
    public void Post([FromBody] PatientPostDto patient)
    {
        _polyclinicRepository.Patients.Add(_mapper.Map<Patient>(patient));
    }

    // PUT api/<PatientController>/5
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

    // DELETE api/<PatientController>/5
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
