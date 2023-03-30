using AutoMapper;
using LibrarySchool;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Subject. Defined methods: Get
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ILogger<SubjectController> _logger;
    private readonly ILibrarySchoolRepository _librarySchoolRepository;
    private readonly IMapper _mapper;
    /// <summary>
    /// Constructor controller subject
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librarySchoolRepository"></param>
    /// <param name="mapper"></param>
    public SubjectController(ILogger<SubjectController> logger, ILibrarySchoolRepository librarySchoolRepository, IMapper mapper)
    {
        _logger = logger;
        _librarySchoolRepository = librarySchoolRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Get list subject
    /// </summary>
    /// <returns>
    /// Return list subject
    /// </returns>
    [HttpGet]
    public IEnumerable<Subject> Get()
    {
        _logger.LogInformation("Get list subjects");
        return _librarySchoolRepository.Subjects;
    }

    /// <summary>
    /// Get subject with certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: Subject with certain Id
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<Subject> Get(int id)
    {
        var foundSubject = _librarySchoolRepository.Subjects.FirstOrDefault(subject => subject.SubjectId == id);
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject {id}", id);
            return NotFound();
        }
        return Ok(foundSubject);
    }

    /// <summary>
    /// Create new Subject
    /// </summary>
    /// <param name="subjectPostDto"></param>
    [HttpPost]
    public void Post([FromBody] SubjectPostDto subjectPostDto)
    {
        _librarySchoolRepository.Subjects.Add(_mapper.Map<Subject>(subjectPostDto));
    }

    /// <summary>
    /// Change information of a Subject by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="subjectPostDto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SubjectPostDto subjectPostDto)
    {
        var foundSubject = _librarySchoolRepository.Subjects.FirstOrDefault(subject => subject.SubjectId == id);
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject {id}", id);
            return NotFound();
        }
        _mapper.Map(subjectPostDto, foundSubject);
        return Ok();
    }

    /// <summary>
    /// Delete a subject by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var foundSubject = _librarySchoolRepository.Subjects.FirstOrDefault(subject => subject.SubjectId == id);
        if (foundSubject == null)
        {
            _logger.LogInformation("Not found subject {id}", id);
            return NotFound();
        }
        _librarySchoolRepository.Subjects.Remove(foundSubject);
        return Ok();
    }
}
