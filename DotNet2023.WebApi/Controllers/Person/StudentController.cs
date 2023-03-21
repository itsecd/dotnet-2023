using AutoMapper;
using DotNet2023.Domain.Person;
using DotNet2023.WebApi.Interfaces.Person;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Person;

[Route("api/[controller]")]
[ApiController]
public class StudentController : Controller
{
    private readonly IStudent _repository;
    private readonly IMapper _mapper;

    public StudentController(IStudent repository,
        IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    [HttpGet]
    public IActionResult GetStudents()
    {
        var educationWorker = _mapper
            .Map<List<Student>>
            (_repository.GetStudents());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(educationWorker);
    }

    [HttpGet("GetStudent")]
    public IActionResult GetStudent(string idStudent)
    {
        var institution = _mapper
            .Map<EducationWorker>
            (_repository.GetStudentById(idStudent));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);
    }


    [HttpPost("CreateStudent")]
    public IActionResult CreateStudent(
    [FromBody] Student student)
    {
        if (student == null)
            return BadRequest(ModelState);

        var studentMap = _mapper
            .Map<Student>(student);

        if (!_repository.CreateStudent(studentMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteStudent")]
    public IActionResult DeleteStudent(string idStudent)
    {
        if (!_repository.StudentExistsById(idStudent))
            return NotFound();

        var studentToDelete = _repository
            .GetStudentById(idStudent);

        if (!ModelState.IsValid || studentToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteStudent(studentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateStudent")]
    public IActionResult UpdateStudent(
        [FromBody] EducationWorker educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        if (!_repository.StudentExistsById(educationWorker.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var studentToUpdate = _mapper.Map<Student>(educationWorker);
        if (!_repository.UpdateStudent(studentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }

}
