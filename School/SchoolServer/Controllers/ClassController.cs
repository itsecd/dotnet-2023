using AutoMapper;
using SchoolServer.Dto;
using SchoolServer.Repository;
using Microsoft.AspNetCore.Mvc;
using School.Classes;

namespace SchoolServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly ILogger<ClassController> _logger;

    private readonly ISchoolRepository _diaryRepository;

    private readonly IMapper _mapper;

    public ClassController(ILogger<ClassController> logger, ISchoolRepository diaryRepository, IMapper mapper)
    {
        _logger = logger;
        _diaryRepository = diaryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ClassGetDto> Get()
    { 
        return _diaryRepository.Classes.Select(obj => _mapper.Map<ClassGetDto>(obj));
    }

    [HttpGet("{id}")]
    public ActionResult<Class> Get(int id)
    {
        var diaryClass = _diaryRepository.Classes.FirstOrDefault(obj => obj.Id == id);
        if (diaryClass == null) 
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(diaryClass);
        }
    }

    [HttpPost]
    public void Post([FromBody] ClassGetDto @class)
    {
        _diaryRepository.Classes.Add(_mapper.Map<Class>(@class));
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ClassPostDto @class)
    {
        var diaryClass = _diaryRepository.Classes.FirstOrDefault(obj => obj.Id == id);
        if (diaryClass == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(@class, diaryClass);
            return Ok();
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var diaryClass = _diaryRepository.Classes.FirstOrDefault(obj => obj.Id == id);
        if (diaryClass == null)
        {
            _logger.LogInformation("Not Found class with id = {id}", id);
            return NotFound();
        }
        else
        {
            _diaryRepository.Classes.Remove(diaryClass);
            return Ok();
        }
    }
    
}
