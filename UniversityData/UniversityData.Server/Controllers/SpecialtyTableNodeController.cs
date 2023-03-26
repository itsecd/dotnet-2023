using UniversityData.Domain;
using UniversityData.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Server.Repository;
using AutoMapper;

namespace UniversityData.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialtyTableNodeController : ControllerBase
{
    private readonly ILogger<SpecialtyTableNodeController> _logger;
    private readonly IUniversityDataRepository _universityDataRepository;
    private readonly IMapper _mapper;
    public SpecialtyTableNodeController(ILogger<SpecialtyTableNodeController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<SpecialtyTableNodeGetDto> Get()
    {
        _logger.LogInformation("Get all departments");
        return _universityDataRepository.SpecialtyTableNodes.Select(specialtyTableNode => _mapper.Map<SpecialtyTableNodeGetDto>(specialtyTableNode));
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
            return Ok(_mapper.Map<SpecialtyTableNodeGetDto>(specialtyTableNode));
        }
    }

    [HttpPost]
    public void Post([FromBody] SpecialtyTableNodePostDto specialtyTableNode)
    {
        _universityDataRepository.SpecialtyTableNodes.Add(_mapper.Map<SpecialtyTableNode>(specialtyTableNode));
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SpecialtyTableNodePostDto specialtyTableNodeToPut)
    {
        var specialtyTableNode = _universityDataRepository.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            _mapper.Map<SpecialtyTableNodePostDto, SpecialtyTableNode>(specialtyTableNodeToPut, specialtyTableNode);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var specialtyTableNode = _universityDataRepository.SpecialtyTableNodes.FirstOrDefault(specialtyTableNode => specialtyTableNode.Id == id);
        if (specialtyTableNode == null)
        {
            _logger.LogInformation($"Not found specialtyTableNode with id: {id}");
            return NotFound();
        }
        else
        {
            _universityDataRepository.SpecialtyTableNodes.Remove(specialtyTableNode);
            return Ok();
        }
    }
}