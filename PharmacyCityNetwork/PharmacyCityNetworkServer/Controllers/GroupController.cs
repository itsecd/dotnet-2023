using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public GroupController(ILogger<GroupController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<GroupGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.Groups.Select(group => _mapper.Map<GroupGetDto>(group));
    }

    [HttpGet("{id}")]
    public ActionResult<Group> Get(int id)
    {
        var group = _pharmacyCityNetworkRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation($"Not found group: {id}");
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<GroupGetDto>(group));
        }
    }

    [HttpPost]
    public void Post([FromBody] GroupPostDto group)
    {
        _pharmacyCityNetworkRepository.Groups.Add(_mapper.Map<Group>(group));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GroupPostDto groupToPut)
    {
        var group = _pharmacyCityNetworkRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation("Not found group: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(groupToPut, group);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var group = _pharmacyCityNetworkRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation($"Not found group: {id}");
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.Groups.Remove(group);
            return Ok();
        }
    }
}