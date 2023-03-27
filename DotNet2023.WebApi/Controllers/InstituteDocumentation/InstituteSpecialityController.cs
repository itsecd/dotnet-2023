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
    public IActionResult GetInstituteSpecialities()
    {
        var instituteSpecialities = _mapper
            .Map<List<InstituteSpecialityDto>>
            (_repository.GetInstituteSpecialities());
        _logger.LogInformation($"ModelState {ModelState}, method GetInstituteSpecialities");

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(instituteSpecialities);
    }

    /// <summary>
    /// Get InstituteSpecialityDto by code
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesByCode")]
    public IActionResult GetInstituteSpecialitiesByCode(string code)
    {
        var instituteSpecialit = _mapper
            .Map<List<InstituteSpecialityDto>>
            (_repository.GetInstituteSpecialitiesByCode(code));
        _logger.LogInformation($"ModelState {ModelState}, method GetInstituteSpecialitiesByCode");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpecialit);
    }

    /// <summary>
    /// Get InstituteSpecialityDto by id Institution
    /// </summary>
    /// <param name="idInstitution">id Institution</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpecialitiesByInstitution")]
    public IActionResult GetInstituteSpecialitiesByInstitution(string idInstitution)
    {
        var instituteSpecialit = _mapper
            .Map<List<InstituteSpecialityDto>>
            (_repository.GetInstituteSpecialitiesByInstitution(idInstitution));
        _logger.LogInformation($"ModelState {ModelState}, " +
            $"method GetInstituteSpecialitiesByInstitution");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpecialit);
    }

    /// <summary>
    /// Get InstituteSpeciality
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <param name="idInstitution">id institution</param>
    /// <returns>IActionResult with List<InstituteSpecialityDto></returns>
    [HttpGet("GetInstituteSpeciality")]
    public IActionResult GetInstituteSpeciality(string code, string idInstitution)
    {
        var instituteSpeciality = _mapper
            .Map<InstituteSpecialityDto>
            (_repository.GetInstituteSpeciality(code, idInstitution));
        _logger.LogInformation($"ModelState {ModelState}, method GetInstituteSpeciality");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpeciality);
    }

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
}
