using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyCityNetwork.Server.Dto;
using PharmacyCityNetwork.Server.Repository;

namespace PharmacyCityNetwork.Server.Controllers;
/// <summary>
/// PharmaGroup controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PharmaGroupController : ControllerBase
{
    private readonly ILogger<PharmaGroupController> _logger;

    private readonly IPharmacyCityNetworkRepository _pharmacyCityNetworkRepository;
    private readonly IMapper _mapper;
    public PharmaGroupController(ILogger<PharmaGroupController> logger, IPharmacyCityNetworkRepository pharmacyCityNetworkRepository, IMapper mapper)
    {
        _logger = logger;
        _pharmacyCityNetworkRepository = pharmacyCityNetworkRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Get info about all pharmaGroups
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<PharmaGroupGetDto> Get()
    {
        return _pharmacyCityNetworkRepository.PharmaGroups.Select(pharmaGroup => _mapper.Map<PharmaGroupGetDto>(pharmaGroup));
    }
    /// <summary>
    /// Get pharmaGroup info by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PharmaGroup> Get(int id)
    {
        var pharmaGroup = _pharmacyCityNetworkRepository.PharmaGroups.FirstOrDefault(pharmaGroup => pharmaGroup.Id == id);
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
    /// <summary>
    /// Post a new pharmaGroup
    /// </summary>
    /// <param name="pharmaGroup"></param>
    [HttpPost]
    public void Post([FromBody] PharmaGroupPostDto pharmaGroup)
    {
        _pharmacyCityNetworkRepository.PharmaGroups.Add(_mapper.Map<PharmaGroup>(pharmaGroup));
    }
    /// <summary>
    /// Put pharmaGroup
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pharmaGroupToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PharmaGroupPostDto pharmaGroupToPut)
    {
        var pharmaGroup = _pharmacyCityNetworkRepository.PharmaGroups.FirstOrDefault(pharmaGroup => pharmaGroup.Id == id);
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
    /// <summary>
    /// Delete a pharmaGroup
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pharmaGroup = _pharmacyCityNetworkRepository.PharmaGroups.FirstOrDefault(pharmaGroup => pharmaGroup.Id == id);
        if (pharmaGroup == null)
        {
            _logger.LogInformation($"Not found pharmacy: {id}");
            return NotFound();
        }
        else
        {
            _pharmacyCityNetworkRepository.PharmaGroups.Remove(pharmaGroup);
            return Ok();
        }
    }
}