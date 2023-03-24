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

    [HttpGet]
    public IEnumerable<EntrantGetDto> Get()
    {
        return _admissionCommitteeRepository.Entrants.Select(entrant => _mapper.Map<EntrantGetDto>(entrant));
    }

    [HttpGet("{id}")]
    public ActionResult<Entrant> Get(int id)
    {
        var entrant = _admissionCommitteeRepository.Entrants.FirstOrDefault(entrant => entrant.IdEntrant == id);
        if (entrant == null)
        {
            _logger.LogInformation("Not found entrant : {id}", id);
            return NotFound($"The entrant does't exist by this id {id}");
        }
        else
        {
            return Ok(_mapper.Map<EntrantGetDto>(entrant));
        }
    }

    [HttpPost]
    public void Post([FromBody] EntrantPostDto entrant)
    {
        _admissionCommitteeRepository.Entrants.Add(_mapper.Map<Entrant>(entrant));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] EntrantPostDto entrantToPut)
    {
        var entrant = _admissionCommitteeRepository.Entrants.FirstOrDefault(entrant => entrant.IdEntrant == id);
        if (entrant == null)
        {
            _logger.LogInformation("Not found entrant : {id}", id);
            return NotFound($"The entrant does't exist by this id {id}");
        }
        else
        {
            _mapper.Map(entrantToPut, entrant);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entrant = _admissionCommitteeRepository.Entrants.FirstOrDefault(entrant => entrant.IdEntrant == id);
        if (entrant == null)
        {
            _logger.LogInformation($"Not found entrant : {id}");
            return NotFound($"The entrant does't exist by this id {id}");
        }
        else
        {
            _admissionCommitteeRepository.Entrants.Remove(entrant);
            return Ok();
        }
    }
}
