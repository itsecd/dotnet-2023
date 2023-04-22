using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PharmaGroupController : ControllerBase
{
    private readonly ILogger<PharmaGroupController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmaGroupsRepository;
    private readonly IMapper _mapper;
    public PharmaGroupController(ILogger<PharmaGroupController> logger, IPharmacyCityNetworkRepository pharmaGroupsRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmaGroupsRepository = pharmaGroupsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<PharmaGroupGetDto> Get()
    {
        return _pharmaGroupsRepository.PharmaGroups.Select(pharmaGroup => _mapper.Map<PharmaGroupGetDto>(pharmaGroup));
    }

    [HttpGet("{id}")]
    public ActionResult<PharmaGroup> Get(int id)
    {
        var pharmaGroup = _pharmaGroupsRepository.PharmaGroups.FirstOrDefault(pharmaGroup => pharmaGroup.Id == id);
        if (pharmaGroup == null)
        {
            _logger.LogInformation($"Not found pharmacy: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<PharmaGroupGetDto>(pharmaGroup));
        }
    }

    [HttpPost]
    public void Post([FromBody] PharmaGroupPostDto pharmaGroup)
    {
        _pharmaGroupsRepository.PharmaGroups.Add(_mapper.Map<PharmaGroup>(pharmaGroup));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PharmaGroupPostDto pharmaGroupToPut)
    {
        var pharmaGroup = _pharmaGroupsRepository.PharmaGroups.FirstOrDefault(pharmaGroup => pharmaGroup.Id == id);
        if (pharmaGroup == null)
        {
            _logger.LogInformation("Not found pharmacy: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(pharmaGroupToPut, pharmaGroup);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pharmaGroup = _pharmaGroupsRepository.PharmaGroups.FirstOrDefault(pharmaGroup => pharmaGroup.Id == id);
        if (pharmaGroup == null)
        {
            _logger.LogInformation($"Not found pharmacy: {id}");
            return NotFound();
        }
        else
        {
            _pharmaGroupsRepository.PharmaGroups.Remove(pharmaGroup);
            return Ok();
        }
    }
}