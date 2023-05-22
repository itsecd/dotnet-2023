using AutoMapper;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.WebApi.DtoModels.InstituteDocumentation;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using Microsoft.AspNetCore.Mvc;


namespace DotNet2023.WebApi.Controllers.InstituteDocumentation;

[Route("api/[controller]")]
[ApiController]
public class InstituteSpecialityController : Controller
{
    private readonly IInstituteSpeciality _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<InstituteSpeciality> _logger;

    public InstituteSpecialityController(IInstituteSpeciality repository,
        IMapper mapper, ILogger<InstituteSpeciality> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// Get all InstituteSpeciality
    /// </summary>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet]
    public IEnumerable<InstituteSpecialityDto> GetInstituteSpecialities() =>
        _mapper
            .Map<List<InstituteSpecialityDto>>
            (_repository.GetInstituteSpecialities());

    /// <summary>
    /// Async Get all InstituteSpeciality
    /// </summary>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesAsync")]
    public async Task<IEnumerable<InstituteSpecialityDto>> GetInstituteSpecialitiesAsync() =>
        _mapper
            .Map<List<InstituteSpecialityDto>>
            (await _repository.GetInstituteSpecialitiesAsync());


    /// <summary>
    /// Get InstituteSpecialityDto by code
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesByCode")]
    public IEnumerable<InstituteSpecialityDto> GetInstituteSpecialitiesByCode(string code) =>
        _mapper
            .Map<List<InstituteSpecialityDto>>
            (_repository.GetInstituteSpecialitiesByCode(code));
    /// <summary>
    /// Async Get InstituteSpecialityDto by code
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesByCodeAsync")]
    public async Task<IEnumerable<InstituteSpecialityDto>> GetInstituteSpecialitiesByCodeAsync(string code) =>
        _mapper
            .Map<List<InstituteSpecialityDto>>
            (await _repository.GetInstituteSpecialitiesByCodeAsync(code));



    /// <summary>
    /// Get InstituteSpecialityDto by id Institution
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesByInstitution")]
    public IEnumerable<InstituteSpecialityDto> GetInstituteSpecialitiesByInstitution(string idInstitution) =>
        _mapper
            .Map<List<InstituteSpecialityDto>>
            (_repository.GetInstituteSpecialitiesByInstitution(idInstitution));


    /// <summary>
    /// Async Get InstituteSpecialityDto by id Institution
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesByInstitutionAsync")]
    public async Task<IEnumerable<InstituteSpecialityDto>> GetInstituteSpecialitiesByInstitutionAsync(string idInstitution) =>
        _mapper
            .Map<List<InstituteSpecialityDto>>
            (await _repository.GetInstituteSpecialitiesByInstitutionAsync(idInstitution));


    /// <summary>
    /// Get InstituteSpeciality
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <param name="idInstitution">id institution</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpeciality")]
    public InstituteSpecialityDto GetInstituteSpeciality(string code, string idInstitution) =>
         _mapper
            .Map<InstituteSpecialityDto>
            (_repository.GetInstituteSpeciality(code, idInstitution));

    /// <summary>
    /// Async Get InstituteSpeciality
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <param name="idInstitution">id institution</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialityAsync")]
    public async Task<InstituteSpecialityDto> GetInstituteSpecialityAsync(string code, string idInstitution) =>
        _mapper
            .Map<InstituteSpecialityDto>
            (await _repository.GetInstituteSpecialityAsync(code, idInstitution));

    /// <summary>
    /// Create a new instituteSpeciality
    /// </summary>
    /// <param name="instituteSpeciality">new instituteSpeciality</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateInstituteSpeciality")]
    public IActionResult CreateInstituteSpeciality(
    [FromBody] InstituteSpecialityDto instituteSpeciality)
    {
        if (instituteSpeciality == null)
            return BadRequest(ModelState);

        var instituteSpecialityMap = _mapper
            .Map<InstituteSpeciality>(instituteSpeciality);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateInstituteSpeciality(instituteSpecialityMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }
    /// <summary>
    /// Async Create a new instituteSpeciality
    /// </summary>
    /// <param name="instituteSpeciality">new instituteSpeciality</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateInstituteSpecialityAsync")]
    public async Task<IActionResult> CreateInstituteSpecialityAsync(
    [FromBody] InstituteSpecialityDto instituteSpeciality)
    {
        if (instituteSpeciality == null)
            return BadRequest(ModelState);

        var instituteSpecialityMap = _mapper
            .Map<InstituteSpeciality>(instituteSpeciality);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.CreateInstituteSpecialityAsync(instituteSpecialityMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }


    /// <summary>
    /// Delete by code and id institution
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteInstituteSpeciality")]
    public IActionResult DeleteInstituteSpeciality(string code, string idInstitution)
    {
        if (!_repository.InstituteSpecialityExistsByCode(idInstitution))
            return NotFound();

        var instituteSpecialityToDelete = _repository
            .GetInstituteSpeciality(code, idInstitution);

        _logger.LogInformation($"ModelState {ModelState}, method DeleteInstituteSpeciality");

        if (!ModelState.IsValid || instituteSpecialityToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteInstituteSpeciality(instituteSpecialityToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }
    /// <summary>
    /// Async Delete by code and id institution
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteInstituteSpecialityAsync")]
    public async Task<IActionResult> DeleteInstituteSpecialityAsync(
        string code, string idInstitution)
    {
        if (!await _repository.InstituteSpecialityExistsByCodeAsync(idInstitution))
            return NotFound();

        var instituteSpecialityToDelete = await _repository
            .GetInstituteSpecialityAsync(code, idInstitution);

        _logger.LogInformation($"ModelState {ModelState}, method DeleteInstituteSpeciality");

        if (!ModelState.IsValid || instituteSpecialityToDelete == null)
            return BadRequest(ModelState);

        if (!await _repository.DeleteInstituteSpecialityAsync(instituteSpecialityToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update model
    /// </summary>
    /// <param name="instituteSpeciality">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateInstituteSpeciality")]
    public IActionResult UpdateInstituteSpeciality(
    [FromBody] InstituteSpecialityDto instituteSpeciality)
    {
        if (instituteSpeciality == null)
            return BadRequest(ModelState);
        _logger.LogInformation($"ModelState {ModelState}, method UpdateInstituteSpeciality");

        if (!_repository.InstituteSpecialityExists(
            instituteSpeciality.IdSpeciality,
            instituteSpeciality.IdHigherEducationInstitution))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var institutionToUpdate = _mapper.Map<InstituteSpeciality>(instituteSpeciality);
        if (!_repository.UpdateInstituteSpeciality(institutionToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
    /// <summary>
    /// Async Update model
    /// </summary>
    /// <param name="instituteSpeciality">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateInstituteSpecialityAsync")]
    public async Task<IActionResult> UpdateInstituteSpecialityAsync(
    [FromBody] InstituteSpecialityDto instituteSpeciality)
    {
        if (instituteSpeciality == null)
            return BadRequest(ModelState);
        _logger.LogInformation($"ModelState {ModelState}, method UpdateInstituteSpeciality");

        if (!await _repository.InstituteSpecialityExistsAsync(
            instituteSpeciality.IdSpeciality,
            instituteSpeciality.IdHigherEducationInstitution))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var institutionToUpdate = _mapper.Map<InstituteSpeciality>(instituteSpeciality);
        if (!await _repository.UpdateInstituteSpecialityAsync(institutionToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}