using AutoMapper;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DtoModels.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstitutionStructure;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : Controller
{
    private readonly IFaculty _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<Faculty> _logger;

    public FacultyController(IFaculty repository,
        IMapper mapper, ILogger<Faculty> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// Get all faculties
    /// </summary>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet]
    public IEnumerable<FacultyDto> GetFaculties() =>
        _mapper
            .Map<List<FacultyDto>>
            (_repository.GetFaculties());
    /// <summary>
    /// Async Get all faculties
    /// </summary>
    /// <returns>IActionResult with List<FacultyDto></returns>
    [HttpGet("GetFacultiesAsync")]
    public async Task<IEnumerable<FacultyDto>> GetFacultiesAsync() =>
        _mapper
            .Map<List<FacultyDto>>
            (await _repository.GetFacultiesAsync());

    /// <summary>
    /// Get faculty by id
    /// </summary>
    /// <param name="idFaculty">id faculty</param>
    /// <returns>IActionResult with FacultyDto</returns>
    [HttpGet("GetFaculty")]
    public FacultyDto GetFaculty(string idFaculty) =>
        _mapper
            .Map<FacultyDto>
            (_repository.GetFacultyById(idFaculty));
    /// <summary>
    /// Async Get faculty by id
    /// </summary>
    /// <param name="idFaculty">id faculty</param>
    /// <returns>IActionResult with FacultyDto</returns>
    [HttpGet("GetFacultyAsync")]
    public async Task<FacultyDto> GetFacultyAsync(string idFaculty) =>
        _mapper
            .Map<FacultyDto>
            (await _repository.GetFacultyByIdAsync(idFaculty));

    /// <summary>
    /// Create a new faculty
    /// </summary>
    /// <param name="faculty">new faculty</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateFaculty")]
    public IActionResult CreateFaculty(
    [FromBody] FacultyDto faculty)
    {
        if (faculty == null)
            return BadRequest(ModelState);

        var facultyMap = _mapper
            .Map<Faculty>(faculty);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateFaculty(facultyMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }
    /// <summary>
    /// Async Create a new faculty
    /// </summary>
    /// <param name="faculty">new faculty</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateFacultyAsync")]
    public async Task<IActionResult> CreateFacultyAsync(
    [FromBody] FacultyDto faculty)
    {
        if (faculty == null)
            return BadRequest(ModelState);

        var facultyMap = _mapper
            .Map<Faculty>(faculty);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.CreateFacultyAsync(facultyMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    /// <summary>
    /// Delete by id Faculty
    /// </summary>
    /// <param name="idFaculty">id Faculty</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteFaculty")]
    public IActionResult DeleteFaculty(string idFaculty)
    {
        if (!_repository.FacultytExistsById(idFaculty))
            return NotFound();

        var facultyToDelete = _repository
            .GetFacultyById(idFaculty);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || facultyToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteFaculty(facultyToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }
    /// <summary>
    /// Async Delete by id Faculty
    /// </summary>
    /// <param name="idFaculty">id Faculty</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteFacultyAsync")]
    public async Task<IActionResult> DeleteFacultyAsync(string idFaculty)
    {
        if (!await _repository.FacultyExistsByIdAsync(idFaculty))
            return NotFound();

        var facultyToDelete = await _repository
            .GetFacultyByIdAsync(idFaculty);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || facultyToDelete == null)
            return BadRequest(ModelState);

        if (!await _repository.DeleteFacultyAsync(facultyToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update model
    /// </summary>
    /// <param name="faculty">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateFaculty")]
    public IActionResult UpdateInstitution(
        [FromBody] FacultyDto faculty)
    {
        if (faculty == null)
            return BadRequest(ModelState);

        if (!_repository.FacultytExistsById(faculty.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var facultyToUpdate = _mapper.Map<Faculty>(faculty);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.UpdateFaculty(facultyToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
    /// <summary>
    /// Async Update model
    /// </summary>
    /// <param name="faculty">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateFacultyAsync")]
    public async Task<IActionResult> UpdateInstitutionAsync(
        [FromBody] FacultyDto faculty)
    {
        if (faculty == null)
            return BadRequest(ModelState);

        if (!await _repository.FacultyExistsByIdAsync(faculty.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var facultyToUpdate = _mapper.Map<Faculty>(faculty);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.UpdateFacultyAsync(facultyToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
