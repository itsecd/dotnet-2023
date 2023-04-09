using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Policlinic;
using PoliclinicServer.Dto;
using PoliclinicServer.Repository;

namespace PoliclinicServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReceptionController : ControllerBase
{
    private readonly ILogger<ReceptionController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    private readonly IMapper _mapper;

    public ReceptionController(ILogger<ReceptionController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }

    // GET: api/<DoctorController>
    [HttpGet]
    public IEnumerable<ReceptionGetDto> Get()
    {
        return _policlinicRepository.Receptions.Select(reception => _mapper.Map<ReceptionGetDto>(reception));
        //return _mapper.ProjectTo<DoctorGetDto>(_policlinicRepository.CreateDefaultDoctors.Select(doctor => ))
    }

    // GET api/<DoctorController>/5
    [HttpGet("{id}")]
    public ActionResult<ReceptionGetDto> Get(int id)
    {
        var reception = _policlinicRepository.Receptions.FirstOrDefault(reception => reception.IdReception == id);
        if (reception == null)
        {
            _logger.LogInformation("Not found reception with id {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get reception with id {0}", id);
            return Ok(_mapper.Map<ReceptionGetDto>(reception));
        }
    }

    // POST api/<DoctorController>
    [HttpPost]
    public void Post([FromBody] ReceptionPostDto reception)
    {
        _policlinicRepository.Receptions.Add(_mapper.Map<Reception>(reception));
    }

    // PUT api/<DoctorController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ReceptionPostDto receptionToPut)
    {
        var reception = _policlinicRepository.Receptions.FirstOrDefault(reception => reception.IdReception == id);
        if (reception == null)
        {
            _logger.LogInformation("Not found reception with id {0}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(receptionToPut, reception);
            return Ok();
        }
    }

    // DELETE api/<DoctorController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var reception = _policlinicRepository.Receptions.FirstOrDefault(reception => reception.IdReception == id);
        if (reception == null)
        {
            _logger.LogInformation("Not found reception with id {0}", id);
            return NotFound();
        }
        else
        {
            _policlinicRepository.Receptions.Remove(reception);
            return Ok();
        }
    }
}
