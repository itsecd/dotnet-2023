using UniversityData.Domain;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Dto;
namespace UniversityData.Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly ILogger<UniversityController> _logger;
    private readonly IUniversityDataRepository _universityDataRepository;
    public UniversityController(ILogger<UniversityController> logger, IUniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<UniversityGetDto> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Universities.Select(university =>
        new UniversityGetDto
        {
            Id = university.Id,
            Name = university.Name,
            Number = university.Number,
            Address = university.Address,
            RectorId = university.RectorId,
            UniversityProperty = university.UniversityProperty,
            ConstructionProperty = university.ConstructionProperty
        });
    }

    [HttpGet("{id}")]
    public ActionResult<UniversityGetDto?> Get(int id)
    {
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation($"Not found university with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get university with id {id}");
            return Ok(new UniversityGetDto
            {
                Id = university.Id,
                Name = university.Name,
                Number = university.Number,
                Address = university.Address,
                RectorId = university.RectorId,
                UniversityProperty = university.UniversityProperty,
                ConstructionProperty = university.ConstructionProperty
            });
        }
    }

    [HttpPost]
    public void Post([FromBody] UniversityPostDto university)
    {
        _universityDataRepository.Universities.Add(new University()
        {
            Number = university.Number,
            Address = university.Address,
            Name = university.Name,
            RectorId = university.RectorId,
            UniversityProperty = university.UniversityProperty,
            ConstructionProperty = university.ConstructionProperty
        });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UniversityPostDto universityToPut)
    {
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation($"Not found university with id: {id}");
            return NotFound();
        }
        else
        {
            university.Number = universityToPut.Number;
            university.Name = universityToPut.Name;
            university.Address = universityToPut.Address;
            university.RectorId = universityToPut.RectorId;
            university.ConstructionProperty = universityToPut.ConstructionProperty;
            university.UniversityProperty = universityToPut.UniversityProperty;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var university = _universityDataRepository.Universities.FirstOrDefault(university => university.Id == id);
        if (university == null)
        {
            _logger.LogInformation($"Not found university with id: {id}");
            return NotFound();
        }
        else
        {
           _universityDataRepository.Universities.Remove(university);
            return Ok();
        }
    }
}