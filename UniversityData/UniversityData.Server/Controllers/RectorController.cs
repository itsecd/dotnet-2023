using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RectorController : ControllerBase
{
    private readonly ILogger<RectorController> _logger;
    private readonly UniversityDataRepository _universityDataRepository;
    public RectorController(ILogger<RectorController> logger, UniversityDataRepository universityDataRepository)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
    }

    [HttpGet]
    public IEnumerable<Rector> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Rectors;
    }

    [HttpGet("{id}")]
    public ActionResult<Rector?> Get(int id)
    {
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get rector with id {id}");
            return Ok(rector);
        }  
    }

    [HttpPost]
    public void Post([FromBody] RectorPostDto rector)
    {
        _universityDataRepository.Rectors.Add(new Rector()
        {
            Name = rector.Name,
            Surname = rector.Surname,
            Patronymic = rector.Patronymic,
            Degree = rector.Degree,
            Title = rector.Title,
            Position = rector.Position,
            UniversityiId = rector.UniversityiId
        });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] RectorPostDto rectorToPut)
    {
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }
        else
        {
            rector.Surname = rectorToPut.Surname;
            rector.Name = rectorToPut.Name;
            rector.Patronymic = rectorToPut.Patronymic;
            rector.UniversityiId = rectorToPut.UniversityiId;
            rector.Degree = rectorToPut.Degree;
            rector.Title = rectorToPut.Title;
            rector.Position = rectorToPut.Position;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
