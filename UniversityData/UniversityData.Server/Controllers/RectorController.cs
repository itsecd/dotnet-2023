using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Repository;
using AutoMapper;

namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RectorController : ControllerBase
{
    private readonly ILogger<RectorController> _logger;
    private readonly IUniversityDataRepository _universityDataRepository;
    private readonly IMapper _mapper;
    public RectorController(ILogger<RectorController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
        _mapper = mapper;
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
        _universityDataRepository.Rectors.Add(_mapper.Map<Rector>(rector));
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
            _mapper.Map<RectorPostDto, Rector>(rectorToPut, rector);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var rector = _universityDataRepository.Rectors.FirstOrDefault(rector => rector.Id == id);
        if (rector == null)
        {
            _logger.LogInformation($"Not found rector with id: {id}");
            return NotFound();
        }
        else
        {
            _universityDataRepository.Rectors.Remove(rector);
            return Ok();
        }
    }
}
