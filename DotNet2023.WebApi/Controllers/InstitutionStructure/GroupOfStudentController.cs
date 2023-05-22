using AutoMapper;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DtoModels.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstitutionStructure;

[Route("api/[controller]")]
[ApiController]
public class GroupOfStudentController : Controller
{
    private readonly IGroupOfStudents _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<GroupOfStudents> _logger;

    public GroupOfStudentController(IGroupOfStudents repository,
        IMapper mapper, ILogger<GroupOfStudents> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// Get all GroupOfStudents
    /// </summary>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet]
    public IEnumerable<GroupOfStudentsDto> GetGroupOfStudents() =>
        _mapper
            .Map<List<GroupOfStudentsDto>>
            (_repository.GetGroupOfStudents());
    /// <summary>
    /// Async Get all GroupOfStudents
    /// </summary>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet("GetGroupOfStudentsAsync")]
    public async Task<IEnumerable<GroupOfStudentsDto>> GetGroupOfStudentsAsync() =>
        _mapper
            .Map<List<GroupOfStudentsDto>>
            (await _repository.GetGroupOfStudentsAsync());

    /// <summary>
    /// Get GroupOfStudents by id
    /// </summary>
    /// <param name="idGroupOfStudent">id GroupOfStudents</param>
    /// <returns>IActionResult with FacultyDto</returns>
    [HttpGet("GetGroupOfStudent")]
    public GroupOfStudentsDto GetGroupOfStudent(string idGroupOfStudent) =>
        _mapper
            .Map<GroupOfStudentsDto>
            (_repository.GetGroupOfStudentstById(idGroupOfStudent));

    /// <summary>
    /// Async Get GroupOfStudents by id
    /// </summary>
    /// <param name="idGroupOfStudent">id GroupOfStudents</param>
    /// <returns>IActionResult with FacultyDto</returns>
    [HttpGet("GetGroupOfStudentAsync")]
    public async Task<GroupOfStudentsDto> GetGroupOfStudentAsync(string idGroupOfStudent) =>
         _mapper
            .Map<GroupOfStudentsDto>
            (await _repository.GetGroupOfStudentstByIdAsync(idGroupOfStudent));


    /// <summary>
    /// Create a new GroupOfStudent
    /// </summary>
    /// <param name="groupOfStudents">new groupOfStudents</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateGroupOfStudent")]
    public IActionResult CreateGroupOfStudent(
    [FromBody] GroupOfStudentsDto groupOfStudents)
    {
        if (groupOfStudents == null)
            return BadRequest(ModelState);

        var groupOfStudentsMap = _mapper
            .Map<GroupOfStudents>(groupOfStudents);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateGroupOfStudents(groupOfStudentsMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }
    /// <summary>
    /// Async Create a new GroupOfStudent
    /// </summary>
    /// <param name="groupOfStudents">new groupOfStudents</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateGroupOfStudentAsync")]
    public async Task<IActionResult> CreateGroupOfStudentAsync(
    [FromBody] GroupOfStudentsDto groupOfStudents)
    {
        if (groupOfStudents == null)
            return BadRequest(ModelState);

        var groupOfStudentsMap = _mapper
            .Map<GroupOfStudents>(groupOfStudents);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.CreateGroupOfStudentsAsync(groupOfStudentsMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    /// <summary>
    /// Delete by id GroupOfStudents
    /// </summary>
    /// <param name="idGroupOfStudents">id GroupOfStudents</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteGroupOfStudents")]
    public IActionResult DeleteGroupOfStudents(string idGroupOfStudents)
    {
        if (!_repository.GroupOfStudentsExistsById(idGroupOfStudents))
            return NotFound();

        var groupOfStudentToDelete = _repository
            .GetGroupOfStudentstById(idGroupOfStudents);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || groupOfStudentToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteGroupOfStudents(groupOfStudentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }
    /// <summary>
    /// Async Delete by id GroupOfStudents
    /// </summary>
    /// <param name="idGroupOfStudents">id GroupOfStudents</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteGroupOfStudentsAsync")]
    public async Task<IActionResult> DeleteGroupOfStudentsAsync(string idGroupOfStudents)
    {
        if (!await _repository.GroupOfStudentsExistsByIdAsync(idGroupOfStudents))
            return NotFound();

        var groupOfStudentToDelete = await _repository
            .GetGroupOfStudentstByIdAsync(idGroupOfStudents);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || groupOfStudentToDelete == null)
            return BadRequest(ModelState);

        if (!await _repository.DeleteGroupOfStudentsAsync(groupOfStudentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update model
    /// </summary>
    /// <param name="groupOfStudent">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateGroupOfStudents")]
    public IActionResult UpdateGroupOfStudents(
        [FromBody] GroupOfStudentsDto groupOfStudent)
    {
        if (groupOfStudent == null)
            return BadRequest(ModelState);

        if (!_repository.GroupOfStudentsExistsById(groupOfStudent.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var groupOfStudentToUpdate = _mapper.Map<GroupOfStudents>(groupOfStudent);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.UpdateGroupOfStudents(groupOfStudentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
    /// <summary>
    /// Async Update model
    /// </summary>
    /// <param name="groupOfStudent">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateGroupOfStudentsAsync")]
    public async Task<IActionResult> UpdateGroupOfStudentsAsync(
        [FromBody] GroupOfStudentsDto groupOfStudent)
    {
        if (groupOfStudent == null)
            return BadRequest(ModelState);

        if (!await _repository.GroupOfStudentsExistsByIdAsync(groupOfStudent.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var groupOfStudentToUpdate = _mapper.Map<GroupOfStudents>(groupOfStudent);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.UpdateGroupOfStudentsAsync(groupOfStudentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }

}
