using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PoliclinicServer.Repository;
using PoliclinicServer.Dto;
using Policlinic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoliclinicServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    private readonly IMapper _mapper;

    public PatientController(ILogger<PatientController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }
    // GET: api/<PatientController>
    [HttpGet]
    public IEnumerable<PatientGetDto> Get()
    {
        return _policlinicRepository.Patients.Select(patient => _mapper.Map<PatientGetDto>(patient));
        //return _mapper.ProjectTo<DoctorGetDto>(_policlinicRepository.CreateDefaultDoctors.Select(doctor => ))
    }

    // GET api/<PatientController>/5
    [HttpGet("{id}")]
    public ActionResult<PatientGetDto> Get(int id)
    {
        var patient = _policlinicRepository.Patients.FirstOrDefault(patient => patient.IdPatient == id);
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

    // POST api/<PatientController>
    [HttpPost]
    public void Post([FromBody] PatientPostDto patient)
    {
        _policlinicRepository.Patients.Add(_mapper.Map<Patient>(patient));
    }

    // PUT api/<PatientController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PatientPostDto patientToPut)
    {
        var patient = _policlinicRepository.Patients.FirstOrDefault(patientToPut => patientToPut.IdPatient == id);
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

    // DELETE api/<PatientController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var patient = _policlinicRepository.Patients.FirstOrDefault(patient => patient.IdPatient == id);
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
