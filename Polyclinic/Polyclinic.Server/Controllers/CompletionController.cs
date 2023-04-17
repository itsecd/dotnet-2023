using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyclinic.Domain;
using Polyclinic.Server.Dto;
using Polyclinic.Server.Repository;

namespace Polyclinic.Server.Controllers;

/// <summary>
/// Completion controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompletionController : ControllerBase
{
    private readonly ILogger<CompletionController> _logger;
    private readonly IPolyclinicRepository _polyclinicRepository;
    private readonly IMapper _mapper;
    public CompletionController(ILogger<CompletionController> logger, IPolyclinicRepository polyclinicRepository, IMapper mapper)
    {
        _logger = logger;
        _polyclinicRepository = polyclinicRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get completions
    /// </summary>
    /// <returns>completions</returns>
    [HttpGet]
    public IEnumerable<Completion> Get()
    {
        _logger.LogInformation("Get completion");
        return _polyclinicRepository.Completions;
    }

    /// <summary>
    /// Get completion by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>completion</returns>
    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        var completion = _polyclinicRepository.Completions.FirstOrDefault(completion => completion.Id == id);
        if (completion == null)
        {
            _logger.LogInformation($"Not found completion: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get completion with id {id}");
            return Ok(completion);
        }
    }


    /// <summary>
    /// Post completion
    /// </summary>
    /// <param name="completion"></param>
    [HttpPost]
    public void Post([FromBody] CompletionPostDto completion)
    {
        _logger.LogInformation("Post completion");
        _polyclinicRepository.Completions.Add(_mapper.Map<Completion>(completion));
    }

    /// <summary>
    /// Put copletion by ID
    /// </summary>
    /// <param name="id"></param>
    /// <param name="completionToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CompletionPostDto completionToPut)
    {
        var completion = _polyclinicRepository.Completions.FirstOrDefault(completion => completion.Id == id);
        if (completion == null)
        {
            _logger.LogInformation($"Not found completion: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put completion with id {id}");
            _mapper.Map(completionToPut, completion);
            return Ok();
        }
    }

    /// <summary>
    /// Delete completion by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var completion = _polyclinicRepository.Completions.FirstOrDefault(completion => completion.Id == id);
        if (completion == null)
        {
            _logger.LogInformation($"Not found completion: {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Put completion with id {id}");
            _polyclinicRepository.Completions.Remove(completion);
            return Ok();
        }
    }
}
