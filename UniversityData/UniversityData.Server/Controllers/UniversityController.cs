using UniversityData.Domain;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
using AutoMapper;

namespace UniversityData.Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UniversityController : ControllerBase
{
    private readonly ILogger<UniversityController> _logger;
    private readonly IUniversityDataRepository _universityDataRepository;
    private readonly IMapper _mapper;
    public UniversityController(ILogger<UniversityController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<UniversityGetDto> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.Universities.Select(university => _mapper.Map<UniversityGetDto>(university));
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
            return Ok(_mapper.Map<UniversityGetDto>(university));
        }
    }

    [HttpPost]
    public void Post([FromBody] UniversityPostDto university)
    {
        _universityDataRepository.Universities.Add(_mapper.Map<University>(university));
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
            _mapper.Map<UniversityPostDto, University>(universityToPut, university);
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