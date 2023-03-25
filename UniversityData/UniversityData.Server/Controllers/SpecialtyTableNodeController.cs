using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialtyTableNodeController : ControllerBase
{
    private readonly ILogger<SpecialtyTableNodeController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public SpecialtyTableNodeController(ILogger<SpecialtyTableNodeController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<SpecialtyTableNodeGetDto> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.SpecialtyTableNodes.Select(specialtyTableNode =>
        new SpecialtyTableNodeGetDto
        {
            Id= specialtyTableNode.Id,
            SpecialtyID = specialtyTableNode.SpecialtyID,
            CountGroups = specialtyTableNode.CountGroups,
            UniversityId = specialtyTableNode.UniversityId
        });
    }

    [HttpGet("{id}")]
    public ActionResult<SpecialtyTableNodeGetDto?> Get(int id)
    {
        var specialtyTableNode = _universityDataRepository.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialtyTableNode with id {id}");
            return Ok(new SpecialtyTableNodeGetDto
            {
                Id = specialtyTableNode.Id,
                SpecialtyID = specialtyTableNode.SpecialtyID,
                CountGroups = specialtyTableNode.CountGroups,
                UniversityId = specialtyTableNode.UniversityId
            });
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