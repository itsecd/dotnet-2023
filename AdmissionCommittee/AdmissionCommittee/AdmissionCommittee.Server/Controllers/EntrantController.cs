using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EntrantController : ControllerBase
{
    private readonly ILogger<EntrantController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public EntrantController(ILogger<EntrantController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all Entrants
    /// </summary>
    /// <returns> IEnumerable type EntrantGetDto </returns>
    [HttpGet("GetAllEntrants")]
    public IEnumerable<EntrantGetDto> Get()
    {
        _logger.LogInformation("Get all Entrants");
        return _admissionCommitteeRepository.GetEntrants.Select(entrant => _mapper.Map<EntrantGetDto>(entrant));
    }

    /// <summary>
    /// Get Entrant by id
    /// </summary>
    /// <param name="idEntrant">id entrant</param>
    /// <returns>EntrantGetDto with http code</returns>
    [HttpGet("GetEntrantById{idEntrant}")]
    public ActionResult<EntrantGetDto> Get(int idEntrant)
    {
        var entrant = _admissionCommitteeRepository.GetEntrants.FirstOrDefault(entrant => entrant.IdEntrant == idEntrant);
        if (entrant == null)
        {
            _logger.LogInformation("Not found Entrant : {idEntrant}", idEntrant);
            return NotFound($"The Entrant does't exist by this idEntrant {idEntrant}");
        }
        else
        {
            _logger.LogInformation("Get Entrant by {idEntrant}", idEntrant);
            return Ok(_mapper.Map<EntrantGetDto>(entrant));
        }
    }

    /// <summary>
    /// Create new Entrant
    /// </summary>
    /// <param name="entrant">new Entrant</param>
    [HttpPost("CreateEntrant")]
    public void Post([FromBody] EntrantPostDto entrant)
    {
        _logger.LogInformation("Create new Entrant");
        _admissionCommitteeRepository.GetEntrants.Add(_mapper.Map<Entrant>(entrant));
    }

    /// <summary>
    /// Update information about Entrant
    /// </summary>
    /// <param name="idEntrant">id Entrant</param>
    /// <param name="entrantToPut">Entrant that is updated</param>
    /// <returns></returns>
    [HttpPut("UpdateEntrantById{idEntrant}")]
    public IActionResult Put(int idEntrant, [FromBody] EntrantPostDto entrantToPut)
    {
        var entrant = _admissionCommitteeRepository.GetEntrants.FirstOrDefault(entrant => entrant.IdEntrant == idEntrant);
        if (entrant == null)
        {
            _logger.LogInformation("Not found Entrant : {idEntrant}", idEntrant);
            return NotFound($"The Entrant does't exist by this id {idEntrant}");
        }
        else
        {
            _logger.LogInformation("Update Entrant by id {idEntrant}", idEntrant);
            _mapper.Map(entrantToPut, entrant);
            return Ok();
        }
    }

    /// <summary>
    /// Delete by id Entrant
    /// </summary>
    /// <param name="idEntrant">id Entrant for delete</param>
    /// <returns>Ok or NotFound</returns>
    [HttpDelete("DeleteEntrantById{idEntrant}")]
    public IActionResult Delete(int idEntrant)
    {
        var entrant = _admissionCommitteeRepository.GetEntrants.FirstOrDefault(entrant => entrant.IdEntrant == idEntrant);
        if (entrant == null)
        {
            _logger.LogInformation($"Not found Entrant : {idEntrant}");
            return NotFound($"The entrant does't exist by this id {idEntrant}");
        }
        else
        {
            _logger.LogInformation("Delete Entrant by id {idEntrant}", idEntrant);
            _admissionCommitteeRepository.GetEntrants.Remove(entrant);
            return Ok();
        }
    }
}