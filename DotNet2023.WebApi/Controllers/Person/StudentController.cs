using AutoMapper;
using DotNet2023.Domain.Person;
using DotNet2023.WebApi.DtoModels.Person;
using DotNet2023.WebApi.Interfaces.Person;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Person;

[Route("api/[controller]")]
[ApiController]
public class StudentController : Controller
{
    private readonly IStudent _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<Student> _logger;

    public StudentController(IStudent repository,
        IMapper mapper, ILogger<Student> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// get all students
    /// </summary>
    /// <returns>IActionResult with List<StudentDto></returns>
    [HttpGet]
    public IActionResult GetStudents()
    {
        var educationWorker = _mapper
            .Map<List<StudentDto>>
            (_repository.GetStudents());
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(educationWorker);
    }

    /// <summary>
    /// Get student by id
    /// </summary>
    /// <param name="idStudent">id Student</param>
    /// <returns>IActionResult with StudentDto</returns>
    [HttpGet("GetStudent")]
    public IActionResult GetStudent(string idStudent)
    {
        var institution = _mapper
            .Map<StudentDto>
            (_repository.GetStudentById(idStudent));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);
    }

    /// <summary>
    /// Create a new student
    /// </summary>
    /// <param name="student">new student</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateStudent")]
    public IActionResult CreateStudent(
    [FromBody] StudentDto student)
    {
        if (student == null)
            return BadRequest(ModelState);

        var studentMap = _mapper
            .Map<Student>(student);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateStudent(studentMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    /// <summary>
    /// Delete by id Student
    /// </summary>
    /// <param name="idStudent">id Student</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteStudent")]
    public IActionResult DeleteStudent(string idStudent)
    {
        if (!_repository.StudentExistsById(idStudent))
            return NotFound();

        var studentToDelete = _repository
            .GetStudentById(idStudent);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || studentToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteStudent(studentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update model
    /// </summary>
    /// <param name="student">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateStudent")]
    public IActionResult UpdateStudent(
        [FromBody] StudentDto student)
    {
        if (student == null)
            return BadRequest(ModelState);

        if (!_repository.StudentExistsById(student.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var studentToUpdate = _mapper.Map<Student>(student);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.UpdateStudent(studentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }

}
