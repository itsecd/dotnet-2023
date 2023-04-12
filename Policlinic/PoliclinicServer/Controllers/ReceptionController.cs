using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Policlinic;
using PoliclinicServer.Dto;
using PoliclinicServer.Repository;

namespace PoliclinicServer.Controllers;
/// <summary>
/// Reception controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ReceptionController : ControllerBase
{
    private readonly ILogger<ReceptionController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor for ReceptionController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="policlinicRepository"></param>
    /// <param name="mapper"></param>
    public ReceptionController(ILogger<ReceptionController> logger, IPoliclinicRepository policlinicRepository, IMapper mapper)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get reception info
    /// </summary>
    /// <returns>List of all receptions</returns>
    [HttpGet]
    public IEnumerable<ReceptionDto> Get()
    {
        return _policlinicRepository.Receptions.Select(reception => _mapper.Map<ReceptionDto>(reception));
    }

    /// <summary>
    /// Get reception info by id
    /// </summary>
    /// <param name="id">Reception's id</param>
    /// <returns>Reception with given id</returns>
    [HttpGet("{id}")]
    public ActionResult<ReceptionDto> Get(int id)
    {
        var reception = _policlinicRepository.Receptions.FirstOrDefault(reception => reception.Id == id);
        if (reception == null)
        {
            _logger.LogInformation("Not found reception with id {0}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get reception with id {0}", id);
            return Ok(_mapper.Map<ReceptionDto>(reception));
        }
    }

    /// <summary>
    /// Post a new reception
    /// </summary>
    /// <param name="reception">ReceptionDto's typed reception</param>
    [HttpPost]
    public void Post([FromBody] ReceptionDto reception)
    {
        _policlinicRepository.Receptions.Add(_mapper.Map<Reception>(reception));
    }

    /// <summary>
    /// Put reception
    /// </summary>
    /// <param name="id">Reception's id</param>
    /// <param name="receptionToPut">ReceptionDto's typed reception</param>
    /// <returns>Code of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ReceptionDto receptionToPut)
    {
        var reception = _policlinicRepository.Receptions.FirstOrDefault(reception => reception.Id == id);
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

    /// <summary>
    /// Delete reception by id
    /// </summary>
    /// <param name="id">Reception's id</param>
    /// <returns>Code of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var reception = _policlinicRepository.Receptions.FirstOrDefault(reception => reception.Id == id);
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
