using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Policlinic;
using PoliclinicServer.Dto;
using PoliclinicServer.Repository;

namespace PoliclinicServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly ILogger<DoctorController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    private readonly IMapper _mapper;

    public DoctorController(ILogger<DoctorController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }

    // GET: api/<DoctorController>
    [HttpGet]
    public IEnumerable<DoctorGetDto> Get()
    {
        return _policlinicRepository.Doctors.Select(doctor => _mapper.Map<DoctorGetDto>(doctor));
        //return _mapper.ProjectTo<DoctorGetDto>(_policlinicRepository.CreateDefaultDoctors.Select(doctor => ))
    }

    // GET api/<DoctorController>/5
    [HttpGet("{id}")]
    public ActionResult<DoctorGetDto> Get(int id)
    {
        var doctor = _policlinicRepository.Doctors.FirstOrDefault(doctor => doctor.IdDoctor == id);
        if (doctor == null)
        {
            _logger.LogInformation("Not found doctor with id {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get doctor with id {0}", id);
            return Ok(_mapper.Map<DoctorGetDto>(doctor));
        }
    }

    // POST api/<DoctorController>
    [HttpPost]
    public void Post([FromBody] DoctorPostDto doctor)
    {
        _policlinicRepository.Doctors.Add(_mapper.Map<Doctor>(doctor));
    }

    // PUT api/<DoctorController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DoctorPostDto doctorToPut)
    {
        var doctor = _policlinicRepository.Doctors.FirstOrDefault(doctor => doctor.IdDoctor == id);
        if (doctor == null)
        {
            _logger.LogInformation("Not found doctor with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(doctorToPut, doctor);
            return Ok();
        }
    }

    // DELETE api/<DoctorController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var doctor = _policlinicRepository.Doctors.FirstOrDefault(doctor => doctor.IdDoctor == id);
        if (doctor == null)
        {
            _logger.LogInformation("Not found doctor with id {0}", id);
            return NotFound();
        }
        else
        {
            _policlinicRepository.Doctors.Remove(doctor);
            return Ok();
        }
    }
}
