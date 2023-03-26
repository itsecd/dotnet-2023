using AutoMapper;
using LibrarySchool;
using LibrarySchoolServer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySchoolServer.Controllers;
/// <summary>
/// Controler for class Mark. Defined methods: Post, Put, Get, Delete
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class MarkController : Controller
{
    private readonly ILogger<ClassTypeController> _logger;
    private readonly ILibrarySchoolRepository _librarySchoolRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor class StudentController
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librarySchoolRepository"></param>
    /// <param name="mapper"></param>
    public MarkController(ILogger<ClassTypeController> logger, ILibrarySchoolRepository librarySchoolRepository, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _librarySchoolRepository = librarySchoolRepository;
    }
    /// <summary>
    /// Get list mark
    /// </summary>
    /// <returns>
    /// Return: list mark
    /// </returns>
    [HttpGet]
    public IEnumerable<Mark> Get()
    {
        _logger.LogInformation("Get list marks");
        return _librarySchoolRepository.Marks;
    }
    /// <summary>
    /// Get mark with certain id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: Ation result Ok if mark exist, NotFound if not exist
    /// </returns>
    [HttpGet("{id}")]
    public ActionResult<Mark> Get(int id)
    {
        var foundMark = _librarySchoolRepository.Marks.FirstOrDefault(mark => mark.MarkId == id);
        if (foundMark == null)
        {
            _logger.LogInformation("Not found mark {id}", id);
            return NotFound();
        }
        return Ok(foundMark);
    }

    /// <summary>
    /// Add new mark to respository
    /// </summary>
    /// <param name="markToPost"></param>
    [HttpPost]
    public void Post([FromBody] MarkPostDto markToPost)
    {
        _librarySchoolRepository.Marks.Add(_mapper.Map<Mark>(markToPost));
    }

    /// <summary>
    /// Change information of mark with certain Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="fixedMark"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if exist
    /// </returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] MarkPostDto fixedMark)
    {
        var markToFix = _librarySchoolRepository.Marks.FirstOrDefault(mark => mark.MarkId == id);
        if (fixedMark == null)
        {
            _logger.LogInformation("Not found mark {id}", id);
            return NotFound();
        }
        _mapper.Map(fixedMark, markToFix);
        return Ok();
    }

    /// <summary>
    /// Delete a mark with certain Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Return: IActionResult NotFound if not exist or Ok if student deleted
    /// </returns>

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var markToDelete = _librarySchoolRepository.Marks.FirstOrDefault(mark => mark.MarkId == id);
        if (markToDelete == null)
        {
            _logger.LogInformation("Not found mark {id}", id);
            return NotFound();
        }
        _librarySchoolRepository.Marks.Remove(markToDelete);
        return Ok();
    }
}
