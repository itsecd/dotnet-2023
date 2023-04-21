using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;

    private readonly IPharmacyCityNetworkRepository _groupsRepository;
    public GroupController(ILogger<GroupController> logger, IPharmacyCityNetworkRepository groupsRepository)
    {
        _logger = logger;
        _groupsRepository = groupsRepository;
    }
    [HttpGet]
    public IEnumerable<Group> Get()
    {
        return _groupsRepository.Groups;
    }

    [HttpGet("{id}")]
    public ActionResult<Group> Get(int id) 
    {
        var group = _groupsRepository.Groups.FirstOrDefault(group => group.Id == id);
        if (group == null)
        {
            _logger.LogInformation($"Not found group: {id}");
            return NotFound();
        }
        else
        {
            return Ok(group);

        }
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}