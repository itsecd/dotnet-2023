using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Policlinic;
using PoliclinicServer.Dto;
using PoliclinicServer.Repository;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Doctor controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly ILogger<DoctorController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for DoctorController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="policlinicRepository"></param>
    /// <param name="mapper"></param>
    public DoctorController(ILogger<DoctorController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get doctor info
    /// </summary>
    /// <returns>List of all doctors</returns>
    [HttpGet]
    public IEnumerable<DoctorGetDto> Get()
    {
        return _policlinicRepository.Doctors.Select(doctor => _mapper.Map<DoctorGetDto>(doctor));
    }

    /// <summary>
    /// Get doctor info by id
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <returns>Doctor with given id</returns>
    [HttpGet("{id}")]
    public ActionResult<DoctorGetDto> Get(int id)
    {
        var doctor = _policlinicRepository.Doctors.FirstOrDefault(doctor => doctor.Id == id);
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

    /// <summary>
    /// Post a new doctor
    /// </summary>
    /// <param name="doctor">DoctorPostDto's typed doctor</param>
    [HttpPost]
    public void Post([FromBody] DoctorPostDto doctor)
    {
        _policlinicRepository.Doctors.Add(_mapper.Map<Doctor>(doctor));
    }

    /// <summary>
    /// Put doctor
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <param name="doctorToPut">DoctorPostDto's typed doctor</param>
    /// <returns>Code of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DoctorPostDto doctorToPut)
    {
        var doctor = _policlinicRepository.Doctors.FirstOrDefault(doctor => doctor.Id == id);
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

    /// <summary>
    /// Delete doctor by id
    /// </summary>
    /// <param name="id">Doctor's id</param>
    /// <returns>Code of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var doctor = _policlinicRepository.Doctors.FirstOrDefault(doctor => doctor.Id == id);
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
