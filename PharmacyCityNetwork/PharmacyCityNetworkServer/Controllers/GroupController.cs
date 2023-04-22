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

    private readonly IPharmacyCityNetworkRepository _groupsRepository;
    private readonly IMapper _mapper;
    public GroupController(ILogger<GroupController> logger, IPharmacyCityNetworkRepository groupsRepository, IMapper mapper)
    {
        _logger = logger;
        _groupsRepository = groupsRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<GroupGetDto> Get()
    {
        return _groupsRepository.Groups.Select(group => _mapper.Map<GroupGetDto>(group));
    }

    [HttpGet("{id}")]
    public ActionResult<Group> Get(int id)
    {
        var group = _groupsRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation($"Not found manufacturer: {id}");
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
        _groupsRepository.Groups.Add(_mapper.Map<Group>(group));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] GroupPostDto groupToPut)
    {
        var group = _groupsRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation("Not found manufacturer: {id}", id);
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
        var group = _groupsRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation($"Not found manufacturer: {id}");
            return NotFound();
        }
        else
        {
            _groupsRepository.Groups.Remove(group);
            return Ok();
        }
    }
}