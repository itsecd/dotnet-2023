using AutoMapper;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstitutionStructure;

[Route("api/[controller]")]
[ApiController]
public class GroupOfStudentController : Controller
{
    private readonly IGroupOfStudents _repository;
    private readonly IMapper _mapper;

    public GroupOfStudentController(IGroupOfStudents repository,
        IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    [HttpGet]
    public IActionResult GetGroupOfStudents()
    {
        var institutions = _mapper
            .Map<List<GroupOfStudents>>
            (_repository.GetGroupOfStudents());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(institutions);
    }

    [HttpGet("GetGroupOfStudent")]
    public IActionResult GetGroupOfStudent(string idGroupOfStudent)
    {
        var institution = _mapper
            .Map<GroupOfStudents>
            (_repository.GetGroupOfStudentstById(idGroupOfStudent));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);
    }


    [HttpPost("CreateGroupOfStudent")]
    public IActionResult CreateGroupOfStudent(
    [FromBody] GroupOfStudents groupOfStudents)
    {
        if (groupOfStudents == null)
            return BadRequest(ModelState);

        var groupOfStudentsMap = _mapper
            .Map<GroupOfStudents>(groupOfStudents);

        if (!_repository.CreateGroupOfStudents(groupOfStudentsMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteGroupOfStudents")]
    public IActionResult DeleteGroupOfStudents(string idGroupOfStudents)
    {
        if (!_repository.GroupOfStudentsExistsById(idGroupOfStudents))
            return NotFound();

        var groupOfStudentToDelete = _repository
            .GetGroupOfStudentstById(idGroupOfStudents);

        if (!ModelState.IsValid || groupOfStudentToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteGroupOfStudents(groupOfStudentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateGroupOfStudents")]
    public IActionResult UpdateGroupOfStudents(
        [FromBody] GroupOfStudents groupOfStudent)
    {
        if (groupOfStudent == null)
            return BadRequest(ModelState);

        if (!_repository.GroupOfStudentsExistsById(groupOfStudent.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var groupOfStudentToUpdate = _mapper.Map<GroupOfStudents>(groupOfStudent);
        if (!_repository.UpdateGroupOfStudents(groupOfStudentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
